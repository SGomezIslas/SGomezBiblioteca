using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Librs {  get; set; }
        public string Autor {  get; set; }
        public string Editorial {  get; set; }
        public int NumeroPaginas {  get; set; }
        public int IdGenero {  get; set; }
        public ML.Genero Generos { get; set; }
        public List<ML.Libro> libross { get; set; }
    }
}
