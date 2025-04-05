using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface ISolicitacaoService

{
    IEnumerable<SolicitacaoDTO> GetAllAsync();
    Task CreateAsync(SolicitacaoDTO category);
    Task UpdateAsync(SolicitacaoDTO category);
    Task<SolicitacaoDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<SolicitacaoDTO> GetAllVisible();
}