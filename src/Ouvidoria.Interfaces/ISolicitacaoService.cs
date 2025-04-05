using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface ISolicitacaoService

{
    IEnumerable<RegistroDTO> GetAllAsync();
    Task CreateAsync(RegistroDTO solicitacao);
    Task UpdateAsync(RegistroDTO solicitacao);
    Task<RegistroDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<RegistroDTO> GetAllVisible();
}