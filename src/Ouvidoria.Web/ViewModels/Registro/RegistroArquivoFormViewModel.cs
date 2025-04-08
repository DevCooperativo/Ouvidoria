using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroArquivoFormViewModel
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public RegistroArquivoFormViewModel() { }

    public ArquivoDTO ConvertToArquivoDTO(int? materialId = null)
    {
        using MemoryStream itemMemoryStream = new MemoryStream();
        Image?.CopyTo(itemMemoryStream);

        ArquivoDTO imageDTO = new()
        {
            Id = Id,
            Nome = Image?.FileName ?? string.Empty,
            TipoArquivo = Image?.ContentType ?? string.Empty,
        };
        return imageDTO;
    }
}
