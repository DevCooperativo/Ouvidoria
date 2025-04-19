using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IObjectStorageService
{
    Task<string> UploadFileAsync(ArquivoDTO fileDTO);
    Task<byte[]> GetFileBytesAsync(string nomeS3);
    string GetFileUrlAsync(string fileName);
    Task DeleteFileAsync(string fileName);
}
