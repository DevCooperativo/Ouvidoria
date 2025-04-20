using System.Security.Claims;
using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IRegistroService

{
    IEnumerable<RegistroDTO> GetAll();
    Task<string> CreateAsync(RegistroDTO solicitacao, ClaimsPrincipal claimsPrincipal);
    Task UpdateAsync(RegistroDTO solicitacao);
    Task<RegistroDTO> GetDTOByIdAsync(int id);
    RegistroDTO GetDTOByTokenAsync(string token);
    Task DeleteAsync(int id);
    Task ChangeVisibility(int id);
    IEnumerable<RegistroDTO> GetAllVisible();
}