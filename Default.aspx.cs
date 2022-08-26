using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace proyect_one
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection cn = Conexion.conectar();

            if (cn.State == System.Data.ConnectionState.Open)
            {
                lbl1.Text = "Conectado";
            }
            

        }
    }
}