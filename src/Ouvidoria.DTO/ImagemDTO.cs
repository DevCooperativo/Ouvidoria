namespace Ouvidoria.DTO;

public record ImagemDTO
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string NomeS3 { get; init; } = string.Empty;
    public string TipoArquivo { get; init; } = string.Empty;
    public ArquivoDTO? ArquivoDTO { get; set; }
    public int RegistroId { get; init; }

    public ImagemDTO() { }
    public ImagemDTO(string nome, string nomeS3, string tipoArquivo, int registroId) : base()
    {
        Nome = nome;
        NomeS3 = nomeS3;
        TipoArquivo = tipoArquivo;
        RegistroId = registroId;
    }
}
