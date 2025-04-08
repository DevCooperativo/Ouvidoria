using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroFormViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo")]
    [StringLength(40, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Tipo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Título")]
    [StringLength(80, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Natureza")]
    public string Natureza { get; set; } = string.Empty;

    public SelectList NaturezaList { get; set; } = new SelectList(from TipoRegistroEnum f in Enum.GetValues(typeof(TipoRegistroEnum)) select new { ID = (int)f, Name = f.GetDisplayName() }, "ID", "Name");

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(400, ErrorMessage = "{0} deve ter até {1} caracteres")]
    [Display(Name="Descrição")]
    public string Descricao { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name="Arquivo")]

    public RegistroArquivoFormViewModel Arquivo { get; set; } = new();

    public RegistroFormViewModel() { }

}