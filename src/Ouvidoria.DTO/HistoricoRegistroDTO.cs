using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record HistoricoRegistroDTO<T> where T : RegistroBase
{
    public int Id { get; }
    public StatusEnum Status { get; }
    public string Feedback { get; } = string.Empty;
    public DateTime DataAtualizacao { get; }
    public T RegistroBase { get; }
    public int RegistroId { get; }

    public HistoricoRegistroDTO(int id, StatusEnum status, string feedback, DateTime dataAtualizacao, T registroBase)
    {
        Id = id;
        Status = status;
        DataAtualizacao = dataAtualizacao;
        RegistroBase = registroBase;
        RegistroId = registroBase.Id;
    }

}
