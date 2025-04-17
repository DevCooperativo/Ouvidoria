using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Usuario;

namespace Ouvidoria.Web.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUsuarioService _usuarioService;
    private readonly ICidadaoService _cidadaoService;
    private readonly IAdministradorService _administradorService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserController(ILogger<UserController> logger, IUsuarioService usuarioService, ICidadaoService cidadaoService, IAdministradorService administradorService, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        _usuarioService = usuarioService;
        _cidadaoService = cidadaoService;
        _administradorService = administradorService;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(loginViewModel);
        try
        {

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password ?? "", true, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Sua conta está bloqueada. Por favor tente novamente mais tarde.");
                }
                else
                {
                    ModelState.AddModelError("Login", "O e-mail ou a senha estão incorretos.");
                }
                return View(loginViewModel);
            }
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);
            if (User.IsInRole(ApplicationUser.TipoAdministrador))
                return RedirectToAction("Index", "Administrador");
            return RedirectToAction("Index", "Cidadao");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ModelState.AddModelError("", "Ocorreu um erro durante o login. Por favor tente novamente.");
            return View(loginViewModel);
        }
    }

    [HttpGet]
    public IActionResult RegistrarCidadao()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegistrarCidadao(RegistrarCidadaoViewModel cidadaoVM)
    {
        if (!ModelState.IsValid) return View(cidadaoVM);
        try
        {
            RegistrarCidadaoDTO cidadaoDTO = new(cidadaoVM.UserName, cidadaoVM.Email, cidadaoVM.Password, cidadaoVM.Cpf, cidadaoVM.Telefone, cidadaoVM.Endereco, cidadaoVM.DataNascimento);

            await _usuarioService.RegistrarCidadaoAsync(cidadaoDTO);
            await _cidadaoService.CreateAsync(new CidadaoDTO(cidadaoVM.UserName, cidadaoVM.Email, cidadaoVM.Cpf, cidadaoVM.Telefone, cidadaoVM.Endereco, cidadaoVM.DataNascimento));

            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(cidadaoVM);
        }
    }
    [HttpGet]
    public IActionResult RegistrarAdministrador()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegistrarAdministrador(RegistrarAdministradorViewModel administradorVM)
    {
        if (!ModelState.IsValid) return View(administradorVM);
        try
        {
            RegistrarAdministradorDTO registrarAdministradorDTO = new(administradorVM.UserName, administradorVM.Email, administradorVM.Password);

            await _usuarioService.RegistrarAdministradorAsync(registrarAdministradorDTO);
            await _administradorService.CreateAsync(new AdministradorDTO(administradorVM.UserName, administradorVM.Email));

            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(administradorVM);
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
