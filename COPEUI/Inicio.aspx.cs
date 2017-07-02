using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace COPEUI
{
    public partial class Inicio : System.Web.UI.Page
    {
        ReportePaginaInicio repo = new ReportePaginaInicio();
        ModificacionesPretamos presta = new ModificacionesPretamos();
        Ripo r = new Ripo();
        Permisos permiso = new Permisos();
        Pagos p = new Pagos();
        protected void Page_Load(object sender, EventArgs e)
        {
           try
            {
                string usuario = Session["cool"].ToString();
                int agencia2 = Convert.ToInt32(Session["idagencia"]);
                string veri = repo.CantidadPagos(agencia2).Rows[0][0].ToString();
                Label2.Visible = false;
                //Label2.Text = agencia2.ToString();
              



                //sumar capital
                string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
               DateTime fecha = Convert.ToDateTime(fecha1);

               if (repo.CapitalRecaudadoHOy(fecha, agencia2).Rows.Count == 0)
               {
                   Label3.Text = "Q.0.00";
               }else{
                    int Capio= 0;
                    foreach (DataRow dr in repo.CapitalRecaudadoHOy(fecha, agencia2).Rows)
            {
                    Capio += Convert.ToInt32(dr[0]);
            }
            Label3.Text =  "Q."+Convert.ToString(Capio);
               }
                //mora
               if (repo.InteresesRecaudadosHoy(fecha, agencia2).Rows.Count == 0)
               {
                   Label4.Text = "Q.0.00";
               }
               else {

                   int Inter = 0;
                   foreach (DataRow dr in repo.InteresesRecaudadosHoy(fecha, agencia2).Rows)
                   {
                       Inter += Convert.ToInt32(dr[0]);
                   }
                   Label4.Text = "Q." + Convert.ToString(Inter);
               }
               
                //mostrar morarecaudada
               if (repo.MoraRecaudadaHoy(fecha, agencia2).Rows.Count == 0)
               {
                   Label5.Text = "Q.0.00";
                   
               }
               else {
                   Label5.Text = "Q." + repo.MoraRecaudadaHoy(fecha, agencia2).Rows[0][0].ToString();
                  
               }
                //mostrar totalrecaudado
               if (repo.TotalEfectivoHoy(fecha, agencia2).Rows.Count == 0)
               {
                   Label6.Text = "Q.0.00";
                   Label7.Text = "Q.0.00";
               }
               else {
                   Label6.Text = "Q." + repo.TotalEfectivoHoy(fecha, agencia2).Rows[0][0].ToString();
                   Label7.Text = "Q." + repo.TotalEfectivoHoy(fecha, agencia2).Rows[0][0].ToString();
               }
                //clientes activos
               if (repo.ClientesActivos(agencia2).Rows.Count == 0)
               {
                   Label8.Text = "0";
               }
               else {
                   Label8.Text = repo.ClientesActivos(agencia2).Rows[0][0].ToString();
               }
                //prestamos activos
               if (repo.PrestamosActivos(agencia2).Rows.Count == 0)
               {
                   Label9.Text = "0";
               }
               else
               {
                   Label9.Text = repo.PrestamosActivos(agencia2).Rows[0][0].ToString();
               }

                //resumen semanal
               int ini = 0;
               int fina = 0;
               if (fecha.DayOfWeek == DayOfWeek.Monday)
               {
                    ini = fecha.Day;
                    fina = fecha.Day + 6;

               }
               else if (fecha.DayOfWeek == DayOfWeek.Tuesday)
               {
                    ini = fecha.Day-1;
                    fina = fecha.Day + 5;

               }
               else if (fecha.DayOfWeek == DayOfWeek.Wednesday)
               {
                    ini = fecha.Day - 2;
                    fina = fecha.Day + 4;
               }
               else if (fecha.DayOfWeek == DayOfWeek.Thursday)
               {
                    ini = fecha.Day - 3;
                    fina = fecha.Day + 3;
               }
               else if (fecha.DayOfWeek == DayOfWeek.Friday)
               {
                    ini = fecha.Day - 3;
                    fina = fecha.Day + 2;
               }
               else if (fecha.DayOfWeek == DayOfWeek.Saturday)
               {
                    ini = fecha.Day - 4;
                    fina = fecha.Day + 1;
               }
               else if (fecha.DayOfWeek == DayOfWeek.Sunday)
               {
                    ini = fecha.Day - 5;
                    fina = fecha.Day ;
               }
                DateTime fi1 = new DateTime(fecha.Year, fecha.Month, ini);
                
            int fin1=DateTime.DaysInMonth(fecha.Year,fecha.Month);
            if (fina > fin1)
            {
                int mes = fecha.Month + 1;
                if (mes > 12)
                {
                    mes = 1;
                }
                int fina2 = fina - fin1;
                
                DateTime ff2 = new DateTime(fecha.Year, mes, fina2);
                if (repo.CalculoTotalPOrFechas(fi1, ff2, agencia2).Rows.Count == 0)
                {
                    Label11.Text = "Q.00";
                }
                else
                {
                    Label11.Text = "Q." + repo.CalculoTotalPOrFechas(fi1, ff2, agencia2).Rows[0][0].ToString();

                }


            }
            else {
                DateTime ff2 = new DateTime(fecha.Year, fecha.Month, fina);
                if (repo.CalculoTotalPOrFechas(fi1, ff2, agencia2).Rows.Count == 0)
                {
                    Label11.Text = "Q.00";
                }
                else
                {
                    Label11.Text = "Q." + repo.CalculoTotalPOrFechas(fi1, ff2, agencia2).Rows[0][0].ToString();

                }

 
            }
             

             



           

                //resumen mensual
               
                int fin=DateTime.DaysInMonth(fecha.Year,fecha.Month);
                int inicio=1;
                DateTime fi = new DateTime(fecha.Year,fecha.Month,inicio);
                DateTime ff = new DateTime(fecha.Year, fecha.Month, fin);
                if (repo.CalculoTotalPOrFechas(fi,ff,agencia2).Rows.Count == 0)
                {
                    Label10.Text = "Q.00";
                }
                else {
                    Label10.Text = "Q."+repo.CalculoTotalPOrFechas(fi, ff, agencia2).Rows[0][0].ToString();
 
                }



               if (veri=="0")
                {
                    Label1.Visible = true;
                }
                else {

                   //verificar si el usuario tiene permisos para registrar pagos
                    if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][0].ToString() == "True")
                   {
                       GridView2.DataSource = repo.PaganHoy(agencia2);
                       GridView2.Columns[0].Visible = false;
                       GridView2.Columns[1].Visible = false;
                       GridView2.DataBind();

                   }
                   
                   
                }
              //verificacion para agregar mora a pagos
              
               string verificar = repo.NumeroPagosAtrasados(fecha).Rows[0][0].ToString();
               int numero = Convert.ToInt32(verificar);

               if (numero > 0)
               {
                   List<Int32> IDPAGO = new List<Int32>();
                   List<Decimal> MORAPAGO = new List<Decimal>();
                   List<String> FinesSemana = new List<String>();
                   List<String> FechasFeriado = new List<String>();
                   List<DateTime> Feriados = new List<DateTime>();

                   ///Agregar los feriados a una lista
                   DateTime f1 = Convert.ToDateTime(repo.LIstadoFechasPagosAtrasados(fecha).Rows[0][0].ToString());
                   int cantidadf = Convert.ToInt32(repo.CantidadFeriadosMora(f1, fecha).Rows[0][0].ToString());
                   for (int m = 0; m < cantidadf; m++)
                   {

                       Feriados.Add(Convert.ToDateTime(repo.ListaFeriado(f1, fecha).Rows[m][0].ToString()));
                   }
                   //aqui lista excluyendo dias de feriado
                   for (int j = 0; j <= numero - 1; j++)
                   {
                       int Cant2 = 0;
                       DateTime Ini = Convert.ToDateTime(repo.LIstadoFechasPagosAtrasados(fecha).Rows[j][0].ToString());

                       System.DateTime Fin = fecha;
                       while (Ini != Fin)
                       {
                           if (!Feriados.Contains(Ini))
                           {
                               Cant2 = Cant2 + 1;
                           }
                           Ini = Ini.AddDays(1);

                       }
                       FechasFeriado.Add(Convert.ToString(Cant2));
                   }

                   for (int i = 0; i <= numero - 1; i++)
                   {

                       IDPAGO.Add(Convert.ToInt32(repo.NumeroPagosAtradasoIDPago(fecha).Rows[i][0].ToString()));
                       MORAPAGO.Add(Convert.ToDecimal(repo.CantidadMoraPagosAtrasados(fecha).Rows[i][0].ToString()));

                       int Cant = 0;
                       DateTime Ini = Convert.ToDateTime(repo.LIstadoFechasPagosAtrasados(fecha).Rows[i][0].ToString());
                       System.DateTime Fin = fecha;


                       //cuento cuantos domingos hay en un rango de fechas
                       while (Ini != Fin)
                       {

                           if (Ini.DayOfWeek == DayOfWeek.Sunday)
                           {
                               Cant = Cant + 1;
                           }

                           Ini = Ini.AddDays(1);

                       }


                       FinesSemana.Add(Convert.ToString(Cant));

                   }

                   for (int C = 0; C <= numero - 1; C++)
                   {
                       repo.AgregarCantidaMora(IDPAGO[C], (MORAPAGO[C] *(Convert.ToInt32(FechasFeriado[C]) - Convert.ToInt32(FinesSemana[C]))), false);
                   }
               }
          

                  
               


                
                ///fin de verificacion de pagos mora
               

               
            }
            catch (Exception ex)
            {
               // Response.Redirect("index.aspx");

            }
        }

        
        protected void svpagos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int agencia2 = Convert.ToInt32(Session["idagencia"]);
                    int idpago = Convert.ToInt32(GridView2.DataKeys[e.NewSelectedIndex].Value);
                    bool pagito = true;
                    int codigo = Convert.ToInt32(Session["idempleado"]);
                    string fecha1 = DateTime.Now.ToString("G");
                   DateTime fecha = Convert.ToDateTime(fecha1);
                //si el pago es el ultimo
                   int idprestamo=Convert.ToInt32(p.IDPRESTAMO(idpago).Rows[0][0].ToString());
                   if (p.LIstadoPagosFUll(idprestamo).Rows.Count == 1)
                   {

                       p.FinalizarPrestamo(idprestamo);

                   }
                //realizar el pago
                    presta.RealizarPago(idpago, pagito,fecha,codigo,true);
                    GridView2.DataSource = repo.PaganHoy(agencia2);
                    GridView2.DataBind();
                    Bitacora bita = new Bitacora();
                    bita.RegistrarBitacora("Pago", "Pago de cuota de pago id" + Convert.ToString(idpago), Convert.ToInt32(Session["idempleado"]));

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
            catch (Exception ex){

                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }
            

        }


        
    }
}