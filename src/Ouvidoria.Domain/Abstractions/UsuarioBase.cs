
namespace Ouvidoria.Domain.Abstractions;
public abstract class UsuarioBase : EntidadeBase
{
    public string Nome { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;

    protected UsuarioBase() { }

    protected UsuarioBase(string nome, string email) : base()
    {
        Nome = nome;
        Email = email;
    }


}