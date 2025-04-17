using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Exceptions;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;
using Ouvidoria.Web.Helpers;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.ViewModels.Registro;

public class HistoricoRegistroFormViewModel
{
    public int Id { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public StatusEnum Status { get; set; }
    public SelectList StatusList { get; init; } = new SelectList(EnumHelper.RecuperarSelectListItemEnum<StatusEnum>().ToList(), "ID", "Name", "Pendente", StatusEnum.Pendente.ToString());
    // public SelectList StatusList { get; init; } = new SelectList(teste, "ID", "Name");
    public int RegistroId { get; set; }

    public HistoricoRegistroFormViewModel() { }
    public HistoricoRegistroFormViewModel(int registroId)
    {
        RegistroId = registroId;
    }



}