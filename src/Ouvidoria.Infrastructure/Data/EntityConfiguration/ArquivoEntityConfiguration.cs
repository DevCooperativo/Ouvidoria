using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class ArquivoEntityConfiguration : IEntityTypeConfiguration<Arquivo>
{
    public void Configure(EntityTypeBuilder<Arquivo> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Nome)
        .HasMaxLength(100);
        builder.Property(a => a.NomeS3);
        builder.Property(a => a.TipoArquivo);
    }
}