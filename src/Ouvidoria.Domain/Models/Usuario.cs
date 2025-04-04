using Microsoft.AspNetCore.Identity;

namespace Ouvidoria.Domain.Models;
public class Usuario : IdentityUser
{
    private string _nome { get; set; } = string.Empty;
    private string _email { get; set; } = string.Empty;
    private string _senha { get; set; } = string.Empty;
    private int _permissao { get; set; }

    public Usuario(string nome, string email, string senha, int permissao)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Permissao = permissao;
    }
    public void Update(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public string Nome
    {
        get => _nome;
        private set
        {
            _nome = value;
        }
    }
    public string Email
    {
        get => _email;
        private set
        {
            _email = value;
        }
    }
    public string Senha
    {
        get => _senha;
        private set
        {
            _senha = value;
        }
    }
    public int Permissao
    {
        get => _permissao;
        private set
        {
            _permissao = value;
        }
    }
}