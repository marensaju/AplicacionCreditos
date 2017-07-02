using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Carteramuerta : System.Web.UI.Page
    {
        Ripo r = new Ripo();
        Pagos pa = new Pagos();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][18].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
            DropDownList1.Visible = true;
            if (!IsPostBack)
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DropDownList1.DataSource = pa.AsesoresDropdown(agencia);
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "Id_empleado";
                DropDownList1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                int empleado = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                GridView2.DataSource = r.CarteraMuerta(agencia, empleado);
                GridView2.DataBind();
                Button2.Visible = true;
            }
            catch (Exception ex) { }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Bitacora bita = new Bitacora();
            bita.RegistrarBitacora("Imprimir", "Cartera muerta", Convert.ToInt32(Session["idempleado"]));
            int empleado = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            String Valor = Convert.ToString(empleado);
            Response.Redirect("ImprimirCarteramuerta.aspx?valor=" + Valor);

        }
    }
}