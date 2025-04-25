using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.Domain.Models;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class RegistroService : IRegistroService
{
    private readonly ICidadaoService _cidadaoService;
    private readonly IObjectStorageService _objectStorageService;
    private readonly IBaseRepository<Registro> _registroRepository;
    private readonly ICidadaoRepository _cidadaoRepository;
    private readonly IAdministradorService _administradorService;
    private readonly IBaseRepository<Administrador> _administradorRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegistroService(ICidadaoService cidadaoService, IBaseRepository<Registro> registroRepository, ICidadaoRepository cidadaoRepository, IUnitOfWork unitOfWork, IObjectStorageService objectStorageService, IAdministradorService administradorService, UserManager<ApplicationUser> userManager, IBaseRepository<Administrador> administradorRepository)
    {
        _cidadaoService = cidadaoService;
        _registroRepository = registroRepository;
        _cidadaoRepository = cidadaoRepository;
        _unitOfWork = unitOfWork;
        _objectStorageService = objectStorageService;
        _administradorService = administradorService;
        _userManager = userManager;
        _administradorRepository = administradorRepository;
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

        Random rnd = new();
        List<AdministradorDTO> listAdminDTO = _administradorService.GetAllAsync().ToList();
        AdministradorDTO adminEscolhido = listAdminDTO[rnd.Next(listAdminDTO.Count)];
        Administrador admin = await _administradorRepository.GetByIdAsync(adminEscolhido.Id) ?? throw new Exception("Usuário administrador não encontrado");

        Registro newRegistro = new(
            registro.Tipo,
            registro.IsAnonima,
            registro.Titulo,
            registro.Descricao,
            registro.TipoRegistro,
            registro.Status,
            cidadao, admin
            );


        if (registro.Arquivo.Bytes.Length > 0)
        {
            string nomeS3 = await _objectStorageService.UploadFileAsync(registro.Arquivo);
            Arquivo arquivo = new(registro.Arquivo.Nome, nomeS3, registro.Arquivo.TipoArquivo);
            newRegistro.AdicionarArquivo(arquivo);
        }

        _registroRepository.Add(newRegistro);
        _ = await _unitOfWork.Commit();
        return newRegistro.AccessToken.ToString();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RegistroDTO> GetAll()
    {
        var teste = _registroRepository.GetAll("Administrador").Select(x => (RegistroDTO)x);
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
        return new RegistroDTO(_registroRepository.GetAllReadOnly("Historico", "Arquivos").Where(x => x.AccessToken.ToString() == token).FirstOrDefault() ?? throw new Exception("Não foi encontrado nenhum registro ou este registro está indisponível para consulta"));
    }


    public ChartDataDTO GetCountPerMonthToChartDataDTO()
    {
        var teste = _registroRepository.GetAll().Where(x => x.DataCriacao.Year == DateTime.Now.Year).OrderBy(x => x.DataCriacao.Month).GroupBy(x => new { x.DataCriacao.Month });
        List<string> Labels = [.. teste.Select(x => x.Key.Month.ToString())];
        List<int> Data = [.. teste.Select(x => x.Count())];
        return new ChartDataDTO(Labels, Data);
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