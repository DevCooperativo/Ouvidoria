using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.Domain.Extensions;
using Ouvidoria.DTO;
using Ouvidoria.Web.ViewModels.Administrador;
using Ouvidoria.Web.ViewModels.Cidadao;

namespace Ouvidoria.Web.ViewModels.Registro;

public class RegistroViewModel
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public CidadaoFormViewModel? Autor { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool TemArquivo { get; set; } = false;
    public string TipoRegistro { get; set; }
    public SelectList TipoRegistroList { get; set; } = new SelectList(from TipoRegistroEnum f in Enum.GetValues(typeof(TipoRegistroEnum)) select new { ID = (int)f, Name = f.GetDisplayName() }, "ID", "Name");
    public string Descricao { get; set; } = string.Empty;
    public AdministradorViewModel? Responsavel { get; set; }
    public RegistroImagemFormViewModel Arquivo { get; set; } = new();
    public List<HistoricoRegistroViewModel> HistoricosAntigos { get; set; } = [];

    public RegistroViewModel(RegistroDTO registroDTO)
    {
        Id = registroDTO.Id;
        Tipo = registroDTO.Tipo;
        DataCriacao = registroDTO.DataCriacao;
        DataAtualizacao = registroDTO.DataAtualizacao;
        if (registroDTO.Autor is not null)
        {
            Autor = new CidadaoFormViewModel(registroDTO.Autor);
        }
        if(registroDTO.Administrador is not null){
            Responsavel= new AdministradorViewModel(registroDTO.Administrador);
        }
        TemArquivo = registroDTO.Arquivo != null;
        Status = registroDTO.Status.GetDisplayName();
        Titulo = registroDTO.Titulo;
        TipoRegistro = registroDTO.TipoRegistro.GetDisplayName();
        Descricao = registroDTO.Descricao;
        HistoricosAntigos = [.. registroDTO.Historicos.Select(x => new HistoricoRegistroViewModel(x))];
    }

    public static explicit operator RegistroViewModel(RegistroDTO registroDTO)
    {
        return new RegistroViewModel(registroDTO);
    }
}