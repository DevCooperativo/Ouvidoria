using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ouvidoria.Domain.Enums;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

public class HomeController : Controller
{

    private IRegistroService _registroService;

    public HomeController(IRegistroService registroService)
    {
        _registroService = registroService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Registro()
    {
        return View(new RegistroFormViewModel());
    }
    [HttpPost]
    public async Task<IActionResult> Registro(RegistroFormViewModel registroFormViewModel)
    {
        if (!ModelState.IsValid) return View(registroFormViewModel);
        try
        {
            RegistroDTO registroDTO = new()
            {
                Titulo = registroFormViewModel.Titulo,
                Tipo = registroFormViewModel.Tipo,
                TipoRegistro = (TipoRegistroEnum)Enum.Parse(typeof(TipoRegistroEnum), registroFormViewModel.Natureza),
                Descricao = registroFormViewModel.Descricao,
                Arquivo = registroFormViewModel.Arquivo.ConvertToArquivoDTO(),
            };
            await _registroService.CreateAsync(registroDTO, User);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return View(registroFormViewModel);
        }
    }

}
