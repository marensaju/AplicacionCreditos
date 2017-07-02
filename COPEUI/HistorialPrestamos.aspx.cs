using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class HistorialPrestamos : System.Web.UI.Page
    {
        PrestamosTodo presta = new PrestamosTodo();
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DateTime f1= Convert.ToDateTime(TextBox1.Text);
                DateTime f2=Convert.ToDateTime(TextBox2.Text);
                GridView1.DataSource = presta.HPrestamosGeneral(agencia,f1,f2);
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
                Button2.Visible = true;
                Label1.Visible = true;
                Label3.Visible = true;
                Label3.Text = "Q. "+presta.SumaPrestamos(agencia, f1, f2).Rows[0][0].ToString();
                Div1.Visible = true;
                textoc.Visible = true;
                Label1.Text = presta.SumaPrestamos(agencia, f1, f2).Rows[0][1].ToString();
               
            }
            catch (Exception ex)
            { 
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String Valor = TextBox1.Text;
                String Ubicac = TextBox2.Text;
                Response.Redirect("ImprimirHistorialPrestamos.aspx?valor=" + Valor + "&Ubicac=" + Ubicac);
            }
            catch (Exception ex) { 

            }
        }
    }
}