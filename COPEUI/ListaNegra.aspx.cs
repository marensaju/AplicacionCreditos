using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class ListaNegra : System.Web.UI.Page
    {
        VerClientes ver = new VerClientes();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
          /*  int agencia = Convert.ToInt32(Session["idagencia"]);
            GridView1.DataSource = ver.ListaNegra(agencia);
            GridView1.Columns[4].Visible = false;
            GridView1.DataBind();*/

        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idpersona = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Label8.Text = idpersona.ToString();
                Label1.Text = ver.PerfilC(idpersona).Rows[0][1].ToString();
                Label2.Text = ver.PerfilC(idpersona).Rows[0][1].ToString();
                Label3.Text = ver.PerfilC(idpersona).Rows[0][2].ToString();
                Label4.Text = ver.PerfilC(idpersona).Rows[0][3].ToString();
                Label5.Text = ver.PerfilC(idpersona).Rows[0][4].ToString();
                Label6.Text = ver.PerfilC(idpersona).Rows[0][5].ToString();
                Label7.Text = ver.PerfilC(idpersona).Rows[0][6].ToString();
                Image1.ImageUrl = "~/ImagenesCargadas/Clientes/" + ver.PerfilC(idpersona).Rows[0][7].ToString();
                Label9.Text = ver.PerfilC(idpersona).Rows[0][8].ToString();

                GridView2.DataSource = ver.Listadore(idpersona);
                GridView2.DataBind();

                GridView3.DataSource = ver.Historiales(idpersona);
                GridView3.DataBind();



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
                GridView1.DataSource = ver.NegraFincliente(TextBox1.Text, agencia);
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

        protected void Button3_Click(object sender, EventArgs e)
        {

            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                int idperson = Convert.ToInt32(Label8.Text);
                ver.QuitardeLista(idperson);
                GridView1.DataSource = ver.ListaNegra(agencia);
                GridView1.Columns[4].Visible = false;
                GridView1.DataBind();

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Quitar de lista negra " + Convert.ToString(idperson), Convert.ToInt32(Session["idempleado"]));


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
            Response.Redirect("ActualizarCliente.aspx?valor=" + Valor);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImprimirClientesListaNegra.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            String Valor = Label8.Text;

            Bitacora bita = new Bitacora();
            bita.RegistrarBitacora("Imprimir", "Imprimir info de cliente: " + Valor, Convert.ToInt32(Session["idempleado"]));
            Response.Redirect("ImprimirInfoCliente.aspx?valor=" + Valor);
        }



    }
}