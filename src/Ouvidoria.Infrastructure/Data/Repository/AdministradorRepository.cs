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

    public Task<Administrador?> GetByEmailAsync(string email)
    {
        return _context.Set<Administrador>().FirstOrDefaultAsync(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
