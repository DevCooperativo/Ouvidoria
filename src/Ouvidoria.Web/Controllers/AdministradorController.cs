using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Administrador;
using Ouvidoria.Web.ViewModels.ChartData;
using Ouvidoria.Web.ViewModels.Registro;

namespace Ouvidoria.Web.Controllers;
[Authorize]
public class AdministradorController : Controller
{
    private readonly IRegistroService _registroService;
    private readonly ILogger<AdministradorController> _logger;
    private readonly IObjectStorageService _objectStorageService;
    private readonly IAdministradorService _administradorService;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public AdministradorController(IRegistroService registroService, ILogger<AdministradorController> logger, IObjectStorageService objectStorageService, IAdministradorService administradorService, SignInManager<ApplicationUser> signInManager)
    {
        _registroService = registroService;
        _logger = logger;
        _objectStorageService = objectStorageService;
        _administradorService = administradorService;
        _signInManager = signInManager;
    }
    /// <summary>
    /// A dashboard principal do usuário administrador, contendo uma listagem de todos os registros
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Registros()
    {
        AdministradorDTO adminDTO = await _administradorService.GetDTOByEmailAsync(User.Claims.Where(x=>x.Type==ClaimTypes.Email).Select(x=>x.Value).FirstOrDefault()??"");
        AdministradorRegistrosWithChartDataViewModel rm = new(_registroService.GetAll().Where(x => x.AdministradorId == adminDTO.Id).Select(x => (RegistroViewModel)x), new ChartDataViewModel(_registroService.GetCountPerMonthToChartDataDTO()));
        return View(rm);
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
        AdministradorDTO adminDTO = await _administradorService.GetDTOByEmailAsync(User.Claims.Where(x=>x.Type==ClaimTypes.Email).Select(x=>x.Value).FirstOrDefault()??"");
        if(registroDTO.AdministradorId != adminDTO.Id) throw new Exception("Você não pode acessar esse regitro");
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
