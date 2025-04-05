namespace Ouvidoria.Domain.Models;
public class Administrador : UsuarioBase
{
    protected Administrador() { }
    public Administrador(string nome, string email) : base(nome, email) { }

    public void Update(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}