namespace Ouvidoria.DTO;

public record ArquivoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string NomeS3 { get; set; } = string.Empty;
    public string TipoArquivo { get; set; } = string.Empty;
    public byte[] Bytes { get; set; } = [];
}
