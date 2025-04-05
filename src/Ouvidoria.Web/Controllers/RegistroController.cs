using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

[Route("[controller]")]
public class RegistroController : Controller
{
    private readonly ILogger<RegistroController> _logger;

    public RegistroController(ILogger<RegistroController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CriarRegsitro()
    {
        return View("Criar");
    }

    [HttpPost]
    public async Task<IActionResult> CriarRegistro(RegistroFormViewModel registroFormViewModel)
    {
        if(!ModelState.IsValid) return View(registroFormViewModel);
        try
        {

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return View(registroFormViewModel);
        }
    }
}
