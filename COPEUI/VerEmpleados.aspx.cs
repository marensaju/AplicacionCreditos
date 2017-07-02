using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class VerEmpleados : System.Web.UI.Page
    {
        VerEmplead ver = new VerEmplead();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Button6.Visible = false;
            Button5.Visible = false;
           
            
           

            /*int agencia = Convert.ToInt32(Session["idagencia"]);
            GridView1.DataSource = ver.ListaEmpleados(agencia);
            GridView1.Columns[4].Visible = false;
            GridView1.DataBind();*/

        }

        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                
                    int idpersona = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                    Label8.Text = idpersona.ToString();
                    Label1.Text = ver.PErfilClientes(idpersona).Rows[0][1].ToString();
                    Label2.Text = ver.PErfilClientes(idpersona).Rows[0][1].ToString();
                    Label3.Text = ver.PErfilClientes(idpersona).Rows[0][2].ToString();
                    Label4.Text = ver.PErfilClientes(idpersona).Rows[0][3].ToString();
                    Label5.Text = ver.PErfilClientes(idpersona).Rows[0][4].ToString();
                    Label6.Text = ver.PErfilClientes(idpersona).Rows[0][5].ToString();
                    Label7.Text = ver.PErfilClientes(idpersona).Rows[0][6].ToString();
                    Label9.Text = ver.PErfilClientes(idpersona).Rows[0][7].ToString();
                    Label10.Text = ver.PErfilClientes(idpersona).Rows[0][8].ToString();
                    Label11.Text = ver.PErfilClientes(idpersona).Rows[0][9].ToString();
                    Label12.Text = ver.PErfilClientes(idpersona).Rows[0][10].ToString();
                    Image1.ImageUrl = "~/ImagenesCargadas/Empleados/" + ver.PErfilClientes(idpersona).Rows[0][11].ToString();

                    GridView2.DataSource = ver.ReferenciasEmpleado(idpersona);
                    GridView2.DataBind();


                    //permiso para modificar
                    if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][21].ToString() == "False")
                    {
                        Button2.Visible = false;
                    }
                    else {
                        Button2.Visible = true;
                    }
                    //permiso para suspender usuario
                    if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][22].ToString() == "False")
                    {
                        Button3.Visible = false;
                    }
                    else { Button3.Visible = true; }
                //crear usuarios
                    if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][19].ToString() == "False")
                    {
                        Button6.Visible = false;
                    }
                    else
                    {
                        Button6.Visible = true;
                    }

                    Button5.Visible = true;
            }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                GridView1.DataSource = ver.FinEmpleado(TextBox1.Text, agencia);
                GridView1.Columns[4].Visible = false;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);

            }

        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            String Valor = Label8.Text;
            Response.Redirect("Usuarios.aspx?valor=" + Valor);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                int idperson = Convert.ToInt32(Label8.Text);
               // ver.EnviarListaNegra(idperson);
                GridView1.DataSource = ver.ListaEmpleados(agencia);
                GridView1.Columns[4].Visible = false;
                GridView1.DataBind();
                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
            }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            String Valor = Label8.Text;
            Response.Redirect("ActualizarEmpleado.aspx?valor=" + Valor);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImprimirListaEmpleados.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            String Valor = Label8.Text;
            Response.Redirect("ImprimirPerfilEmpleado.aspx?valor=" + Valor);
        }



    }
}