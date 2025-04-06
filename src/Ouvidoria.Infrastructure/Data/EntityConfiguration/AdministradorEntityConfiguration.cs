using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.Infrastructure.Data.EntityConfiguration;

public class AdministradorEntityConfiguration : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Email).HasMaxLength(256);
        builder.Property(c => c.Nome).HasMaxLength(256);
    }
}
