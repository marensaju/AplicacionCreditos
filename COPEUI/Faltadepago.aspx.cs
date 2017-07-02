using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Faltadepago : System.Web.UI.Page
    {
        Pagos pa = new Pagos();
        protected void Page_Load(object sender, EventArgs e)
        {
            SuperAdmin.Visible = false;
            /* if (!IsPostBack)
             {
                 int agencia = Convert.ToInt32(Session["idagencia"]);
                 DropDownList1.DataSource =pa.AsesoresDropdown(agencia);
                 DropDownList1.DataTextField = "name";
                 DropDownList1.DataValueField = "Id_empleado";
                 DropDownList1.DataBind();
             }*/
            string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
            TextBox1.Text = fecha1;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DateTime f1 = Convert.ToDateTime(TextBox1.Text);           
                int empleado = Convert.ToInt32(Session["idempleado"]);
                GridView2.DataSource = pa.FALTADEPAGO(f1, agencia,empleado);
                GridView2.DataBind();


           }
            catch (Exception ex)
            {
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

    }
}