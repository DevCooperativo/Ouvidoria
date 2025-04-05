using Microsoft.AspNetCore.Identity;
using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;
public interface IUsuarioService
{
    Task<IdentityResult> RegistrarAdministradorAsync(AdministradorDTO administradorDTO);
    Task<IdentityResult> RegistrarCidadaoAsync(CidadaoDTO cidadaoDTO);
    Task<bool> ConfirmarEmailAsync(string userId, string token);
}