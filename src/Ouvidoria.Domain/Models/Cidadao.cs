using Ouvidoria.Domain.Enums;

namespace Ouvidoria.Domain.Models;
public class Cidadao : UsuarioBase
{

    public string Cpf { get; private set; } = string.Empty;
    public string Telefone { get; private set; } = string.Empty;
    public string Endereco { get; private set; } = string.Empty;
    public SexoEnum Sexo { get; private set; } = default!;
    public DateTime DataNascimento { get; private set; }

    protected Cidadao() { }

    public Cidadao(string nome, string email, string cpf, string telefone, string endereco, SexoEnum sexo, DateTime dataNascimento) : base(nome, email)
    {
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
        Sexo = sexo;
        DataNascimento = dataNascimento;
    }

    public void Update(string nome, string email, string cpf, string telefone, string endereco, SexoEnum sexo, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
        Sexo = sexo;
        DataNascimento = dataNascimento;
    }


}