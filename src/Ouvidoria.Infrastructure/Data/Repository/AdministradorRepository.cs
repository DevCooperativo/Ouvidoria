using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Domain.Models;
using Ouvidoria.Infrastructure.Data.Repositories;

namespace Ouvidoria.Infrastructure.Data.Repository;

public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
{
    private readonly DataContext _context;
    public AdministradorRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Administrador?> GetByEmailAsync(string email)
    {
        var teste =  await _context.Set<Administrador>().FirstOrDefaultAsync(a => a.Email == email);
        return teste;
    }
}
