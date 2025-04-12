using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroViewModel
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public TipoRegistroEnum TipoRegistro { get; set; }
    public SelectList TipoRegistroList { get; set; } = new SelectList(from TipoRegistroEnum f in Enum.GetValues(typeof(TipoRegistroEnum)) select new { ID = (int)f, Name = f.GetDisplayName() }, "ID", "Name");
    public string Descricao { get; set; } = string.Empty;

    public RegistroImagemFormViewModel Arquivo { get; set; } = new();

    public RegistroViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.Tipo;
        Titulo = registroDTO.Titulo;
        TipoRegistro = registroDTO.TipoRegistro;
        Descricao = registroDTO.Descricao;
    }

    public static explicit operator RegistroViewModel(RegistroDTO registroDTO)
    {
        return new RegistroViewModel(registroDTO);
    }
}