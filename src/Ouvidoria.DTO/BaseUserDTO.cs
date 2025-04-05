namespace Ouvidoria.DTO;

public class BaseUserDTO
{
    public string nome { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string senha { get; set; } = string.Empty;

    public BaseUserDTO(string nome, string email, string senha)
    {
        this.nome = nome;
        this.email = email;
        this.senha = senha;
    }
}