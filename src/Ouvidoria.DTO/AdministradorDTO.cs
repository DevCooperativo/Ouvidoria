namespace Ouvidoria.DTO;

public record AdministradorDTO
{
    public int Id { get; }
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public AdministradorDTO(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
}