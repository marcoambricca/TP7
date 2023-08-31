using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7.Models;

namespace TP7.Controllers;

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

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.categorias = Juego.ObtenerCategorias();
        ViewBag.dificultad = Juego.ObtenerDificultades();
        return View("ConfigurarJuego");
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {   
        bool si = Juego.CargarPartida(username, dificultad, categoria);
        if(si){ 
            return RedirectToAction("Jugar");
        }
        else{
            return View("ConfigurarJuego");
        }
    }

    public IActionResult Jugar()
    {   
        Pregunta pregunta = Juego.ObtenerProximaPregunta();
        if (pregunta== null || Juego.preguntasCont == 15){
            return RedirectToAction("Fin");
        }

        ViewBag.pregCont = Juego.GetPregCont();
        ViewBag.username = Juego.GetUsername();
        ViewBag.cantPregCorrectas = Juego.GetPregCorrectas();
        ViewBag.proxPreg = pregunta;
        List<Respuesta> proximasrespuestas = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
        ViewBag.proxResp = proximasrespuestas;
        
        return View();
    }

    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        return View("Respuesta");
    }

    public IActionResult Fin()
    {
        ViewBag.pregCont = Juego.GetPregCont();
        ViewBag.cantPregCorrectas = Juego.GetPregCorrectas();
        return View();
    }
}