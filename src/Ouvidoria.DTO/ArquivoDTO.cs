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
    public string GetMimeType()
    {
        return GetMimeType(TipoArquivo.ToLower());
    }
    public static string GetMimeType(string fileExtension)
    {
        return fileExtension.ToLower() switch
        {
            "png" => "image/png",
            "jpg" => "image/jpeg",
            "jpeg" => "image/jpeg",
            "jfif" => "image/jpeg",
            "webp" => "image/webp",
            "zip" => "application/zip",
            "7z" => "application/x-7z-compressed",
            "rar" => "application/vnd.rar",
            "mp4" => "video/mp4",
            "avi" => "video/x-msvideo",
            "ogg" => "video/ogg",
            "pdf" => "application/pdf",
            "docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            "doc" => "application/msword",
            "txt" => "text/plain",
            _ => "application/octet-stream", // padrão genérico
        };
    }
}
