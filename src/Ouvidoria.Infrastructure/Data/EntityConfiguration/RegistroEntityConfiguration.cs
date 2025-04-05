using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class RegistroEntityConfiguration : IEntityTypeConfiguration<Registro>
{
    public void Configure(EntityTypeBuilder<Registro> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Tipo).HasMaxLength(40);
        builder.Property(d => d.Status);
        builder.Property(d => d.TipoRegistro);
        builder.HasOne(d => d.Autor).WithMany().HasForeignKey(d => d.AutorId);
        builder.HasOne(d => d.Alvo).WithMany().HasForeignKey(d => d.AlvoId);
        builder.HasOne(d => d.Administrador).WithMany().HasForeignKey(d => d.AdministradorId);
        builder.HasMany(d => d.Arquivos).WithOne(a => a.Registro).HasForeignKey(a => a.RegistroId);
        builder.HasMany(d => d.Historico).WithOne(h => h.Registro).HasForeignKey(h => h.RegistroId);
    }
}