using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class Agencia : System.Web.UI.Page
    {
        IngresosConfiEmpresa em = new IngresosConfiEmpresa();
        ModificacionConfiEmpresa modi = new ModificacionConfiEmpresa();
        Permisos permiso = new Permisos();
        //EstoSeCambiaPorCadaAplicacion
        int idempresa = 0;
        //se usan para actualizardatos
       
        int IDAgencia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
            
            GridView1.DataSource = em.ListadoAgencias(idempresa);
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();
            Button3.Visible = false;
        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idagencia = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                TextNombre.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][0].ToString();
                TextDireccion.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][1].ToString();
                TextTelefono.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][2].ToString();
                TextDepartamento.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][3].ToString();
                TextMunicipio.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][4].ToString();
                TextCapital.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][5].ToString();
                Button1.Visible = false;
                Button3.Visible = true;
                IDAgencia = idagencia;
               
            }

            catch (Exception ex)
            {
            }
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                
                
                    Decimal capi = Convert.ToDecimal(TextCapital.Text);

                    em.Agencia(TextNombre.Text, TextDireccion.Text, TextTelefono.Text, true, TextDepartamento.Text, TextMunicipio.Text, capi, idempresa);

                    //llenar de nuevo el gridview
                    GridView1.DataSource = em.ListadoAgencias(idempresa);
                    GridView1.Columns[0].Visible = false;
                    GridView1.DataBind();
                
                //bitacora
                    Bitacora bita = new Bitacora();
                    bita.RegistrarBitacora("Registro", "crear agencia: "+TextNombre.Text , Convert.ToInt32(Session["idempleado"]));
                 

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

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            IDAgencia =0;
            TextNombre.Text = "";
            TextDireccion.Text = "";
            TextTelefono.Text = "";
            TextDepartamento.Text = "";
            TextMunicipio.Text = "";
            TextCapital.Text = "";
            Button1.Visible = true;
            Button3.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try {
                Decimal capi = Convert.ToDecimal(TextCapital.Text);
                modi.ModAgencia(IDAgencia, TextNombre.Text, TextDireccion.Text, TextTelefono.Text, true, TextDepartamento.Text, TextMunicipio.Text, capi, idempresa);
                GridView1.DataSource = em.ListadoAgencias(idempresa);
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();


                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Actualizar agencia: " + TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
                 
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