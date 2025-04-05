using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Web.ViewModels.Usuario;

public class RegistrarAdministradorViewModel
{

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Nome de Usuário")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Compare("Password", ErrorMessage = "A senha e a confirmação de senha devem ser iguais")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Confirmar Senha")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    public RegistrarAdministradorViewModel() { }


}