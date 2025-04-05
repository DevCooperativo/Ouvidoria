namespace Ouvidoria.DTO;

public record RegistrarCidadaoDTO
{
    public string Nome { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public string Senha { get; set; }
    public string Cpf { get; } = string.Empty;
    public string Telefone { get; } = string.Empty;
    public string Endereco { get; } = string.Empty;
    public DateTime DataNascimento { get; }
    public RegistrarCidadaoDTO(string nome, string email, string senha, string cpf, string telefone, string endereco, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Cpf = cpf;
        Telefone = telefone;
        Endereco = endereco;
        DataNascimento = dataNascimento;
    }
}