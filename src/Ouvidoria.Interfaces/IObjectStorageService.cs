using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;

public interface IObjectStorageService
{
    Task<string> UploadFileAsync(ArquivoDTO fileDTO, bool isThumbnail = false);
    string GetFileUrlAsync(string fileName);
    Task DeleteFileAsync(string fileName);
}
