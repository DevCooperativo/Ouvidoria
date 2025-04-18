using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;
using Ouvidoria.Web.ViewModels.Cidadao;
using Ouvidoria.Web.ViewModels.Entidade;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroFormViewModel
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo")]
    [StringLength(40, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Tipo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Título")]
    [StringLength(80, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Status")]
    public StatusEnum Status { get; set; }

    public SelectList StatusList { get; set; } = new SelectList(from StatusEnum f in Enum.GetValues(typeof(StatusEnum)) select new { ID = (int)f, Name = f.GetDisplayName() }, "ID", "Name");

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo do Registro")]
    public TipoRegistroEnum TipoRegistro { get; set; }

    public SelectList TipoRegistroList { get; set; } = new SelectList(from TipoRegistroEnum f in Enum.GetValues(typeof(TipoRegistroEnum)) select new { ID = (int)f, Name = f.GetDisplayName() }, "ID", "Name");

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(400, ErrorMessage = "{0} deve ter até {1} caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Arquivo")]
    public RegistroImagemFormViewModel Arquivo { get; set; } = new();

    public CidadaoFormViewModel? Autor { get; set; }
    public int? AutorId { get; set; }

    public EntidadeFormViewModel? Alvo { get; set; }
    public int? AlvoId { get; set; }

    public HistoricoRegistroFormViewModel? NovoRegistro { get; set; }
    public List<HistoricoRegistroViewModel> HistoricosAntigos { get; set; } = [];


    public RegistroFormViewModel() { }

    public RegistroFormViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.Tipo;
        Titulo = registroDTO.Titulo;
        Status = registroDTO.Status;
        TipoRegistro = registroDTO.TipoRegistro;
        Descricao = registroDTO.Descricao;
        Arquivo = new RegistroImagemFormViewModel();
        if (registroDTO.Alvo is not null)
        {
            Alvo = new EntidadeFormViewModel(registroDTO.Alvo);
            AlvoId = registroDTO.Alvo.Id;
        }
        if (registroDTO.Autor is not null)
        {
            Autor = new CidadaoFormViewModel(registroDTO.Autor);
            AutorId = registroDTO.Autor.Id;
        }
        HistoricosAntigos = [.. registroDTO.Historicos.Select(x => new HistoricoRegistroViewModel(x))];

    }

}