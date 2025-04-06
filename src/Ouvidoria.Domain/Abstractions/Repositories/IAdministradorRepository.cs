using Ouvidoria.Domain.Models;

namespace Ouvidoria.Domain.Abstractions.Repositories;

public interface IAdministradorRepository : IBaseRepository<Administrador>
{
    Task<Administrador?> GetByEmailAsync(string email);
}
