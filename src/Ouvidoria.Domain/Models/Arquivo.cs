using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public record Arquivo
{
    private IReadOnlyCollection<string> tipoArquivo = ["png", "jpg", "jpeg", "pdf", "webp", "bmp"];

    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string NomeS3 { get; init; } = string.Empty;
    public string TipoArquivo { get; init; } = string.Empty;
    public int? RegistroId { get; init; }
    public virtual Registro? Registro { get; init; }

    protected Arquivo() { }

    public Arquivo(string nome, string nomeS3, string tipoArquivo, int? registroId = null) : base()
    {
        EntityException.When(nome.Length > 100, "O nome do arquivo não pode passar de 100 caracteres");
        Nome = nome;

        NomeS3 = nomeS3;

        EntityException.When(!tipoArquivo.Contains(tipoArquivo), "O tipo do arquivo deve ser de um tipo válido");
        TipoArquivo = tipoArquivo;

        if (registroId is not null)
            RegistroId = registroId;
    }

}