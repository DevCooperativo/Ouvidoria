using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record AdministradorDTO
{
    public int Id { get; }
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public AdministradorDTO(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public AdministradorDTO(Administrador administrador)
    {
        Id = administrador.Id;
        Nome = administrador.Nome;
        Email = administrador.Email;
    }
}