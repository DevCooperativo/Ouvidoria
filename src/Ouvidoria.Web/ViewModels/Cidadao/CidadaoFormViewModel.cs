using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Cidadao;

public class CidadaoFormViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }

    public CidadaoFormViewModel(CidadaoDTO cidadaoDTO)
    {
        Id = cidadaoDTO.Id;
        Nome = cidadaoDTO.Nome;
        Cpf = cidadaoDTO.Cpf;
        Telefone = cidadaoDTO.Telefone;
        Endereco = cidadaoDTO.Endereco;
        DataNascimento = cidadaoDTO.DataNascimento;
    }

}