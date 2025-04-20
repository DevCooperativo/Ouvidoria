using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.Web.Helpers;

namespace Ouvidoria.Web.ViewModels.Usuario;

public class RegistrarCidadaoViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(256, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no máximo {1} caracteres")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(128, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no máximo {1} caracteres")]
    [Display(Name = "Nome de Usuário")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "O campo deve ser um e-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Compare("Password", ErrorMessage = "A senha e a confirmação de senha devem ser iguais.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Confirmar Senha")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no máximo {1} caracteres")]
    public string Telefone { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O cpf informado é inválido")]
    public string Cpf { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Endereco { get; set; } = string.Empty;


    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.DateTime)]
    public DateTime DataNascimento { get; set; }

    public RegistrarCidadaoViewModel() { }


}