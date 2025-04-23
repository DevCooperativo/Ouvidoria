// using Microsoft.AspNetCore.Mvc;
// using Ouvidoria.DTO;
// using Ouvidoria.Interfaces;
// using Ouvidoria.Web.ViewModels.Files;

// namespace Ouvidoria.Web.Controllers;

// public class UploadController : Controller
// {
//     private IObjectStorageService _objectStorageService;

//     public UploadController(IObjectStorageService objectStorageService)
//     {
//         _objectStorageService = objectStorageService;
//     }

//     [HttpGet]
//     public IActionResult Index()
//     {
//         return View();
//     }
//     [HttpPost]
//     public async Task<IActionResult> Index(FileUploadViewModel fileUploadViewModel)
//     {
//         if (fileUploadViewModel.File != null && fileUploadViewModel.File.Length > 0)
//         {
//             using (MemoryStream stream = new())
//             {
//                 await fileUploadViewModel.File.CopyToAsync(stream);
//                 var file = new ArquivoDTO
//                 {
//                     Id = 0,
//                     Nome = fileUploadViewModel.File.FileName,
//                     TipoArquivo = fileUploadViewModel.File.ContentType.Split("/")[1],
//                     Bytes = stream.ToArray()
//                 };
//                 await _objectStorageService.UploadFileAsync(file);
//             }
//         }

//         return RedirectToAction("Index", "Home");

//     }
//     [HttpGet]
//     public async Task<IActionResult> List()
//     {
//         ViewData["File"] = _objectStorageService.GetFileUrlAsync("68a6039f-d7f7-4d0b-9312-2e19b695bca0.png");
//         return View();
//     }

//     [HttpGet]
//     public IActionResult Delete()
//     {
//         return View();
//     }

//     [HttpPost]
//     public async Task<IActionResult> Delete(FileDeleteViewModel fileDeleteViewModel)
//     {
//         await _objectStorageService.DeleteFileAsync(fileDeleteViewModel.FileName);

//         return RedirectToAction("Index", "Home");
//     }
// }
