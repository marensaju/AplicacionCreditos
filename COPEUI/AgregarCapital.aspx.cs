using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class AgregarCapital : System.Web.UI.Page
    {
        IngresosConfiEmpresa em = new IngresosConfiEmpresa();
        ModificacionConfiEmpresa modi = new ModificacionConfiEmpresa();
        Permisos permiso = new Permisos();
        //EstoSeCambiaPorCadaAplicacion
        int idempresa = 0;
        //se usan para actualizardatos
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            GridView1.DataSource = em.ListadoAgencias(idempresa);
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();
        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idagencia = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Label1.Text = em.LIstadoEditarAgencias(idagencia).Rows[0][5].ToString();
                Label3.Text=Convert.ToString(idagencia);
               
            }

            catch (Exception ex)
            {
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextCapital.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal capo = Convert.ToDecimal(TextCapital.Text);
                Decimal Capi=Convert.ToDecimal(Label1.Text)+capo;
                int agen = Convert.ToInt32(Label3.Text);
                modi.AgregarCapital(agen,Capi);
                GridView1.DataSource = em.ListadoAgencias(idempresa);
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Agregar capital Agencia : "+ Label3.Text+ " Cantidad de "+Convert.ToString(Capi), Convert.ToInt32(Session["idempleado"]));
                 

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
    }
}