using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio4.View
{
    public partial class Editar : System.Web.UI.Page
    {
        DAOAlumnos controlAlumnos = new DAOAlumnos();
        public  DataTable dtNotas = new DataTable();
        public static DataTable copydtNotas = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                alumnos();
                periodo();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            obtenerNotas();
        }


        private void obtenerNotas()
        {

            try
            {
                if (ddlAlumno.SelectedIndex == 0 || ddlPeriodo.SelectedIndex == 0)
                    return;

                dtNotas = controlAlumnos.obtenerNotas(Convert.ToInt32(ddlAlumno.SelectedValue), ddlPeriodo.SelectedItem.Value);
                copydtNotas = dtNotas.Copy();
                GridViewNotas.DataSource = dtNotas;
                GridViewNotas.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void GridViewNotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idx = e.RowIndex;
            try
            {
                string Pk_idNota = GridViewNotas.Rows[idx].Cells[0].Text;
                int idNota= Convert.ToInt32(copydtNotas.Rows[idx].ItemArray[1]);
                if (controlAlumnos.eliminarNota(idNota))
                {
                    Console.WriteLine("Eliminado");
                    obtenerNotas();
                }
            }
            catch(Exception ex)
            { 
            
            }
        }

   
        protected void GridViewNotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName.ToString() == "Actualizar")
                {
                    int idx = Convert.ToInt32(e.CommandArgument);
                    int idNota = Convert.ToInt32(copydtNotas.Rows[idx].ItemArray[1]);
                    GridViewRow row = GridViewNotas.Rows[idx];
                    int nuevaNota = Convert.ToInt32(((TextBox)row.FindControl("txtNuevaNota")).Text);

                    controlAlumnos.actualizarNota(idNota, nuevaNota);

                    Console.WriteLine("Eliminado");
                    obtenerNotas();
                }

                
            }
            catch (Exception)
            {

                throw;
            }

       
        }
    }
}