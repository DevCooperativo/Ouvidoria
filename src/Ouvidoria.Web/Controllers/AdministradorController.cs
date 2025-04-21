using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.DTO;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;

[Authorize(Policy = "RequireAdministratorRole")]
public class AdministradorController : Controller
{
    private readonly IRegistroService _registroService;
    private readonly ILogger<AdministradorController> _logger;
    private readonly IObjectStorageService _objectStorageService;

    public AdministradorController(IRegistroService registroService, ILogger<AdministradorController> logger, IObjectStorageService objectStorageService)
    {
        _registroService = registroService;
        _logger = logger;
        _objectStorageService = objectStorageService;
    }
    /// <summary>
    /// A dashboard principal do usuário administrador, contendo uma listagem de todos os registros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Registros()
    {
        IEnumerable<RegistroViewModel> registroViewModels = _registroService.GetAll().Select(x => (RegistroViewModel)x);
        return View(registroViewModels);
    }

    /// <summary>
    /// Um detalhamento de um único registro obtide pelo id (query)
    /// </summary>
    /// <param name="id">Id do registro</param>
    /// <returns></returns>
    [HttpGet("/Administrador/Registro/{id}")]
    public async Task<IActionResult> Detalhes(int id)
    {
        RegistroDTO registroDTO = await _registroService.GetDTOByIdAsync(id);
        AdminRegistroFormViewModel viewModel = new(registroDTO);
        return View(viewModel);
    }

    [HttpPost("/Administrador/Registro")]
    public async Task<IActionResult> Detalhes(HistoricoRegistroFormViewModel historicoVM)
    {
        RegistroDTO registroDTO = await _registroService.GetDTOByIdAsync(historicoVM.RegistroId);
        AdminRegistroFormViewModel registroViewModel = new(registroDTO);
        if (!ModelState.IsValid) return View(registroViewModel);
        try
        {
            registroDTO.AddHistorico(new HistoricoRegistroDTO(historicoVM.Status, historicoVM.Feedback));
            await _registroService.UpdateAsync(registroDTO);
            return RedirectToAction("Detalhes", new { id = registroDTO.Id });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return View(registroViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
