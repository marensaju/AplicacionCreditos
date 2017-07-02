using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ReportePaginaInicio repo = new ReportePaginaInicio();
            IngresoUsuarios log = new IngresoUsuarios();
            log.i(TextBox1.Text, TextBox2.Text, Label1.Text);
            string cool = log.i(TextBox1.Text, TextBox2.Text, Label1.Text);
            string c1 = TextBox1.Text;
            log.s(TextBox1.Text, TextBox2.Text, Label2.Text);
            string agencia = log.s(TextBox1.Text, TextBox2.Text, Label2.Text);

            if (cool == "1")
            {
                Session["cool"] = c1;
                Session["idagencia"] = agencia;
                Session["idempleado"] = repo.SaberIdEmpleado(TextBox1.Text, TextBox2.Text).Rows[0][0].ToString();
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Inicio de sesion", "Empleado inicio sesion", Convert.ToInt32(Session["idempleado"]));
                Response.Redirect("Inicio.aspx");

            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");

                
            }
        }
    }
}