using Microsoft.AspNetCore.Identity;
using Ouvidoria.DTO;

namespace Ouvidoria.Interfaces;
public interface IUsuarioService
{
    Task<IdentityResult> RegistrarAdministradorAsync(RegistrarAdministradorDTO administradorDTO);
    Task<IdentityResult> RegistrarCidadaoAsync(RegistrarCidadaoDTO cidadaoDTO);
    Task<bool> ConfirmarEmailAsync(string userId, string token);
}