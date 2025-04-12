using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroImagemFormViewModel
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public RegistroImagemFormViewModel() { }

    public ImagemDTO ConvertToImageDTO(int? registroId = null)
    {
        using MemoryStream itemMemoryStream = new MemoryStream();
        Image?.CopyTo(itemMemoryStream);

        ImagemDTO imagemDTO = new()
        {
            Id = Id,
            Nome = Image?.FileName ?? string.Empty,
            TipoArquivo = Image?.ContentType ?? string.Empty,
            ArquivoDTO = new ArquivoDTO
            {
                Nome = Image?.FileName ?? string.Empty,
                Extensao = Image?.ContentType.Split("/")[1] ?? string.Empty,
                Bytes = itemMemoryStream.ToArray()
            },
        };
        return imagemDTO;
    }
}
