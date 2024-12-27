#region Coment�rios de Manuten��o

/*------------------------------------------
 DATA_ATUALIZA��O: 26/12/2024
 MANUTEN��O: Implementa��o inicial
 -----------------------------------------*/

#endregion

using Microsoft.AspNetCore.Mvc;
using STKShop.Web.Models;
using System.Diagnostics;

namespace STKShop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
