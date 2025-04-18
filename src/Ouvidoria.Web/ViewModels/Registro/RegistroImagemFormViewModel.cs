using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroImagemFormViewModel
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public RegistroImagemFormViewModel() { }

    public ArquivoDTO ConvertToImageDTO(int? registroId = null)
    {
        using MemoryStream itemMemoryStream = new MemoryStream();
        Image?.CopyTo(itemMemoryStream);

        ArquivoDTO imagemDTO = new()
        {
            Id = Id,
            Nome = Image?.FileName ?? string.Empty,
            TipoArquivo = Image?.ContentType.Split("/")[1] ?? string.Empty,
            Bytes = itemMemoryStream.ToArray()
        };
        return imagemDTO;
    }
}
