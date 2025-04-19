using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Models;

namespace Ouvidoria.DTO;

public record RegistroDTO
{
    public int Id { get; init; }
    public string Titulo { get; init; } = string.Empty;
    public string Tipo { get; init; } = string.Empty;
    public TipoRegistroEnum TipoRegistro { get; init; }
    public string Descricao { get; init; } = string.Empty;
    public StatusEnum Status { get; init; }
    public CidadaoDTO? Autor { get; init; }
    public int? AutorId { get; init; }
    public EntidadeDTO? Alvo { get; init; }
    public int? AlvoId { get; init; }
    public AdministradorDTO? Administrador { get; init; } = default!;
    public int? AdministradorId { get; init; }
    public List<HistoricoRegistroDTO> Historicos { get; set; } = [];
    public ArquivoDTO? Arquivo { get; init; }

    public RegistroDTO() { }

    public RegistroDTO(int id, string titulo, string tipo, TipoRegistroEnum tipoRegistro, string descricao, StatusEnum status, CidadaoDTO? autor, int autorId, EntidadeDTO? alvo, int? alvoId, AdministradorDTO administrador, int administradorId)
    {
        Id = id;
        Titulo = titulo;
        Tipo = tipo;
        TipoRegistro = tipoRegistro;
        Descricao = descricao;
        Status = status;
        Autor = autor;
        AutorId = autorId;
        Alvo = alvo;
        AlvoId = alvoId;
        Administrador = administrador;
        AdministradorId = administradorId;
    }

    public RegistroDTO(Registro registro)
    {
        Id = registro.Id;
        Titulo = registro.Titulo;
        Tipo = registro.Tipo;
        TipoRegistro = registro.TipoRegistro;
        Descricao = registro.Descricao;
        Status = registro.Status;
        Arquivo = registro.Arquivos.Count > 0 ? registro.Arquivos.Select(a => new ArquivoDTO(a)).First() : null;
        Autor = registro.Autor is null ? null : new CidadaoDTO(registro.Autor);
        AutorId = registro.AutorId;
        Alvo = registro.Alvo is null ? null : new EntidadeDTO(registro.Alvo);
        AlvoId = registro.AlvoId;
        Administrador = registro.Administrador is null ? null : new AdministradorDTO(registro.Administrador);
        AdministradorId = registro.AdministradorId;
        Historicos = [.. registro.Historico.Select(x => new HistoricoRegistroDTO(x))];
    }

    public void AddHistorico(HistoricoRegistroDTO historicoRegistroDTO)
    {
        Historicos.Add(historicoRegistroDTO);
    }

    public static explicit operator RegistroDTO(Registro registro)
    {
        return new RegistroDTO(registro);
    }
}
