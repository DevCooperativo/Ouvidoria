using Ouvidoria.DTO;

namespace Ouvidoria.Web.ViewModels.Administrador;

public class AdministradorViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public AdministradorViewModel(AdministradorDTO administradorDTO)
    {
        Id = administradorDTO.Id;
        Nome = administradorDTO.Nome;
    }
}