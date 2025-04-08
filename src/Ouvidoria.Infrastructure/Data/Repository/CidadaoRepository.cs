using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Models;
using Ouvidoria.Infrastructure.Data.Repositories;

namespace Ouvidoria.Infrastructure.Data.Repository;

public class CidadaoRepository : BaseRepository<Cidadao>, ICidadaoRepository
{
    private readonly DataContext _context;
    public CidadaoRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public Task<Cidadao?> GetByEmailAsync(string email)
    {
        return _context.Set<Cidadao>().FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
    }
    public async Task<Cidadao?> GetCidadaoByClaimsAsync(ClaimsPrincipal claimsPrincipal)
    {
        return await GetByEmailAsync(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? "");
    }
}

