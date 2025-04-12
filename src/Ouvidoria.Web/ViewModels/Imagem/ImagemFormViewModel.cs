using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Imagem;
public class ImageFormViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string NomeS3 { get; set; } = string.Empty;
    public string TipoArquivo { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public ImageFormViewModel() { }

    public ImageFormViewModel(ImagemDTO imageDTO)
    {
        Id = imageDTO.Id;
        Nome = imageDTO.Nome;
        NomeS3 = imageDTO.NomeS3;
        TipoArquivo = imageDTO.TipoArquivo;
    }
}