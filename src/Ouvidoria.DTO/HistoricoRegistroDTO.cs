using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record HistoricoRegistroDTO
{
    public int Id { get; }
    public StatusEnum Status { get; }
    public string Feedback { get; } = string.Empty;
    public DateTime DataAtualizacao { get; }
    public int RegistroId { get; }

    public HistoricoRegistroDTO(StatusEnum status, string feedback)
    {
        Status = status;
        Feedback=feedback;
    }

    public HistoricoRegistroDTO(HistoricoRegistro historicoRegistro)
    {
        Id = historicoRegistro.Id;
        Status = historicoRegistro.Status;
        Feedback=historicoRegistro.Feedback;
        DataAtualizacao = historicoRegistro.DataAtualizacao;
        RegistroId = historicoRegistro.Registro.Id;
    }

}
