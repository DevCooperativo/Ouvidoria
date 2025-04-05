using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class HistoricoRegistroEntityConfiguration : IEntityTypeConfiguration<HistoricoRegistro>
{
    public void Configure(EntityTypeBuilder<HistoricoRegistro> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Status);
        builder.Property(h => h.Feedback).HasMaxLength(400);
        builder.Property(h => h.DataAtualizacao);
    }
}