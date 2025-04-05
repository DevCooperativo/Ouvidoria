namespace Ouvidoria.DTO;

public class DenunciaDTO
{
    public string Tipo { get; private set; } = string.Empty;
    public string Natureza { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public CidadaoDTO? Autor { get; private set; }
    public int? AutorId { get; private set; }
    public EntidadeDTO? Alvo { get; private set; }
    public AdministradorDTO Administrador { get; private set; } = default!;

}
