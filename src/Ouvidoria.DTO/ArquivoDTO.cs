namespace Ouvidoria.DTO;

public record ArquivoDTO
{
    public int Id { get; }
    public string Nome { get; }
    public string NomeS3 { get; }
    public string TipoArquivo { get; }
    public int RegistroId { get; }

    public ArquivoDTO(string nome, string nomeS3, string tipoArquivo, int registroId) : base()
    {
        Nome = nome;
        NomeS3 = nomeS3;
        TipoArquivo = tipoArquivo;
        RegistroId = registroId;
    }
}
