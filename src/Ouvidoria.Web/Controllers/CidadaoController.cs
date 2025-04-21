using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Error;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

[Authorize]
public class CidadaoController : Controller
{
    private readonly ILogger<CidadaoController> _logger;
    private readonly IRegistroService _registroService;
    private readonly ICidadaoService _cidadaoService;
    public CidadaoController(ILogger<CidadaoController> logger, IRegistroService registroService, ICidadaoService cidadaoService)
    {
        _logger = logger;
        _registroService = registroService;
        _cidadaoService = cidadaoService;
    }

    [HttpGet]
    public async Task<IActionResult> Registros(string? tituloPesquisa)
    {
        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        var errorMessageJson = TempData["ErrorMessage"]?.ToString();
        if (errorMessageJson is not null)
            ViewBag.ErrorMessage = JsonConvert.DeserializeObject<ErrorAlertViewModel>(errorMessageJson);
            
        CidadaoDTO cidadaoDTO = await _cidadaoService.GetCidadaoByClaimsAsync(User);
        IEnumerable<RegistroDTO> quary = _registroService.GetAll().Where(x => x.AutorId == cidadaoDTO.Id);
        if (!string.IsNullOrWhiteSpace(tituloPesquisa))
        {
            quary = quary.Where(x => x.Titulo.Contains(tituloPesquisa, StringComparison.CurrentCultureIgnoreCase));
        }
        IEnumerable<RegistroViewModel> vm = quary.Select(x => new RegistroViewModel(x));
        return View(vm);
    }

    [HttpGet("/Cidadao/Registro/{id}")]
    public async Task<IActionResult> Detalhes(int id)
    {
        RegistroDTO registroDTO = await _registroService.GetDTOByIdAsync(id);
        RegistroFormViewModel viewModel = new(registroDTO);
        var teste = Json(viewModel);
        return teste;
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
