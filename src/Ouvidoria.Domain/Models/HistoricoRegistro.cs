using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public record HistoricoRegistro
{
    public int Id { get; private set; }
    public StatusEnum Status { get; private set; }
    private string _feedback = string.Empty;
    public string Feedback
    {
        get => _feedback; private set
        {
            EntityException.When(value.Length > 400, "O tamanho máximo do feedback é de 400 caracteres");
            EntityException.When(string.IsNullOrWhiteSpace(value), "O feedback é obrigatório");
            _feedback = value;
        }
    }
    public DateTime DataAtualizacao { get; private set; }
    public int RegistroId { get; private set; }
    public virtual Registro Registro { get; private set; }

    protected HistoricoRegistro() { }


    public HistoricoRegistro(StatusEnum status, string feedback, int registroId)
    {
        Status = status;
        Feedback = feedback;
        RegistroId = registroId;
        DataAtualizacao = DateTime.Now;
    }

}
