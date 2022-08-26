using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


using proyect_one.Model;
using System.Web.Http;
using System.Net;

namespace proyect_one
{
    public partial class About : Page
    {
        protected bool isert = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProducts();
           
        }

        public void GetProducts()
        {
            SqlConnection cn = Conexion.conectar();
            var query = "select *from productos";
           
            List<Object> lst = new List<object>();

            SqlDataAdapter da = new SqlDataAdapter(query,cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridview1.DataSource = dt;
            gridview1.DataBind();

            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnInsert.Visible = true;
            divsec.Visible = true;



        }


        //protected void edit_Click(object sender, EventArgs e)
        //{
        //    //string message = "Hello! Mudassar.";
        //    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    //sb.Append("<script type = 'text/javascript'>");
        //    //sb.Append("window.onload=function(){");
        //    //sb.Append("alert('");
        //    //sb.Append(message);
        //    //sb.Append("')};");
        //    //sb.Append("</script>");
        //    //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            

        //}

        protected void getbutton_Click(object sender, EventArgs e)
        {

            lblNotification.Text = txtId.Text;

        }

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection cn = Conexion.conectar();
            var query = "Delete from productos where idProducto=@id";
            SqlCommand cmd = new SqlCommand(query, cn);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value));
            cmd.ExecuteNonQuery();

            lblNotification.Text = "eliminado";
        }

       

        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNotification.Text = gridview1.SelectedRow.Cells[1].Text;
            int item = Int32.Parse(gridview1.SelectedRow.Cells[0].Text);
            btnInsert.Visible = false;
            GetItem(item);
        }


        public void GetItem(int item)
        {
            SqlConnection cn = Conexion.conectar();
            var query = string.Format( "Select *from productos where idProducto={0}",item);
            SqlCommand cmd = new SqlCommand(query, cn);
            //cmd.Parameters.AddWithValue("@id",item);


            SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    divsec.Visible = true;
                    txtCodigo.Text = reader["Codigo"].ToString();
                    txtId.Text = reader["idProducto"].ToString();
                    txtProducto.Text = reader["Producto"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                }
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
        }

        public void SetProducto()
        {
            try
            {
                SqlConnection cn = Conexion.conectar();
                var query = "insert into productos(Codigo,Producto,Precio) values(@codigo,@producto,@precio)";
                SqlCommand cmd = new SqlCommand(query, cn);



                cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@producto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                var alerta = "no se pudo ingresar producto";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+alerta+"')", true);

            }


        }

        public void updateProducto()
        {
            try
            {
                SqlConnection cn = Conexion.conectar();
                var query = string.Format("update productos set Codigo=@codigo,Producto=@producto,Precio=@precio" +
                                          " where IdProducto=@IdProducto");
                SqlCommand cmd = new SqlCommand(query, cn);

                var cod = txtCodigo.Text;
                var pro = txtProducto.Text;
                decimal pre = decimal.Parse(txtPrecio.Text);
                int id = int.Parse(txtId.Text);

                cmd.Parameters.AddWithValue("@codigo", cod);
                cmd.Parameters.AddWithValue("@producto", pro);
                cmd.Parameters.AddWithValue("@precio", pre);
                cmd.Parameters.AddWithValue("@IdProducto", id);

                cmd.ExecuteNonQuery();

                GetProducts();

            }
            catch(Exception ex)
            {
                string message = "No se pudo Actualizar, campo llenado incorrectamente";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            }

        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SetProducto();
            GetProducts();
            cleanTextbox();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateProducto();
            cleanTextbox();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GetProducts();
            cleanTextbox();
        }

        public void cleanTextbox()
        {
            txtCodigo.Text = "";
            txtId.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
        }
    }
}