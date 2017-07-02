using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        ReportePaginaInicio repo = new ReportePaginaInicio();
        protected void Page_Load(object sender, EventArgs e)
        {
          try
            {
                string usuario = Session["cool"].ToString();
                int emplea = Convert.ToInt32(Session["idempleado"]);
                Label1.Text=repo.PerfilInicio(emplea).Rows[0][0].ToString();
                Label2.Text = repo.PerfilInicio(emplea).Rows[0][1].ToString();
                Image1.ImageUrl = "~/ImagenesCargadas/Empleados/" + repo.PerfilInicio(emplea).Rows[0][2].ToString();
                 string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
               DateTime fecha = Convert.ToDateTime(fecha1);

               Label3.Text = "Fecha actual: "+fecha1;

               int agencia = Convert.ToInt32(Session["idagencia"]);
               Label4.Text = repo.TotalPOrAprobar(agencia).Rows[0][0].ToString();
               Label5.Text = repo.TotalPorDesembolso(agencia).Rows[0][0].ToString();
            }
            catch(Exception ex) {
                Response.Redirect("index.aspx");

            }
          
            
        }
    }
}