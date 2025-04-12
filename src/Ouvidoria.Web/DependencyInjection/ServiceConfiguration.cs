using Ouvidoria.Infrastructure.ObjectStorage;
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
        services.AddScoped<IRegistroService, RegistroService>();
        services.AddScoped<IAdministradorService, AdministradorService>();
        services.AddScoped<ICidadaoService, CidadaoService>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        services.AddScoped<IObjectStorageService, ObjectStorageService>();
        ObjectStorageProviderSettings objectStorageProviderSettings = new();
        configuration.GetSection("ObjectStorage").Bind(objectStorageProviderSettings);
        services.Configure<ObjectStorageProviderSettings>(options =>
        {
            options.ServiceUrl = Environment.GetEnvironmentVariable("OBJECT_STORAGE_URL") ?? objectStorageProviderSettings.ServiceUrl;
            options.AccessKey = Environment.GetEnvironmentVariable("OBJECT_STORAGE_ACCESS_KEY") ?? objectStorageProviderSettings.AccessKey;
            options.SecretKey = Environment.GetEnvironmentVariable("OBJECT_STORAGE_SECRET_KEY") ?? objectStorageProviderSettings.SecretKey;
            options.Bucket = Environment.GetEnvironmentVariable("OBJECT_STORAGE_BUCKET") ?? objectStorageProviderSettings.Bucket;
        });
    }
}