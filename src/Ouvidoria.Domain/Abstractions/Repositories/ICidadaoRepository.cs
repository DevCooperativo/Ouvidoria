using Ouvidoria.Domain.Models;

namespace Ouvidoria.Domain.Abstractions.Repositories;

public interface ICidadaoRepository : IBaseRepository<Cidadao>
{
    Task<Cidadao?> GetByEmailAsync(string email);
}
