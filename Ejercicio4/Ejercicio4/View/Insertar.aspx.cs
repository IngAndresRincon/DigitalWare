using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Model;

namespace Ejercicio4
{
    public partial class Insertar : System.Web.UI.Page
    {
        DAOAlumnos controlAlumnos = new DAOAlumnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                alumnos();
                periodo();
                materia();
            }
        }


        private void alumnos()
        {

            try
            {
                DataTable alumnos = new DataTable();

                alumnos = controlAlumnos.obtenerAlumnos();
                ddlAlumno.DataSource = alumnos;
                ddlAlumno.DataTextField = "ALUMNO";
                ddlAlumno.DataValueField = "PK_IDALUMNO";
                ddlAlumno.DataBind();
                ddlAlumno.Items.Insert(0, new ListItem("SELECCIONE", "0"));
            }
            catch
            {

            }



        }


        private void materia()
        {

            try
            {
                DataTable alumnos = new DataTable();

                alumnos = controlAlumnos.obtenerMaterias();
                ddlMateria.DataSource = alumnos;
                ddlMateria.DataTextField = "MAT_NOMBRE";
                ddlMateria.DataValueField = "PK_IDMATERIA";
                ddlMateria.DataBind();
                ddlMateria.Items.Insert(0, new ListItem("SELECCIONE", "0"));
            }
            catch
            {

            }



        }

        private void periodo()
        {
            try
            {
                DataTable _periodo = new DataTable();

                _periodo = controlAlumnos.obtenerPeriodos();
                ddlPeriodo.DataSource = _periodo;
                ddlPeriodo.DataTextField = "Periodo";
                ddlPeriodo.DataValueField = "PK_IDPERIODO";
                ddlPeriodo.DataBind();
                ddlPeriodo.Items.Insert(0, new ListItem("SELECCIONE", "0"));
            }
            catch
            {

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            

            try
            {
                NotaModel nota = new NotaModel() { 
                
                    alumno = Convert.ToInt32(ddlAlumno.SelectedValue),
                    materia = Convert.ToInt32(ddlMateria.SelectedValue),
                    periodo = Convert.ToInt32(ddlPeriodo.SelectedValue),
                    nota = Convert.ToInt32(txtNota.Text)
                };
                if (controlAlumnos.insertarNotaAlumno(nota))
                {
                    Console.WriteLine("Insertado ..");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}