using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        BD bd = new BD();
        ViewBag.figuritas = bd.figuritas();
        return View();
    }
    public IActionResult SobreAbierto()
    {
        BD bd = new BD();
        ViewBag.figuritas = bd.sobre();
        return View();
    }

    public IActionResult Sobre()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Confirmar(List<int> figuritaId)
    {
        BD bd = new BD();
        bd.confirmarSobre(figuritaId);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
