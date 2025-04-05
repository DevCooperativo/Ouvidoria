using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Models;
using Ovidoria.Infrastructure.Data.Account;

namespace Ouvidoria.Infrastructure.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<Denuncia> Denuncias { get; set; }
}