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
        int cantFiguritasObtenidas = 0;
        List<Figurita> figuritas = bd.figuritas();
        ViewBag.figuritas = figuritas;
        foreach(Figurita figurita in figuritas)
        if (figurita.Cantidad >= 1)
        {
            cantFiguritasObtenidas += 1;
        }
        ViewBag.porcentaje = cantFiguritasObtenidas * 100 / figuritas.Count;
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
    public IActionResult ReiniciarAlbum()
    {
        BD bd = new BD();
        bd.reiniciarAlbum();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Confirmar(List<int> figuritaId)
    {
        BD bd = new BD();
        bd.confirmarSobre(figuritaId);
        return RedirectToAction("Index");
    }
    public IActionResult Repetidas()
    {
        BD bd = new BD();
        List<Figurita> repetidas = bd.repetidas();
        ViewBag.repetidas = repetidas;
        return View();
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
