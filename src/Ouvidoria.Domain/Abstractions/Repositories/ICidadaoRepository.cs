using System.Security.Claims;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.Domain.Abstractions.Repositories;

public interface ICidadaoRepository : IBaseRepository<Cidadao>
{
    Task<Cidadao?> GetByEmailAsync(string email);
    Task<Cidadao?> GetCidadaoByClaimsAsync(ClaimsPrincipal claimsPrincipal);
}
