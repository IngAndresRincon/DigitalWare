using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ejercicio5.Models;

namespace Ejercicio5.Controllers
{
    public class DigitalWareController : ApiController
    {
        // GET: api/DigitalWare
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/DigitalWare/5

        [Route("api/GetDigitalWare")]
        public List<NotaModel> Get(int IdAlumno)
        {
            DataTable dtDatos = new DataTable();

            try
            {
                Control _consulta = new Control();
                dtDatos = _consulta.obtenerDatosTabla(IdAlumno);

                List<NotaModel> notas = new List<NotaModel>();
                foreach (DataRow dr in dtDatos.Rows) {
                    NotaModel minota = new NotaModel() {

                        Id = Convert.ToInt32(dr.ItemArray[0]),
                        Alumno = dr.ItemArray[1].ToString(),
                        Curso = dr.ItemArray[2].ToString(),
                        Materia = dr.ItemArray[3].ToString(),
                        Nota = Convert.ToInt32(dr.ItemArray[4].ToString()),
                        Periodo = Convert.ToInt32(dr.ItemArray[5].ToString()),

                    };

                    notas.Add(minota);
                }

                
                return notas;

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        // POST: api/DigitalWare
        [Route("api/PostDigitalWare")]
        public string Post([FromBody]string value)
        {
            return value.ToString().ToUpper();

        }

    
    }
}
