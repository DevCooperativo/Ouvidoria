namespace Ouvidoria.DTO;

public record ArquivoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Extensao { get; set; } = string.Empty;
    public string StorageServiceName { get; set; } = string.Empty;
    public byte[] Bytes { get; set; } = Array.Empty<byte>();
}
