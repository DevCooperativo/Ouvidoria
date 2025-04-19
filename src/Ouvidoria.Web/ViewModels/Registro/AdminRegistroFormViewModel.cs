using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;
using Ouvidoria.Web.Helpers;
using Ouvidoria.Web.ViewModels.Cidadao;
using Ouvidoria.Web.ViewModels.Entidade;

namespace Ouvidoria.Web.ViewModels.Registro;

public class AdminRegistroFormViewModel
{
    public int? Id { get; init; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo")]
    [StringLength(40, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Tipo { get; init; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Título")]
    [StringLength(80, ErrorMessage = "{0} deve ter até {1} caracteres")]
    public string Titulo { get; init; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Status")]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo do Registro")]
    public TipoRegistroEnum TipoRegistro { get; init; }

    public List<SelectListItem> TipoRegistroList { get; init; } = EnumHelper.RecuperarSelectListItemEnum<TipoRegistroEnum>().ToList();

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(400, ErrorMessage = "{0} deve ter até {1} caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; init; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Arquivo")]
    public RegistroImagemFormViewModel Arquivo { get; init; } = new();
    public bool TemArquivo { get; set; } = false;

    public CidadaoFormViewModel? Autor { get; init; }
    public int? AutorId { get; init; }

    public EntidadeFormViewModel? Alvo { get; set; }
    public int? AlvoId { get; set; }
    public string DownloadAnexoUrl { get; set; } = string.Empty;
    public HistoricoRegistroFormViewModel NovoRegistro { get; set; }
    public List<HistoricoRegistroViewModel> HistoricosAntigos { get; set; } = [];


    public AdminRegistroFormViewModel()
    {
        NovoRegistro = new();
    }

    public AdminRegistroFormViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.Tipo;
        Titulo = registroDTO.Titulo;
        Status = registroDTO.Status.GetDisplayName();
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
        TemArquivo = registroDTO.Arquivo != null;
        NovoRegistro = new HistoricoRegistroFormViewModel(registroDTO.Id);
        HistoricosAntigos = [.. registroDTO.Historicos.Select(x => new HistoricoRegistroViewModel(x))];


    }

}