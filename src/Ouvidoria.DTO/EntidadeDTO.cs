using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public class EntidadeDTO
{
    public int Id { get; }
    public string Nome { get; } = string.Empty;
    public string Telefone { get; } = string.Empty;
    public string Cnpj { get; } = string.Empty;

    public EntidadeDTO(int id, string nome, string telefone, string cnpj)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }
    public EntidadeDTO(Entidade entidade)
    {
        Id = entidade.Id;
        Nome = entidade.Nome;
        Telefone = entidade.Telefone;
        Cnpj = entidade.Cnpj;
    }
}
