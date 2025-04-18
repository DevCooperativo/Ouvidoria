using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Web.ViewModels.Usuario;

public class EditarPerfilViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Senha antiga")]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter pelo menos {2} e no maximo {1} caracteres.")]
    [Display(Name = "Confirmar Senha")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;

    public EditarPerfilViewModel() { }
}
