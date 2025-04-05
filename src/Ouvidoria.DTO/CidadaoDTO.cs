namespace Ouvidoria.DTO;

public class CidadaoDTO : BaseUserDTO
{
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public CidadaoDTO(string nome, string email, string senha, string cpf, string telefone, string endereco, DateTime dataNascimento) : base(nome, email, senha)
    {

    }
}