using Ouvidoria.Domain;
using Ouvidoria.Infrastructure;
using Ouvidoria.Infrastructure.Data.Repositories;

namespace Ouvidoria.Web.DependencyInjection;
public static class RepositoryConfiguration
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    }
}