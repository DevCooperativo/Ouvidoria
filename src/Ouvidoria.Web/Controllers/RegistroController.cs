using Microsoft.AspNetCore.Mvc;
using Ouvidoria.DTO;
using Ouvidoria.Infrastructure.Data.Account;
using Ouvidoria.Interfaces;


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

	// [HttpGet]
	// public IActionResult CriarRegistro()
	// {
	//     return View();
	// }

	// [HttpPost]
	// public async Task<IActionResult> CriarRegistro(RegistroFormViewModel registroFormViewModel)
	// {
	//     if (!ModelState.IsValid) return View(registroFormViewModel);
	//     try
	//     {
	//         return RedirectToAction("Index");
	//     }
	//     catch (Exception ex)
	//     {
	//         Console.Write(ex);
	//         return View(registroFormViewModel);
	//     }
	// }
}
