using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;
using Ouvidoria.Infrastructure.Data.Account;

namespace Ouvidoria.Infrastructure.Data.EntityConfiguration;

public class CidadaoEntityConfiguration : IEntityTypeConfiguration<Cidadao>
{
    public void Configure(EntityTypeBuilder<Cidadao> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Email).HasMaxLength(256);
        builder.Property(c => c.Sexo);
        builder.Property(c => c.Nome).HasMaxLength(256);
        builder.Property(c => c.Cpf).HasMaxLength(14);
        builder.Property(c => c.Endereco).HasMaxLength(256);
        builder.Property(c => c.Telefone).HasMaxLength(11);
    }
}
