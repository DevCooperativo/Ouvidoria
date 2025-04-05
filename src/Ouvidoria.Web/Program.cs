using Microsoft.EntityFrameworkCore;
using Ouvidoria.Infrastructure.Data;
using Ouvidoria.Web.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices(builder.Configuration);


string environment = builder.Environment.EnvironmentName;
string? connectionString;

if (environment == "Production" || environment == "Staging")
{
    string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "";
    string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "";
    string dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "";
    string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";

    connectionString = $"Server={dbHost};Database={dbName};User={dbUser};Password={dbPassword};";
}
else
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
