using Ouvidoria.Domain;
using Ouvidoria.Domain.Abstractions.Repositories;
using Ouvidoria.Infrastructure;
using Ouvidoria.Infrastructure.Data.Repositories;
using Ouvidoria.Infrastructure.Data.Repository;

namespace Ouvidoria.Web.DependencyInjection;
public static class RepositoryConfiguration
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAdministradorRepository, AdministradorRepository>();
        services.AddScoped<ICidadaoRepository, CidadaoRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    }
}