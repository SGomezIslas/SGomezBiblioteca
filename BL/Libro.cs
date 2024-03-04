using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static Dictionary<string, object> GetAll(ML.Libro libro)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", exepcion }, { "Libro", libro } };

            try
            {
                using (DL.SGomezBibliotecaEntities context = new DL.SGomezBibliotecaEntities())
                {
                    var fila = context.LibroGetAll().ToList();

                    if (fila != null)
                    {
                        libro.libross = new List<ML.Libro>();
                        foreach (var filas in fila)
                        {
                            ML.Libro libro1 = new ML.Libro();
                            libro1.IdLibro = filas.IdLibro;
                            libro1.Librs = filas.Libro;
                            libro1.Editorial = filas.Editorial;
                            libro1.Autor = filas.Autor;     
                            libro1.NumeroPaginas = (int)filas.NumeroPaginas;
                            libro1.Generos = new ML.Genero();
                            libro1.Generos.IdGenero = (int)filas.IdGenero;

                            libro.libross.Add(libro1);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Add(ML.Libro libro)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", exepcion } };

            try
            {
                using (DL.SGomezBibliotecaEntities context = new DL.SGomezBibliotecaEntities())
                {
                    int filasAfectadas = context.LibroAdd(libro.Librs, libro.Editorial, libro.Autor, libro.NumeroPaginas, libro.IdGenero);

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Update(ML.Libro libro)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL.SGomezBibliotecaEntities context = new DL.SGomezBibliotecaEntities())
                {
                    int filasAfectadas = context.LibroUpdate(libro.IdLibro, libro.Librs, libro.Editorial, libro.Autor, libro.NumeroPaginas, libro.IdGenero);
                    if(filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch(Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetById(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Libro", libro }, { "Resultado", false }, { "Excepcion", exepcion } };

            try
            {
                using (DL.SGomezBibliotecaEntities context = new DL.SGomezBibliotecaEntities())
                {
                    var registro = context.LibroGetById(IdLibro).SingleOrDefault();
                    if (registro != null)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Delete(int IdLibro) 
        {
            ML.Libro libro = new ML.Libro();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", exepcion }, { "Resultado", false }, { "Libro", libro } };

            try
            {
                using (DL.SGomezBibliotecaEntities context = new DL.SGomezBibliotecaEntities())
                {
                    int filasAfectadas = context.LibroDelete(IdLibro);
                    if(filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Libro"] = libro;
                    }
                }
            }
            catch (Exception ex) 
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }


    }
}
