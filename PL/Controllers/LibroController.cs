using BL;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> result = BL.Libro.GetAll(libro);
            bool resultado = (bool)result["Resultado"];

            if (resultado)
            {
                libro = (ML.Libro)result["Libro"];
                return View(libro);
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
