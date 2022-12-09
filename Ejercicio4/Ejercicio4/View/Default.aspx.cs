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
    public partial class Default : System.Web.UI.Page
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
            DataTable alumnos = new DataTable();

            alumnos =  controlAlumnos.obtenerAlumnos();

        }
    }
}