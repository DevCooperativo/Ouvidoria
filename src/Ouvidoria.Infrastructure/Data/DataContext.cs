using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.Infrastructure.Data;

public class DataContext : IdentityDbContext<Usuario>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<Denuncia> Denuncias { get; set; }
}