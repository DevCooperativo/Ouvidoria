using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Arquivo;

public class ArquivoFormViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string NomeS3 { get; set; } = string.Empty;
    public string TipoArquivo { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public ArquivoFormViewModel() { }

    public ArquivoFormViewModel(ArquivoDTO arquivoDTO)
    {
        Id = arquivoDTO.Id;
        Nome = arquivoDTO.Nome;
        NomeS3 = arquivoDTO.NomeS3;
        TipoArquivo = arquivoDTO.TipoArquivo;
    }
}