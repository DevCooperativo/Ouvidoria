using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.DTO;
using Ouvidoria.Web.ViewModels.Usuario;

namespace Ouvidoria.Web.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
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
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View(loginViewModel);
        try
        {

            return RedirectToAction("Index", "Cidadao");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(loginViewModel);
        }
    }

    [HttpGet]
    public IActionResult RegistrarCidadao()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegistrarCidadao(RegistrarCidadaoViewModel registrarCidadaoViewModel)
    {
        if (!ModelState.IsValid) return View(registrarCidadaoViewModel);
        try
        {

            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(registrarCidadaoViewModel);
        }
    }
    [HttpGet]
    public IActionResult RegistrarAdministrador()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegistrarAdministrador(RegistrarAdministradorViewModel registrarAdministradorViewModel)
    {
        if (!ModelState.IsValid) return View(registrarAdministradorViewModel);
        try
        {
            RegistrarAdministradorDTO registrarAdministradorDTO = new(registrarAdministradorViewModel.UserName, registrarAdministradorViewModel.UserName, registrarAdministradorViewModel.Email, registrarAdministradorViewModel.Password);


            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(registrarAdministradorViewModel);
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
