using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IDenunciaService

{
    IEnumerable<RegistroBaseDTO> GetAllAsync();
    Task CreateAsync(RegistroBaseDTO denuncia);
    Task UpdateAsync(RegistroBaseDTO denuncia);
    Task<RegistroBaseDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<RegistroBaseDTO> GetAllVisible();
}