using Ouvidoria.Domain.Enums;

namespace Ouvidoria.DTO;

public record RegistroDTO
{
    public int Id { get; }
    public string Tipo { get; } = string.Empty;
    public string Descricao { get; } = string.Empty;
    public StatusEnum Status { get; }
    public CidadaoDTO? Autor { get; }
    public int AutorId { get; }
    public EntidadeDTO? Alvo { get; }
    public int? AlvoId { get; }
    public AdministradorDTO Administrador { get; } = default!;
    public int AdministradorId { get; }
    public IReadOnlyCollection<RegistroDTO> Historico { get; } = [];
    public IReadOnlyCollection<ArquivoDTO> Arquivos { get; } = [];


}
