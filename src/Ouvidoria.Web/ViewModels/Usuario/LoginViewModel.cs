using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Web.ViewModels.Usuario;

public class LoginViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "O campo {0} deve ter ao menos {1} caracteres")]
    public string Password { get; set; } = string.Empty;
    public LoginViewModel() { }
}