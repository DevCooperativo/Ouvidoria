using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record CidadaoDTO
{
    public int Id { get; }
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Cpf { get; } = string.Empty;
    public string Telefone { get; } = string.Empty;
    public string Endereco { get; } = string.Empty;
    public DateTime DataNascimento { get; }
    public CidadaoDTO(string nome, string email, string cpf, string telefone, string endereco, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
        DataNascimento = dataNascimento;
    }

    public CidadaoDTO(Cidadao cidadao)
    {
        Id = cidadao.Id;
        Nome = cidadao.Nome;
        Email = cidadao.Email;
        Cpf = cidadao.Cpf;
        Telefone = cidadao.Telefone;
        Endereco = cidadao.Endereco;
        DataNascimento = cidadao.DataNascimento;
    }
}