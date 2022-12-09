using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAO
{
    public class DAOAlumnos : DAO, IDisposable
    {
        public void Dispose()
        {

        }

        public DataTable obtenerNotas(int idAlumno, string periodo)
        {
            DataTable dtNotas = new DataTable();

            try
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter("SP_GET_NOTAS", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@PI_IDALUMNO", idAlumno);
                da.SelectCommand.Parameters.AddWithValue("@PI_PERIODO", periodo);
                da.Fill(dtNotas);

            }
            catch
            {
                dtNotas = null;
            }
            finally
            {
                conexion.Close();
            }
            return dtNotas;
        }

        public DataTable obtenerAlumnos()
        {

            DataTable alumnos = new DataTable();

            try
            {
                conexion.Open();
                String query = String.Format(@"SELECT 
                                            PK_IDALUMNO,
                                            CONCAT(ALU_NOMBRE,' ',ALU_APELLIDO) as ALUMNO
                                            FROM TBL_ALUMNO WHERE ALU_ACTIVO = 1");
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.Fill(alumnos);
            }
            catch (Exception ex)
            {
                alumnos = null;
            }
            finally
            {
                conexion.Close();
            }

            return alumnos;
        }

        public DataTable obtenerPeriodos()
        {
            DataTable periodo = new DataTable();

            try
            {
                conexion.Open();
                String query = String.Format(@"SELECT PK_IDPERIODO, CONCAT('Periodo: ',PERIODO) as Periodo  FROM TBL_PERIODO");
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.Fill(periodo);
            }
            catch (Exception ex)
            {
                periodo = null;
            }
            finally
            {
                conexion.Close();
            }

            return periodo;
        }


        public bool eliminarNota(int idNota)
        {

            bool respuesta = false;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_IUD_NOTAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_IDNOTA", idNota);
                cmd.Parameters.AddWithValue("@PI_ELIMINAR", 1);
                cmd.Parameters.Add("@PO_OUTPUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                if (Convert.ToBoolean(cmd.Parameters["@PO_OUTPUT"].Value))
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            finally
            {
                conexion.Close();
            }
        

            return respuesta;
        
        }
        public bool actualizarNota(int idNota, int nuevaNota)
        {

            bool respuesta = false;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_IUD_NOTAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_IDNOTA", idNota);
                cmd.Parameters.AddWithValue("@PI_ACTUALIZAR", 1);
                cmd.Parameters.AddWithValue("@PI_NOT_VALOR", nuevaNota);
                cmd.Parameters.Add("@PO_OUTPUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                if (Convert.ToBoolean(cmd.Parameters["@PO_OUTPUT"].Value))
                {
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            finally
            {
                conexion.Close();
            }

            return respuesta;
        }

        public DataTable obtenerMaterias()
        {
            DataTable materia = new DataTable();

            try
            {
                conexion.Open();
                String query = String.Format(@"SELECT PK_IDMATERIA,MAT_NOMBRE FROM [dbo].[TBL_MATERIA]");
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.Fill(materia);
            }
            catch (Exception ex)
            {
                materia = null;
            }
            finally
            {
                conexion.Close();
            }

            return materia;
        }


        public bool insertarNotaAlumno(NotaModel nuevaNota)
        {
            bool respuesta = false;

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_IUD_NOTAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PI_INSERTAR", 1);
                cmd.Parameters.AddWithValue("@PI_IDMATERIA", nuevaNota.materia);
                cmd.Parameters.AddWithValue("@PI_IDALUMNO", nuevaNota.alumno);
                cmd.Parameters.AddWithValue("@PI_IDPERIODO", nuevaNota.periodo);
                cmd.Parameters.AddWithValue("@PI_NOT_VALOR", nuevaNota.nota);
                cmd.Parameters.Add("@PO_OUTPUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();


                if (Convert.ToBoolean(cmd.Parameters["@PO_OUTPUT"].Value))
                {
                    respuesta = true;
                }

            }
            catch (Exception)
            {
                respuesta = false;
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return respuesta;


        }
    }
}
