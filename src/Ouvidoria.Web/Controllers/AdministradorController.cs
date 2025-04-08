using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

[Route("[controller]")]
public class AdministradorController : Controller
{
    private readonly IRegistroService _registroService;
    private readonly ILogger<AdministradorController> _logger;

    public AdministradorController(IRegistroService registroService, ILogger<AdministradorController> logger)
    {
        _registroService = registroService;
        _logger = logger;
    }

    public async IActionResult Index()
    {
        IEnumerable<RegistroViewModel> registroViewModels = _registroService.GetAllAsync().Select(x => (RegistroViewModel)x);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
