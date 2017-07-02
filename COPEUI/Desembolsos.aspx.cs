using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class Desembolsos : System.Web.UI.Page
    {
        PrestamosTodo presta = new PrestamosTodo();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][9].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            int agencia = Convert.ToInt32(Session["idagencia"]);
            GridView1.DataSource = presta.ListaDesembolso(agencia);
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();

        }

        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idprestamo = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                String Valor = Convert.ToString(idprestamo);
                Response.Redirect("InfroPrestamo.aspx?valor=" + Valor);


            }
            catch (Exception ex)
            {

            }

        }
    }
}