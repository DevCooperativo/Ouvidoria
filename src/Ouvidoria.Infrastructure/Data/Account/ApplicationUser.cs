using Microsoft.AspNetCore.Identity;

namespace Ovidoria.Infrastructure.Data.Account;

public class ApplicationUser : IdentityUser
{
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; } = default!;
}