namespace Ouvidoria.DTO;

public class AdministradorDTO : BaseUserDTO
{
    public AdministradorDTO(string nome, string email, string senha) : base(nome, email, senha)
    {
    }
}