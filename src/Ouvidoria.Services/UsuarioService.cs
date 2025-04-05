using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;

public class UserService : IUsuarioService
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UserService(
        UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegistrarAdministradorAsync(AdministradorDTO administradorDTO)
    {
        ApplicationUser user = new()
        {
            Email = administradorDTO.Email,
            UserName = administradorDTO.Nome,
        };

        var claimName = new Claim("RealName", user.UserName);

        IdentityResult result = await _userManager.CreateAsync(user, administradorDTO.Senha);

        if (!result.Succeeded)
        {
            await _userManager.AddClaimAsync(user, claimName);
            return result;
        }

        // string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // string confirmationLink = _urlGenerator.GetEmailConfirmationLink(user.Id, token, "https");
        // await _emailService.SendEmailAsync("Confirme seu e-mail - Natural Rocha", string.Format(EmailBody.ConfirmationEmailBody, confirmationLink, _urlGenerator.GetContentLink()), user.Email);

        return result;
    }

    public async Task<IdentityResult> RegistrarCidadaoAsync(CidadaoDTO cidadaoDTO)
    {
        ApplicationUser user = new()
        {
            Email = cidadaoDTO.Email,
            UserName = cidadaoDTO.Nome,
            Cpf = cidadaoDTO.Cpf,
            Telefone = cidadaoDTO.Telefone,
            Endereco = cidadaoDTO.Endereco,
            DataNascimento = cidadaoDTO.DataNascimento
        };

        var claimName = new Claim("RealName", user.UserName);

        IdentityResult result = await _userManager.CreateAsync(user, cidadaoDTO.Senha);

        if (!result.Succeeded)
        {
            await _userManager.AddClaimAsync(user, claimName);
            return result;
        }

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
   
}