using System.Security.Claims;
using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Enums;
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

    public async Task CreateAsync(RegistroDTO registro, ClaimsPrincipal claimsPrincipal)
    {
        ArgumentNullException.ThrowIfNull(registro);
        if (registro.Arquivo is null)
        {
            throw new Exception("Insira ao menos um arquivo");
        }


        Cidadao? cidadao = null;

        if (claimsPrincipal.Identity?.IsAuthenticated ?? false)
        {
            cidadao = await _cidadaoRepository.GetCidadaoByClaimsAsync(claimsPrincipal);
        }
        Registro newRegistro = new(registro.Tipo,
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
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroDTO> GetAll()
    {
        return _registroRepository.GetAll().Select(x => (RegistroDTO)x);
    }

    public IEnumerable<RegistroDTO> GetAllVisible()
    {
        throw new NotImplementedException();
    }

    public async Task<RegistroDTO> GetDTOByIdAsync(int id)
    {
        var teste = await _registroRepository.GetByIdAsync(id, "Historico", "Autor", "Arquivos");
        RegistroDTO registroDTO = new(teste ?? throw new Exception("Não foi encontrado nenhum registro com esse id"));
        return registroDTO;
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
}