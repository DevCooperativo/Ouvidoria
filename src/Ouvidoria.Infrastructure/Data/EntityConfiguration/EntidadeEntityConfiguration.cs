using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class EntidadeEntityConfiguration : IEntityTypeConfiguration<Entidade>
{
    public void Configure(EntityTypeBuilder<Entidade> builder)
    {
        builder.Property(e => e.Nome).HasMaxLength(150);
        builder.Property(e => e.Telefone).HasMaxLength(11);
        builder.Property(e => e.Cnpj).HasMaxLength(14);
    }
}