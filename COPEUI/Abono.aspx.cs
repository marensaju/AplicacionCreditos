using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace COPEUI
{
    public partial class Abono : System.Web.UI.Page
    {
        Abonosos abo = new Abonosos();
        ModificacionesPretamos presta = new ModificacionesPretamos();
       
        protected void Page_Load(object sender, EventArgs e)
        {
          string valor3 = Request.QueryString["Valor3"];
                int idprestamo = Convert.ToInt32(valor3);   
            TextOB.Visible = false;
            Button2.Visible = false;

            if (abo.LISTAABONOS(idprestamo).Rows.Count > 0)
            {
                GridView1.DataSource = abo.LISTAABONOS(idprestamo);
                GridView1.DataBind();
            }
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //se realizan los pagos y abono

            try {

                string valor3 = Request.QueryString["Valor3"];
                int idprestamo = Convert.ToInt32(valor3);             
                int codigo = Convert.ToInt32(Session["idempleado"]);
                int inicio = Convert.ToInt32(abo.IDPAGOSINICIOABONO(idprestamo).Rows[0][0].ToString());
                string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime fecha = Convert.ToDateTime(fecha1);
                //aqui se registra el abono
                abo.RegistrarAbono(Convert.ToDecimal(Label3.Text),TextOB.Text,idprestamo);
                //aqui se modifican los pagos
                for (int k = inicio; k <inicio+Convert.ToInt32(Label4.Text); k++)
                {
                    presta.RealizarPago(k, true, fecha, codigo, true);

                }
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Abono", "Abono de: " + TextMonto.Text + " a prestamo: " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                TextOB.Visible = false;
                Button2.Visible = false;
                // Label1.Text = "";
                Label2.Text = "";

                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
            }
            catch (Exception pp) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }

            

 
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string valor3 = Request.QueryString["Valor3"];
            int idprestamo = Convert.ToInt32(valor3);

            try {

                string veri=abo.ConocerSiPuedeAbonar(idprestamo).Rows[0][0].ToString();
                string RARA = abo.ConocerSiPuedeAbonar(idprestamo).Rows[0][1].ToString();
                decimal Saldo = Convert.ToDecimal(RARA);
                


                if(veri!="0")
                {
                    if(Convert.ToDecimal(TextMonto.Text)<=Saldo)
                    {

                        //esto para calcular los pagos
                        //numero de prestamo
                        
                        int Canti = Convert.ToInt32(abo.CantiPagosAbonosFOr(idprestamo).Rows[0][0].ToString());
                        List<Decimal> pagitos = new List<Decimal>();

                        for (int i = 0; i < Canti; i++)
                        {

                            pagitos.Add(Convert.ToDecimal(abo.ListaPagosPendientes(idprestamo).Rows[i][0].ToString()));

                        }
                        //monto
                        Decimal Cantidad = Convert.ToDecimal(TextMonto.Text);
                        int cont = 0;
                        Decimal suma = 0;

                        List<Decimal> pagitos2 = new List<Decimal>();

                        //suma para calcular cuantos pagos se pueden hacer
                        for (int j = 0; j < Canti; j++)
                        {


                            suma = suma + pagitos[j];

                            if (suma <= Cantidad)
                            {
                                pagitos2.Add(suma);
                                cont = cont + 1;
                            }

                        }


                        if (cont > 0)
                        {
                            Label1.Text = "No. Pagos Posibles:" + Convert.ToString(cont);

                            Label2.Text = "Monto aceptable:" + pagitos2.Last().ToString();

                           Label3.Text= pagitos2.Last().ToString();
                            Label4.Text = cont.ToString();
                            TextOB.Visible = true;
                            Button2.Visible = true;

                        }
                        else
                        {

                            Label1.Text = "Monto debe ser mayor para poder efectuar pagos";
                        }






                        
                    }
                }

                
            
            
            
           }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }


        }
    }
}