using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class DiasFeriado : System.Web.UI.Page
    {
        IngresosConfiEmpresa em = new IngresosConfiEmpresa();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {  Permisos permiso = new Permisos();
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            try {
                GridView1.DataSource = em.VerFeriados();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
            }
            catch (Exception ex){
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction2();</script>");
            }

        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                em.EliminarDiasFeriado(id);
                GridView1.DataSource = em.VerFeriados();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Eliminacion", "Elimino feriado ", Convert.ToInt32(Session["idempleado"]));
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");
            }
            catch (Exception s) {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction2();</script>");
            }
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {

                DateTime dia = Convert.ToDateTime(TextBox1.Text);
                em.OmitirDias(dia,true, TextDescripcion.Text );
                GridView1.DataSource = em.VerFeriados();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro ", "Nueva Feriado " + TextDescripcion.Text, Convert.ToInt32(Session["idempleado"]));
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");
            }
            catch (Exception ex) {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction2();</script>");
            }

        }
    }
}