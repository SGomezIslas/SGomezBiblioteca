using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL1.Controllers
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
        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro1 = new ML.Libro();
            if (IdLibro != null)
            {
                Dictionary<string, object> result = BL.Libro.GetById(IdLibro.Value);
                bool resultado = (bool)result["Resultado"];
            }

            else
            {
                ViewBag.Mensaje = "Ocurrio un error al recuperar la informacion" ;
                return PartialView("Modal");
            }
            return View(libro1);
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            Dictionary<string, object> result = BL.Libro.Add(libro);
            bool resultado = (bool)result["Resultado"];
            if (resultado)
            {
                ViewBag.Mensaje = "El libro ha sido insertado";
                return PartialView("Modal");
            }
            else
            {
                //pendiente la alerta               
                string exepcion = (string)result["Exepcion"];
                ViewBag.Mensaje = "El libro no se pudo registrar " + exepcion;
                return PartialView("Modal");
            }
        }
        public ActionResult Delete(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            Dictionary<string, object> result = BL.Libro.Delete(IdLibro.Value);
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {
                ViewBag.Mensaje = "El libro ha sido eliminado";
                return PartialView("Modal");
            }
            else
            {
                //pendiente la alerta               
                //   string exepcion = (string)result["Exepcion"];
                ViewBag.Mensaje = "ERROR! El libro no se elimino "; // + exepcion;
                return PartialView("Modal");
            }
        }

    }
}
