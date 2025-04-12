using Ouvidoria.Domain.Enums;
using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroFormViewModel
{
    public int Id { get; set; }
    public TipoRegistroEnum Tipo { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public StatusEnum Status { get; set; }
    public CidadaoDTO? Autor { get; set; }
    public int AutorId { get; set; }
    public EntidadeDTO? Alvo { get; set; }
    public int? AlvoId { get; set; }
    public AdministradorDTO Administrador { get; set; } = default!;
    public int AdministradorId { get; set; }

    public RegistroFormViewModel() { }

    public RegistroFormViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.TipoRegistro;
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