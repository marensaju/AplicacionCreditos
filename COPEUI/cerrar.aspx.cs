using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Cerrar sesion", "Empleado cerro sesion", Convert.ToInt32(Session["idempleado"]));
                Session.Remove("cool");
                Response.Redirect("index.aspx");
                string usuario = Session["cool"].ToString();
              

            }
            catch (Exception ex)
            {
                Response.Redirect("index.aspx");

            }
        }
    }
}