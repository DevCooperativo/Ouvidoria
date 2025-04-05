using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Domain.Models;
using Ouvidoria.Infrastructure.Data.Account;

namespace Ouvidoria.Infrastructure.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ArquivoEntityConfiguration());
        builder.ApplyConfiguration(new EntidadeEntityConfiguration());
        builder.ApplyConfiguration(new RegistroEntityConfiguration());
        builder.ApplyConfiguration(new HistoricoRegistroEntityConfiguration());
        builder.ApplyConfiguration(new NotificacaoEntityConfiguration());
        base.OnModelCreating(builder);
    }

    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<Registro> Registros { get; set; }
    public DbSet<HistoricoRegistro> HistoricoRegistros { get; set; }
    public DbSet<Notificacao> Notificacaos { get; set; }
}