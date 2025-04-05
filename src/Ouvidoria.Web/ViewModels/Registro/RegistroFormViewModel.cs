using Ouvidoria.Domain.Enums;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroFormViewModel
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

    public RegistroFormViewModel() { }

    public RegistroFormViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.Tipo;
        Descricao = registroDTO.Descricao;
        Status = registroDTO.Status;
        Autor = registroDTO.Autor;
        AutorId = registroDTO.AutorId;
        Alvo = registroDTO.Alvo;
        AlvoId = registroDTO.AlvoId;
        Administrador = registroDTO.Administrador;
        AdministradorId = registroDTO.AdministradorId;
    }
}