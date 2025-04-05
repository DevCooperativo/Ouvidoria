using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IAdministradorService

{
    IEnumerable<AdministradorDTO> GetAllAsync();
    Task CreateAsync(AdministradorDTO administrador);
    Task UpdateAsync(AdministradorDTO administrador);
    Task<AdministradorDTO> GetDTOByIdAsync(int id);
    Task<AdministradorDTO> GetDTOByEmailAsync(string email);
}