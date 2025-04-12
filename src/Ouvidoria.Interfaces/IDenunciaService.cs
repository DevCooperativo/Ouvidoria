using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IRegistroService

{
    IEnumerable<RegistroDTO> GetAllAsync();
    Task CreateAsync(RegistroDTO denuncia);
    Task UpdateAsync(RegistroDTO denuncia);
    Task<RegistroDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
}