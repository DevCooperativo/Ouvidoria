using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record RegistroDTO
{
    public int Id { get; }
    public TipoRegistroEnum TipoRegistro { get; }
    public string Descricao { get; } = string.Empty;
    public StatusEnum Status { get; }
    public CidadaoDTO? Autor { get; }
    public int AutorId { get; }
    public EntidadeDTO? Alvo { get; }
    public int? AlvoId { get; }
    public AdministradorDTO Administrador { get; } = default!;
    public int AdministradorId { get; }
    public List<HistoricoRegistroDTO> Historico { get; } = [];
    public List<ArquivoDTO> Arquivos { get; } = [];

    public RegistroDTO(Registro registro)
    {
        Id = registro.Id;
        TipoRegistro = registro.TipoRegistro;
        Descricao = registro.Descricao;
        Status = registro.Status;
        Autor = registro.Autor is null ? null : new CidadaoDTO(registro.Autor);
        AutorId = registro.AutorId;
        Alvo = registro.Alvo is null ? null : new EntidadeDTO(registro.Alvo);
        AlvoId = registro.AlvoId;
        Administrador = new AdministradorDTO(registro.Administrador);
        AdministradorId = registro.AdministradorId;
        Historico = [.. registro.Historico.Select(h => new HistoricoRegistroDTO(h))];
        Arquivos = [.. registro.Arquivos.Select(a => new ArquivoDTO(a))];
    }
}
