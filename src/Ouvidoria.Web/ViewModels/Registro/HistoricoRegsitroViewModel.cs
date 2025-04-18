using Ouvidoria.Domain.Enums;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class HistoricoRegistroViewModel
{
    public int Id { get; set; }
    public StatusEnum Status { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public DateTime DataAtualizacao { get; private set; }
    public int RegistroId { get; private set; }

    public HistoricoRegistroViewModel() { }

    public HistoricoRegistroViewModel(HistoricoRegistroDTO historicoRegistroDTO)
    {
        Id = historicoRegistroDTO.Id;
        Status = historicoRegistroDTO.Status;
        Feedback = historicoRegistroDTO.Feedback;
        DataAtualizacao = historicoRegistroDTO.DataAtualizacao;
        RegistroId = historicoRegistroDTO.RegistroId;
    }
}
