using System.Globalization;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class HistoricoRegistroViewModel
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public DateTime DataAtualizacao { get; private set; }
    public string DataAtualizacaoExibicao { get; private set; }
    public int RegistroId { get; private set; }

    public HistoricoRegistroViewModel() { }

    public HistoricoRegistroViewModel(HistoricoRegistroDTO historicoRegistroDTO)
    {
        Id = historicoRegistroDTO.Id;
        Status = historicoRegistroDTO.Status.GetDisplayName();
        Feedback = historicoRegistroDTO.Feedback;
        DataAtualizacao = historicoRegistroDTO.DataAtualizacao;
        DataAtualizacaoExibicao= DataAtualizacao.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);;
        RegistroId = historicoRegistroDTO.RegistroId;
    }
}
