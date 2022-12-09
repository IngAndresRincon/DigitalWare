using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio5.Models
{
    public class NotaModel
    {
        public int Id { get; set; }
        public string Alumno { get; set; }
        public string Curso { get; set; }
        public string Materia { get; set; }
        public int Nota { get; set; }
        public int Periodo { get; set; }


    }
}