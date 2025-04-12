using Microsoft.AspNetCore.Mvc;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

public class RegistroController : Controller
{
    private readonly IRegistroService _registroService;
    private readonly ILogger<RegistroController> _logger;

    public RegistroController(
        IRegistroService registroService,
        ILogger<RegistroController> logger)
    {
        _registroService = registroService;
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

    public async Task<IActionResult> Detalhes(int id)
    {
        RegistroFormViewModel rm = new(await _registroService.GetDTOByIdAsync(id));
        return View(rm);
    }

    [HttpPost]
    public async Task<IActionResult> CriarRegistro(RegistroFormViewModel registroFormViewModel)
    {
        if (!ModelState.IsValid) return View(registroFormViewModel);
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
