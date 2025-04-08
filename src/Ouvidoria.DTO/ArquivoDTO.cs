namespace Ouvidoria.DTO;

public record ArquivoDTO
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string NomeS3 { get; init; } = string.Empty;
    public string TipoArquivo { get; init; } = string.Empty;
    public int RegistroId { get; init; }

    public ArquivoDTO() { }
    public ArquivoDTO(string nome, string nomeS3, string tipoArquivo, int registroId) : base()
    {
        Nome = nome;
        NomeS3 = nomeS3;
        TipoArquivo = tipoArquivo;
        RegistroId = registroId;
    }
}
