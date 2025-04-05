namespace Ouvidoria.Interfaces;

public interface ICategoryService

{
    IEnumerable<DenunciaDTO> GetAllAsync();
    Task CreateAsync(DenunciaDTO category);
    Task UpdateAsync(DenunciaDTO category);
    Task<DenunciaDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<DenunciaDTO> GetAllVisible();
}