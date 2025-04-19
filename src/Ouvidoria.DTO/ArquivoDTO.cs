using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record ArquivoDTO
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string NomeS3 { get; init; } = string.Empty;
    public string TipoArquivo { get; init; } = string.Empty;
    public byte[] Bytes { get; init; } = [];

    public ArquivoDTO() { }
    public ArquivoDTO(Arquivo arquivo)
    {
        Id = arquivo.Id;
        Nome = arquivo.Nome;
        NomeS3 = arquivo.NomeS3;
        TipoArquivo = arquivo.TipoArquivo;
    }
}
