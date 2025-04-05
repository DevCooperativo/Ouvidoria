// using Ouvidoria.Domain.Enums;

// namespace Ouvidoria.DTO;

// public record SolicitacaoDTO
// {
//     public int Id { get; set; }
//     public string Tipo { get; private set; } = string.Empty;
//     public string Descricao { get; private set; } = string.Empty;
//     public StatusEnum Status { get; private set; }
//     public CidadaoDTO? Autor { get; private set; }
//     public int AutorId { get; private set; }
//     public EntidadeDTO? Alvo { get; private set; }
//     public int? AlvoId { get; private set; }
//     public AdministradorDTO Administrador { get; private set; } = default!;
//     public int AdministradorId { get; private set; }
//     private List<HistoricoRegistroDTO> _historico = [];
//     public IReadOnlyCollection<HistoricoRegistroDTO> Historico => _historico.AsReadOnly();
//     private List<ArquivoDTO> _arquivos = [];
//     public IReadOnlyCollection<ArquivoDTO> Arquivos => _arquivos.AsReadOnly();


// }
