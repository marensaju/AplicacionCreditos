using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Prestamosconmoras : System.Web.UI.Page
    {
        Pagos p = new Pagos();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][0].ToString() == "True")
            {

            }
            else { Response.Redirect("Inicio.aspx"); }


            int agencia = Convert.ToInt32(Session["idagencia"]);
            int empleado = Convert.ToInt32(Session["idempleado"]);
            try

            {
                GridView1.DataSource = p.PrestamosConMoras(agencia,empleado);
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
            }
            catch (Exception ex)
            { 
            }

        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int idprestamo = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
            String Valor = Convert.ToString(idprestamo);
            Response.Redirect("Realizarpago.aspx?valor=" + Valor);

 
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}