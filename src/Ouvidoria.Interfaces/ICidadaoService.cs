using System.Security.Claims;
using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface ICidadaoService

{
    Task<CidadaoDTO> GetCidadaoByClaimsAsync(ClaimsPrincipal claimsPrincipal);
    IEnumerable<CidadaoDTO> GetAllAsync();
    Task CreateAsync(CidadaoDTO cidadaoDTO);
    Task UpdateAsync(CidadaoDTO cidadaoDTO);
    Task<CidadaoDTO> GetDTOByIdAsync(int id);
    Task<CidadaoDTO> GetDTOByEmailAsync(string email);
}