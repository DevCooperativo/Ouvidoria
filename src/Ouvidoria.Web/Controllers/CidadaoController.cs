using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ouvidoria.Web.Controllers;


public class CidadaoController : Controller
{
    private readonly ILogger<CidadaoController> _logger;

    public CidadaoController(ILogger<CidadaoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
