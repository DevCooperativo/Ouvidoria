using Microsoft.AspNetCore.Mvc.Infrastructure;
using Ouvidoria.Infrastructure.Data;
using Ouvidoria.Interfaces;
using Ouvidoria.Services;
using Ouvidoria.Web.Controllers;

namespace Ouvidoria.Web.DependencyInjection;
public static class ServiceConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddHttpContextAccessor();
        services.AddOptions();
        services.AddHttpClient<HomeController>();

        services.AddScoped<IDenunciaService, DenunciaService>();
        services.AddScoped<IAdministradorService, AdministradorService>();
        services.AddScoped<ICidadaoService, CidadaoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
    }
}