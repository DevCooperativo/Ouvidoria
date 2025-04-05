using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface ISolicitacaoService

{
    IEnumerable<RegistroBaseDTO> GetAllAsync();
    Task CreateAsync(RegistroBaseDTO solicitacao);
    Task UpdateAsync(RegistroBaseDTO solicitacao);
    Task<RegistroBaseDTO> GetDTOByIdAsync(int id);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<RegistroBaseDTO> GetAllVisible();
}