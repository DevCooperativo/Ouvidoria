using Ouvidoria.Domain.Exceptions;

namespace Ouvidoria.Domain.Models;

public record Arquivo
{
    private IReadOnlyCollection<string> fileType = ["png", "jpg", "jpeg", "pdf", "webp", "bmp"];

    public int Id { get; private set; }
    private string _name;
    public string Name
    {
        get => _name; private set
        {
            EntityException.When(value.Length > 100, "O nome do arquivo não pode passar de 100 caracteres");
            _name = value;
        }
    }
    public string NameS3 { get; private set; } = string.Empty;
    private string _fileType;
    public string FileType
    {
        get => _fileType; private set
        {
            EntityException.When(!fileType.Contains(value), "O tipo do arquivo deve ser de um tipo válido");
            _fileType=value;
        }
    }
    public int? RegistroId { get; private set; }

    protected Arquivo() { }

    public Arquivo(string name, string nameS3, string fileType, int registroId) : base()
    {
        Name = name;
        NameS3 = nameS3;
        FileType = fileType;
        RegistroId = registroId;
    }
}