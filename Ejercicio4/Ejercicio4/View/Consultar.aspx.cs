using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace Ejercicio4.View
{
    public partial class Consultar : System.Web.UI.Page
    {

        DAOAlumnos controlAlumnos = new DAOAlumnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                alumnos();
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

        protected void ddlAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtNotas = new DataTable();
            try
            {
                dtNotas = controlAlumnos.obtenerNotas(Convert.ToInt32(ddlAlumno.SelectedValue),null);
                GridViewNotas.DataSource = dtNotas;
                GridViewNotas.DataBind();
            }
            catch(Exception ex)
            { 
            
            }
        }
    }
}