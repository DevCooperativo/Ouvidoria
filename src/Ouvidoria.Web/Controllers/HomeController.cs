using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Error;
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
        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        var errorMessageJson = TempData["ErrorMessage"]?.ToString();
        if (errorMessageJson is not null)
            ViewBag.ErrorMessage = JsonConvert.DeserializeObject<ErrorAlertViewModel>(errorMessageJson);
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
                TipoRegistro = registroFormViewModel.TipoRegistro,
                Descricao = registroFormViewModel.Descricao,
                Arquivo = registroFormViewModel.Arquivo.ConvertToImageDTO(),
            };
            await _registroService.CreateAsync(registroDTO, User);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = new ErrorAlertViewModel("registro", [ex.Message]);
            return View(registroFormViewModel);
        }
        TempData["SuccessMessage"] = "Sua denúncia foi enviada com sucesso.";
        return RedirectToAction("Index");
    }

}
