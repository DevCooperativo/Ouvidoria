using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ouvidoria.Domain.Models;

public class NotificacaoEntityConfiguration : IEntityTypeConfiguration<Notificacao>
{
    public void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        builder.Property(n => n.Titulo).HasMaxLength(100);
        builder.Property(n => n.Mensagem).HasMaxLength(400);
        builder.HasOne(n => n.Cidadao).WithMany().HasForeignKey(c => c.CidadaoId);
        builder.HasOne(n => n.Registro).WithMany().HasForeignKey(r => r.RegistroId);

    }
}
