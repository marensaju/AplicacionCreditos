using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Historialpagos : System.Web.UI.Page
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*try
            {*/

              //  pa.TOtalPagosSinElegirEMpleado(f1, f2, agencia);
               // pa.HistorialPagosSinElegirEMpleado(f1, f2, agencia);
                
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DateTime f1 = Convert.ToDateTime(TextBox1.Text);
                DateTime f2 = Convert.ToDateTime(TextBox2.Text);
                int empleado = Convert.ToInt32(Session["idempleado"]);
                GridView2.DataSource = pa.HistorialPagos(f1, f2, agencia, empleado);
                GridView2.DataBind();
                Label1.Text = pa.TotalHistoPagos(f1, f2, empleado, agencia).Rows[0][0].ToString();
                Label2.Text = pa.TotalHistoPagos(f1, f2, empleado, agencia).Rows[0][1].ToString();
                Label4.Text = pa.TotalHistoPagos(f1, f2, empleado, agencia).Rows[0][2].ToString();
                Label3.Text = pa.TotalHistoPagos(f1, f2, empleado, agencia).Rows[0][3].ToString();
                Div1.Visible = true;
                Div2.Visible = true;
                Div3.Visible = true;
                textoc.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
            
          /*  }
            catch (Exception ex) { 
            }*/
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}