using Microsoft.AspNetCore.Mvc;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;
using Ouvidoria.Web.ViewModels.Error;
using Ouvidoria.Web.ViewModels.Registro;


namespace Ouvidoria.Web.Controllers;

public class RegistroController : Controller
{
	private readonly IRegistroService _registroService;
	private readonly ICidadaoService _cidadaoService;
	private readonly IObjectStorageService _objectStorageService;
	private readonly ILogger<RegistroController> _logger;

	public RegistroController(
		IRegistroService registroService,
		ILogger<RegistroController> logger,
		ICidadaoService cidadaoService,
		IObjectStorageService objectStorageService)
	{
		_registroService = registroService;
		_logger = logger;
		_cidadaoService = cidadaoService;
		_objectStorageService = objectStorageService;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	public async Task<IActionResult> DownloadArquivo(int id)
	{
		try
		{
			RegistroDTO registro = await _registroService.GetDTOByIdAsync(id);
			if (!User.IsInRole(ApplicationUser.TipoAdministrador))
			{
				CidadaoDTO cidadao = await _cidadaoService.GetCidadaoByClaimsAsync(User);
				if (cidadao.Id != registro.AutorId) throw new Exception("Houve um erro no download do arquivo");
			}
			if (registro.Arquivo is null) throw new Exception("Arquivo não encontrado");

			byte[] fileBytes = await _objectStorageService.GetFileBytesAsync(registro.Arquivo.NomeS3);

			return File(fileBytes, registro.Arquivo.GetMimeType(), registro.Arquivo.Nome);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status404NotFound);
		}
	}

	[HttpGet]
	public IActionResult CriarRegistro()
	{
		RegistroFormViewModel vm = new();
		return View(vm);
	}

	[HttpPost]
	public async Task<IActionResult> CriarRegistro(RegistroFormViewModel registroFormViewModel)
	{
		if (!ModelState.IsValid)
		{
			var ModelErrors = ModelState.Select(x => x.Value.Errors).Where(x => x.Count > 0).ToList();
			ViewBag.ErrorMessage = new ErrorAlertViewModel("Error", [.. ModelErrors.SelectMany(x => x.Select(y => y.ErrorMessage).ToList())]);
			return View(registroFormViewModel);
		}
		string tokenAcesso=string.Empty;
		try
		{
			RegistroDTO registroDTO = new()
			{
				Titulo = registroFormViewModel.Titulo,
				IsAnonima = registroFormViewModel.IsAnonima,
				Tipo = registroFormViewModel.Tipo,
				TipoRegistro = registroFormViewModel.TipoRegistro,
				Descricao = registroFormViewModel.Descricao,
				Arquivo = registroFormViewModel.Arquivo.ConvertToImageDTO(),
			};
			tokenAcesso = await _registroService.CreateAsync(registroDTO, User);
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = new ErrorAlertViewModel("registro", [ex.Message]);
			return View(registroFormViewModel);
		}
		TempData["SuccessMessage"] = "Sua denúncia foi enviada com sucesso.";

		return RedirectToAction("RegistroCriado", new { tokenAcesso });
	}


	[HttpGet]
	public IActionResult RegistroCriado(string tokenAcesso)
	{
		ViewData["TokenAcesso"] = tokenAcesso;
		return View();
	}
}
