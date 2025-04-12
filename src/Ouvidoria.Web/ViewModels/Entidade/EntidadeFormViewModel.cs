using System.ComponentModel.DataAnnotations;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Entidade;

public class EntidadeFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é um campo obrigatório")]
    [StringLength(150, ErrorMessage = "{0} deve conter até no máximo {1} caracteres")]
    [Display(Name = "Npme")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} é um campo obrigatório")]
    [StringLength(11, ErrorMessage = "{0} deve conter até no máximo {1} caracteres")]
    [Display(Name = "Telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} é um campo obrigatório")]
    [StringLength(14, ErrorMessage = "{0} deve conter até no máximo {1} caracteres")]
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; } = string.Empty;

    public EntidadeFormViewModel() { }

    public EntidadeFormViewModel(EntidadeDTO entidadeDTO)
    {
        Id = entidadeDTO.Id;
        Nome = entidadeDTO.Nome;
        Telefone = entidadeDTO.Telefone;
        Cnpj = entidadeDTO.Cnpj;
    }
}
