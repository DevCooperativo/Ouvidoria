using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;

public class UsuarioService : IUsuarioService
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UsuarioService(
        UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegistrarAdministradorAsync(RegistrarAdministradorDTO administradorDTO)
    {
        IdentityResult result = await CadastrarUsuarioAsync(administradorDTO.Nome, administradorDTO.Email, administradorDTO.Senha, ApplicationUser.TipoAdministrador);

        // string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // string confirmationLink = _urlGenerator.GetEmailConfirmationLink(user.Id, token, "https");
        // await _emailService.SendEmailAsync("Confirme seu e-mail - Natural Rocha", string.Format(EmailBody.ConfirmationEmailBody, confirmationLink, _urlGenerator.GetContentLink()), user.Email);

        return result;
    }

    public async Task<IdentityResult> RegistrarCidadaoAsync(RegistrarCidadaoDTO cidadaoDTO)
    {
        IdentityResult result = await CadastrarUsuarioAsync(cidadaoDTO.Nome, cidadaoDTO.Email, cidadaoDTO.Senha, ApplicationUser.TipoCidadao);


        // string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // string confirmationLink = _urlGenerator.GetEmailConfirmationLink(user.Id, token, "https");
        // await _emailService.SendEmailAsync("Confirme seu e-mail - Natural Rocha", string.Format(EmailBody.ConfirmationEmailBody, confirmationLink, _urlGenerator.GetContentLink()), user.Email);

        return result;
    }

    public async Task<bool> ConfirmarEmailAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return result.Succeeded;
    }

    private async Task<IdentityResult> CadastrarUsuarioAsync(string nome, string email, string senha, string tipoUsuario)
    {
        ApplicationUser user = new(email, nome, tipoUsuario);

        var claimName = new Claim("RealName", user.UserName ?? "");

        IdentityResult result = await _userManager.CreateAsync(user, senha);

        if (!result.Succeeded)
        {
            await _userManager.AddClaimAsync(user, claimName);
            return result;
        }

        await _userManager.AddToRoleAsync(user, tipoUsuario);

        return result;
    }

}