using Microsoft.AspNetCore.Mvc;

namespace Ouvidoria.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
