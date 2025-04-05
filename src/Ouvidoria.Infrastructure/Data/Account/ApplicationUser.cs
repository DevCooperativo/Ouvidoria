using Microsoft.AspNetCore.Identity;

namespace Ouvidoria.Infrastructure.Data.Account;

public class ApplicationUser : IdentityUser
{
    public string TipoUsuario { get; set; } = null!;
    public string RealName { get; set; } = string.Empty;

    public const string TipoAdministrador = "administrador";
    public const string TipoCidadao = "cidadao";

    protected ApplicationUser() { }

    public ApplicationUser(string email, string nome, string tipoUsuario)
    {
        Email = email;
        UserName = email;
        RealName = nome;
        // AVISO: se não for ter confirmação de email, deixar essa propriedade como true:
        EmailConfirmed = true;
        TipoUsuario = tipoUsuario;
    }
}