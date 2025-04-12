using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

public class AdministradorController : Controller
{
    private readonly IRegistroService _registroService;
    private readonly ILogger<AdministradorController> _logger;

    public AdministradorController(IRegistroService registroService, ILogger<AdministradorController> logger)
    {
        _registroService = registroService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        IEnumerable<RegistroViewModel> registroViewModels = _registroService.GetAll().Select(x => (RegistroViewModel)x);
        return View(registroViewModels);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
