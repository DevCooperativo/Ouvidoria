using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
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
        if (User.IsInRole(ApplicationUser.TipoAdministrador))
        {
            return RedirectToAction("Registros", "Administrador");
        }
        if (User.IsInRole(ApplicationUser.TipoCidadao))
        {
            return RedirectToAction("Registros", "Cidadao");
        }
        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        var errorMessageJson = TempData["ErrorMessage"]?.ToString();
        if (errorMessageJson is not null)
            ViewBag.ErrorMessage = JsonConvert.DeserializeObject<ErrorAlertViewModel>(errorMessageJson);

        return View();
    }
    [HttpGet("/Home/Registro")]
    public IActionResult Registro()
    {
        return View(new RegistroFormViewModel());
    }
    [HttpPost]
    public async Task<IActionResult> Registro(RegistroFormViewModel registroFormViewModel)
    {
        if (!ModelState.IsValid)
        {
            var ModelErrors = ModelState.Select(x => x.Value.Errors).Where(x => x.Count > 0).ToList();
            ViewBag.ErrorMessage = new ErrorAlertViewModel("Error", [.. ModelErrors.SelectMany(x => x.Select(y => y.ErrorMessage).ToList())]);
            return View(registroFormViewModel);
        }
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

    [HttpGet("/Home/Registro/{token}")]
    public IActionResult DetalhesRegistro(string token)
    {
        try
        {
            RegistroViewModel vm = new(_registroService.GetDTOByTokenAsync(token));
            return View(vm);
        }
        catch (Exception)
        {
            return View("Error", $"Um Error ocorreu: O registro inserido é inválido ou não está disponível para consultas");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

}
