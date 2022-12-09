using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ejercicio5
{
    public class Control : Conexion
    {

        public DataTable obtenerDatosTabla(int idAlumno)
        {
            DataTable datos = new DataTable();

            try
            {
                conexion.Open();
                String query = String.Format(@"SELECT 
                                                PK_IDALUMNO as Id,
                                                CONCAT(ALU_NOMBRE,' ',ALU_APELLIDO)	as Alumno,
                                                CUR_DESCRIPCION as Curso,
                                                MAT_NOMBRE as Materia,
                                                NOT_VALOR as Nota,
                                                P.PERIODO as Periodo
                                                FROM [dbo].[TBL_ALUMNO] as A
                                                INNER JOIN [dbo].[TBL_CURSO] as C
                                                ON A.FK_IDCURSO = C.PK_IDCURSO
                                                INNER JOIN [dbo].[TBL_NOTA] as N
                                                ON N.FK_IDALUMNO = A.PK_IDALUMNO
                                                INNER JOIN [dbo].[TBL_MATERIA] as M
                                                ON N.FK_IDMATERIA = M.PK_IDMATERIA
                                                INNER JOIN [dbo].[TBL_PERIODO] as P
                                                ON P.PK_IDPERIODO = N.FK_PERIODO
                                                WHERE A.PK_IDALUMNO = {0}
                                                ", idAlumno);
                SqlDataAdapter da = new SqlDataAdapter(query,conexion);
                da.Fill(datos);
            }
            catch (Exception)
            {
                datos = null;
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return datos;
        }


    }
}