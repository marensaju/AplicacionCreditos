using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class mora : System.Web.UI.Page
    {
        IngresosConfiEmpresa i = new IngresosConfiEmpresa();
        IngresosPrestamos presa = new IngresosPrestamos();
        ModificacionesPretamos modi = new ModificacionesPretamos();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            GridView1.DataSource = i.ListarMora();
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();

        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try {
                int idmora = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Label3.Text = presa.InfoParaEditarMora(idmora).Rows[0][0].ToString();
                TextNombre.Text = presa.InfoParaEditarMora(idmora).Rows[0][1].ToString();
                TextDescripcion.Text = presa.InfoParaEditarMora(idmora).Rows[0][2].ToString();
                TextInteres.Text = presa.InfoParaEditarMora(idmora).Rows[0][3].ToString();
                Button1.Visible = false;
                Button3.Visible = true;

            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }
 
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextNombre.Text = "";
            TextDescripcion.Text = "";
            TextInteres.Text = "";
            Button1.Visible = true;
            Button3.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                presa.Mora(TextNombre.Text,TextDescripcion.Text,Convert.ToDecimal(TextInteres.Text),true);
                GridView1.DataSource = i.ListarMora();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro ", "Nueva mora "+TextNombre.Text , Convert.ToInt32(Session["idempleado"]));
                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);

            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try {

                modi.ModMora(Convert.ToInt32(Label3.Text),TextNombre.Text,TextDescripcion.Text,Convert.ToDecimal(TextInteres.Text),true);
                GridView1.DataSource = i.ListarMora();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Actualizar", "Mora "+ TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }
        }
    }
}