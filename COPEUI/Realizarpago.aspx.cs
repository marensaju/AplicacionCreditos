using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class Realizarpago : System.Web.UI.Page
    {
        Pagos p = new Pagos();
        ModificacionesPretamos presta = new ModificacionesPretamos();
        Ripo r = new Ripo();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][0].ToString() == "True")
            {
                if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][3].ToString() == "True")
                {
                    Button1.Visible = true;
                }
                else {
                    Button1.Visible = false;
                    TextPago.Visible = false;
                }
            }
            else { Response.Redirect("Inicio.aspx"); }


            try {
                string valor2 = Request.QueryString["Valor"];
                int idprestamo = Convert.ToInt32(valor2);
                GridView1.DataSource = p.PagosConMora(idprestamo);
                GridView1.DataBind();
            }
            catch(Exception ex) { 
            }
           



        }

        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string valor2 = Request.QueryString["Valor"];
                int idprestamo = Convert.ToInt32(valor2);
                //
                int idpago = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                bool pagito = true;
                int codigo = Convert.ToInt32(Session["idempleado"]);
                string fecha1 = DateTime.Now.ToString("G");
                DateTime fecha = Convert.ToDateTime(fecha1);
                //verificar si es el ultimopago
                if (p.LIstadoPagosFUll(idprestamo).Rows.Count == 1)
                {

                    p.FinalizarPrestamo(idprestamo);



                }
                presta.RealizarPago(idpago, pagito, fecha, codigo, true);
              
                //actualizo el grid
               
                GridView1.DataSource = p.PagosConMora(idprestamo);
                GridView1.DataBind();
                //bitacora
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Pagar", "pago de cuota prestamo No. " + Convert.ToString(idprestamo) + ", idpago" + Convert.ToString(idpago), Convert.ToInt32(Session["idempleado"]));


                /* actualizar reportes*/

                int prestamo = Convert.ToInt32(r.SaberIDPrestamo(idpago).Rows[0][0].ToString());
               
   
                if (r.InfoReporte(prestamo).Rows.Count != 0)
                {
                    int PagosAtrasados = Convert.ToInt32(r.InfoReporte(prestamo).Rows[0][0].ToString());
                    Decimal MontoAtrasado = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][1].ToString());
                    Decimal Morita = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][2].ToString());
                    Decimal MontoAtrasadoMasMora = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][3].ToString());

                    Decimal SaldoTotal = Convert.ToDecimal(r.SaldoTotal(prestamo).Rows[0][0].ToString());
                    Decimal SaldoTotalMasMora = SaldoTotal + Morita;
                    r.ModificarAgregarReporte(PagosAtrasados, MontoAtrasado, Morita, MontoAtrasadoMasMora, SaldoTotalMasMora, prestamo);
                }
                
                    
                

                /*fin de actualizarrepoertes*/

                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string valor2 = Request.QueryString["Valor"];
                int idprestamo = Convert.ToInt32(valor2);
              
                //omitir mora y pagar
                int agencia2 = Convert.ToInt32(Session["idagencia"]);
                int idpago = Convert.ToInt32(TextPago.Text);
                bool pagito = true;
                int codigo = Convert.ToInt32(Session["idempleado"]);
                string fecha1 = DateTime.Now.ToString("G");
                DateTime fecha = Convert.ToDateTime(fecha1);
                //verificar si es el ultimopago
                if (p.LIstadoPagosFUll(idprestamo).Rows.Count == 1)
                {

                    p.FinalizarPrestamo(idprestamo);



                }

                p.OmitirMora(idpago, pagito, fecha, codigo, true);


                

                //actualizo el grid
                GridView1.DataSource = p.PagosConMora(idprestamo);
                GridView1.DataBind();

                //bitacora
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Pagar ", "Omitir Mora y pagar No prestamo." + Convert.ToString(idprestamo)+", id pago: "+Convert.ToString(idpago), Convert.ToInt32(Session["idempleado"]));
                 
                /* actualizar reportes*/

                int prestamo = Convert.ToInt32(r.SaberIDPrestamo(idpago).Rows[0][0].ToString());
                if (r.InfoReporte(prestamo).Rows.Count != 0)
                {
                    int PagosAtrasados = Convert.ToInt32(r.InfoReporte(prestamo).Rows[0][0].ToString());
                    Decimal MontoAtrasado = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][1].ToString());
                    Decimal Morita = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][2].ToString());
                    Decimal MontoAtrasadoMasMora = Convert.ToDecimal(r.InfoReporte(prestamo).Rows[0][3].ToString());

                    Decimal SaldoTotal = Convert.ToDecimal(r.SaldoTotal(prestamo).Rows[0][0].ToString());
                    Decimal SaldoTotalMasMora = SaldoTotal + Morita;
                    r.ModificarAgregarReporte(PagosAtrasados, MontoAtrasado, Morita, MontoAtrasadoMasMora, SaldoTotalMasMora, prestamo);
                }
                
                /*fin de actualizarrepoertes*/
                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true); 


          }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
 
            }
        }
    }
}