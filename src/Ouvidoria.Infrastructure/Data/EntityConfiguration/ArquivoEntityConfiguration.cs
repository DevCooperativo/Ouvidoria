using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class ArquivoEntityConfiguration : IEntityTypeConfiguration<Arquivo>
{
    public void Configure(EntityTypeBuilder<Arquivo> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
        .HasMaxLength(100);
        builder.Property(a => a.NameS3);
        builder.Property(a => a.FileType);
    }
}