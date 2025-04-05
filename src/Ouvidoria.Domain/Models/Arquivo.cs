using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public record Arquivo
{
    private IReadOnlyCollection<string> tipoArquivo = ["png", "jpg", "jpeg", "pdf", "webp", "bmp"];

    public int Id { get; }
    private string _nome;
    public string Nome { get; }
    public string NomeS3 { get; } = string.Empty;
    public string TipoArquivo { get; }
    public int? RegistroId { get; }

    protected Arquivo() { }

    public Arquivo(string nome, string nomeS3, string tipoArquivo, int registroId) : base()
    {
        EntityException.When(nome.Length > 100, "O nome do arquivo não pode passar de 100 caracteres");
        Nome = nome;

        NomeS3 = nomeS3;

        EntityException.When(!tipoArquivo.Contains(tipoArquivo), "O tipo do arquivo deve ser de um tipo válido");
        TipoArquivo = tipoArquivo;

        RegistroId = registroId;
    }
}