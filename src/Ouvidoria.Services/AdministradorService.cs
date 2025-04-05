using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Models;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;

namespace Ouvidoria.Services;

public class AdministradorService : IAdministradorService
{
    private readonly IAdministradorRepository _repositorio;
    private readonly IUnitOfWork _unitOfWork;
    public AdministradorService(IUnitOfWork unitOfWork, IAdministradorRepository repositorio)
    {
        _repositorio = repositorio;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(AdministradorDTO administrador)
    {
        ArgumentNullException.ThrowIfNull(administrador);

        bool exists = _repositorio.GetAllReadOnly().Any(x => x.Email.Equals(administrador.Email, StringComparison.InvariantCultureIgnoreCase));
        if (exists)
            throw new ArgumentException("Esse e-mail está em uso");

        Administrador newAdministrador = new(administrador.Nome, administrador.Email);

        var administradorSaved = _repositorio.Add(newAdministrador);

        _ = await _unitOfWork.Commit();
    }

    public IEnumerable<AdministradorDTO> GetAllAsync()
    {
        var administradores = _repositorio.GetAllReadOnly();
        return administradores.Select(x => new AdministradorDTO(x)) ?? [];
    }

    public async Task<AdministradorDTO> GetDTOByEmailAsync(string email)
    {
        Administrador administrador = await _repositorio.GetByEmailAsync(email) ?? throw new ArgumentException("Email não encontrado");

        return new AdministradorDTO(administrador);
    }

    public async Task<AdministradorDTO> GetDTOByIdAsync(int id)
    {
        Administrador administrador = await _repositorio.GetByIdAsync(id) ?? throw new ArgumentException("Administrador não encontrado");

        return new AdministradorDTO(administrador);
    }

    public async Task UpdateAsync(AdministradorDTO administrador)
    {
        ArgumentNullException.ThrowIfNull(administrador);

        bool exists = _repositorio.GetAllReadOnly().Any(x => x.Email.Equals(administrador.Email, StringComparison.InvariantCultureIgnoreCase) && x.Id != administrador.Id);
        if (exists)
            throw new ArgumentException("Email já cadastrado");

        Administrador currentAdministrador = await _repositorio.GetByIdAsync(administrador.Id) ?? throw new Exception("Não foi possível encontrar a cor");

        currentAdministrador.Update(administrador.Nome, administrador.Email);

        var administradorSaved = _repositorio.Update(currentAdministrador);

        _ = await _unitOfWork.Commit();
    }
}
