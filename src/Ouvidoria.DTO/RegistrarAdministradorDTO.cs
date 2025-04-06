namespace Ouvidoria.DTO;

public record RegistrarAdministradorDTO
{
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public RegistrarAdministradorDTO() { }
    public RegistrarAdministradorDTO(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}