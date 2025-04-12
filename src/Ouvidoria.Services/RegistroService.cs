using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Models;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class RegistroService : IRegistroService
{
    private readonly IRegistroRepository _registroRepository;
    private readonly ICidadaoRepository _cidadaoRepository;
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegistroService(IRegistroRepository registroRepository, ICidadaoRepository cidadaoRepository, IAdministradorRepository administradorRepository, IUnitOfWork unitOfWork)
    {
        _registroRepository = registroRepository;
        _cidadaoRepository = cidadaoRepository;
        _administradorRepository = administradorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(RegistroDTO registro)
    {
        ArgumentNullException.ThrowIfNull(registro);

        Cidadao cidadao = await _cidadaoRepository.GetByIdAsync(registro.AutorId) ?? throw new ArgumentException("O cidadão não foi encontrado");

        Administrador administrador = await _administradorRepository.GetByIdAsync(registro.AdministradorId) ?? throw new ArgumentException("O administrador não foi encontrado");

        Registro newRegistro = new(registro.Descricao, registro.TipoRegistro, cidadao, administrador);

        _registroRepository.Add(newRegistro);

        _ = await _unitOfWork.Commit();
    }

    public async Task DeleteAsync(int id)
    {
        var registro = await _registroRepository.GetByIdAsync(id) ?? throw new Exception("Não foi possível encontrar o registro");
        _registroRepository.Delete(registro);
        _ = await _unitOfWork.Commit();
    }

    public IEnumerable<RegistroDTO> GetAllAsync()
    {
        var registros = _registroRepository.GetAllReadOnly();
        return registros.Select(x => new RegistroDTO(x)) ?? [];
    }

    public async Task<RegistroDTO> GetDTOByIdAsync(int id)
    {
        var registro = await _registroRepository.GetByIdAsync(id, "Historico", "Arquivos") ?? throw new Exception("Não foi possível encontrar o registro.");
        RegistroDTO registroDTO = new(registro);

        return registroDTO;
    }

    public async Task UpdateAsync(RegistroDTO registro)
    {
        ArgumentNullException.ThrowIfNull(registro);

        Registro currentRegistro = await _registroRepository.GetByIdAsync(registro.Id, "Historico", "Arquivos") ?? throw new Exception("Não foi possível encontrar a cor");
        Administrador administrador = await _administradorRepository.GetByIdAsync(registro.AdministradorId) ?? throw new Exception("Não foi possível encontrar o administrador");

        currentRegistro.Update(registro.Descricao, registro.Status, administrador);

        _registroRepository.Update(currentRegistro);

        _ = await _unitOfWork.Commit();
    }
}