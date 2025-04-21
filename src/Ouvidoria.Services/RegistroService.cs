using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.Domain.Models;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class RegistroService : IRegistroService
{
    private readonly ICidadaoService _cidadaoService;
    private readonly IObjectStorageService _objectStorageService;
    private readonly IBaseRepository<Registro> _registroRepository;
    private readonly ICidadaoRepository _cidadaoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistroService(ICidadaoService cidadaoService, IBaseRepository<Registro> registroRepository, ICidadaoRepository cidadaoRepository, IUnitOfWork unitOfWork, IObjectStorageService objectStorageService)
    {
        _cidadaoService = cidadaoService;
        _registroRepository = registroRepository;
        _cidadaoRepository = cidadaoRepository;
        _unitOfWork = unitOfWork;
        _objectStorageService = objectStorageService;
    }

    public Task ChangeVisibility(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateAsync(RegistroDTO registro, ClaimsPrincipal claimsPrincipal)
    {
        ArgumentNullException.ThrowIfNull(registro);
        if (registro.Arquivo is null)
        {
            throw new Exception("Insira ao menos um arquivo");
        }


        Cidadao? cidadao = null;

        if ((claimsPrincipal.Identity?.IsAuthenticated ?? false) && !registro.IsAnonima)
        {
            cidadao = await _cidadaoRepository.GetCidadaoByClaimsAsync(claimsPrincipal);
        }
        Registro newRegistro = new(
            registro.Tipo,
            registro.IsAnonima,
            registro.Titulo,
            registro.Descricao,
            registro.TipoRegistro,
            registro.Status,
            cidadao);


        if (registro.Arquivo.Bytes.Length > 0)
        {
            string nomeS3 = await _objectStorageService.UploadFileAsync(registro.Arquivo);
            Arquivo arquivo = new(registro.Arquivo.Nome, nomeS3, registro.Arquivo.TipoArquivo);
            newRegistro.AdicionarArquivo(arquivo);
        }

        _registroRepository.Add(newRegistro);
        _ = await _unitOfWork.Commit();
        return GenerateRegistryAccessToken(newRegistro.Id, registro.Titulo, registro.IsAnonima);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroDTO> GetAll()
    {
        var teste = _registroRepository.GetAll().Select(x => (RegistroDTO)x);
        return teste;
    }

    public IEnumerable<RegistroDTO> GetAllVisible()
    {
        throw new NotImplementedException();
    }

    public async Task<RegistroDTO> GetDTOByIdAsync(int id)
    {
        return new RegistroDTO(await _registroRepository.GetByIdAsync(id, "Historico", "Autor", "Arquivos") ?? throw new Exception("Não foi encontrado nenhum registro com esse id"));
    }

    public RegistroDTO GetDTOByTokenAsync(string token)
    {
        string ret = Decode(token) ?? "";
        int id = Convert.ToInt32(ret.Split("|")[0]);
        return new RegistroDTO(_registroRepository.GetAllReadOnly("Historico", "Arquivos").Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Não foi encontrado nenhum registro ou este registro está indisponível para consulta"));
    }


    public ChartDataDTO GetCountPerMonthToChartDataDTO()
    {
        var teste = _registroRepository.GetAll().Where(x=>x.DataCriacao.Year == DateTime.Now.Year).OrderBy(x=>x.DataCriacao.Month).GroupBy(x => new { x.DataCriacao.Month });
        List<string> Labels = [.. teste.Select(x => x.Key.Month.ToString())];
        List<int> Data = [.. teste.Select(x=> x.Count())];
        return new ChartDataDTO(Labels,Data);
    }


    public async Task UpdateAsync(RegistroDTO registro)
    {
        Registro oldRegistro = await _registroRepository.GetByIdAsync(registro.Id) ?? throw new Exception("Nenhum registro encontrado");

        if (oldRegistro.Status is StatusEnum.Cancelado or StatusEnum.Concluido) throw new Exception("O registro já foi fechado e não pode mais ser editado");

        HistoricoRegistroDTO historico = registro.Historicos.Last();

        oldRegistro.AddHistorico(historico.Status, historico.Feedback);

        _registroRepository.Update(oldRegistro);

        _ = await _unitOfWork.Commit();
    }


    private static string GenerateRegistryAccessToken(int id, string titulo, bool isAnonima)
    {
        string Key = "o0P2VLbTMQJMig1zU64Zs27KpW8i3yIm";
        string IV = "Cwk66EmgH0k1Gfsr";
        StringBuilder InfoParaToken = new StringBuilder();
        InfoParaToken.AppendJoin("|", [id, titulo, isAnonima]);
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(Key);
        aesAlg.IV = Encoding.UTF8.GetBytes(IV);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        byte[] inputBytes = Encoding.UTF8.GetBytes(InfoParaToken.ToString());
        byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Convert.ToBase64String(encryptedBytes);
    }

    private static string Decode(string encryptedText)
    {
        string Key = "o0P2VLbTMQJMig1zU64Zs27KpW8i3yIm";
        string IV = "Cwk66EmgH0k1Gfsr";
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(Key);
        aesAlg.IV = Encoding.UTF8.GetBytes(IV);

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }


}