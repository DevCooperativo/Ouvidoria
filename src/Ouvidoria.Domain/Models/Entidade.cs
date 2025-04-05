using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public class Entidade : EntidadeBase
{
    private string _nome = string.Empty;
    public string Nome
    {
        get => _nome; private set
        {
            EntityException.When(value.Length > 150, "O nome deve ter, no máximo, 150 caracteres");
            _nome = value;
        }
    }
    private string _telefone = string.Empty;
    public string Telefone
    {
        get => _telefone; private set
        {
            EntityException.When(value.Length > 11, "O telefone deve ter, no máximo, 11 caracteres");
            EntityException.When(string.IsNullOrWhiteSpace(value), "O nome é obrigatório");
            _telefone = value;
        }
    }
    private string _cnpj = string.Empty;
    public string Cnpj
    {
        get => _cnpj; private set
        {
            EntityException.When(value.Length > 14, "Um CNPJ válido deve ter 14 caracteres");
            EntityException.When(string.IsNullOrWhiteSpace(value), "O CNPJ é obrigatório");
            _cnpj = value;
        }
    }
    protected Entidade() { }


    public Entidade(string nome, string telefone, string cnpj) : base()
    {
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }
}