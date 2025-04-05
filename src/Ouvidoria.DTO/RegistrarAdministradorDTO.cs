namespace Ouvidoria.DTO;

public record RegistrarAdministradorDTO
{
    public string UserName { get; } = string.Empty;
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public RegistrarAdministradorDTO() { }
    public RegistrarAdministradorDTO(string userName, string nome, string email, string senha)
    {
        UserName = userName;
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}