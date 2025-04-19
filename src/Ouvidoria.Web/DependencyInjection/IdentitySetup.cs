using Microsoft.AspNetCore.Identity;
using Ouvidoria.Infrastructure.Data;
using Ouvidoria.Infrastructure.Data.Account;

namespace Ouvidoria.Web.DependencyInjection;
public static class IdentitySetup
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = true;

            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(180);

            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/User/Login";
            options.LogoutPath = "/User/Logout";
            options.AccessDeniedPath = "/User/AccessDenied";
        });

        services.AddAuthorizationBuilder()
            .AddPolicy("Administrador Policy", policy => policy.RequireRole(ApplicationUser.TipoAdministrador))
            .AddPolicy("Cidadão Policy", policy => policy.RequireRole(ApplicationUser.TipoCidadao));

        return services;
    }

    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = new[] { ApplicationUser.TipoAdministrador, ApplicationUser.TipoCidadao };

        foreach (var role in roles)
        {
            var roleExists = await roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }


}