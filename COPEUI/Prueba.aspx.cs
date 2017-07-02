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
    public partial class Prueba : System.Web.UI.Page
    {
        PrestamosTodo presta = new PrestamosTodo(); 
        ReportePaginaInicio repo = new ReportePaginaInicio();
        IngresosPrestamos ingresp = new IngresosPrestamos();
        Conversion c = new Conversion();
        Abonosos abo = new Abonosos();

        protected void Page_Load(object sender, EventArgs e)
        {
            //int dias3 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString());
            
            


           /* //numero de prestamo
            int prestamo = 2156;
            int Canti = Convert.ToInt32(abo.CantiPagosAbonosFOr(prestamo).Rows[0][0].ToString());
            List<Decimal> pagitos = new List<Decimal>();
           
            for (int i = 0; i < Canti; i++) 
            {

                pagitos.Add( Convert.ToDecimal(abo.ListaPagosPendientes(prestamo).Rows[i][0].ToString()));
            
            }
            //monto
            Decimal Cantidad= 121;
            int cont = 0;
            Decimal suma = 0;

            List<Decimal> pagitos2 = new List<Decimal>();
            

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


            }
            else {

                Label1.Text = "Monto debe ser mayor para poder efectuar pagos";
            }
           


           GridView1.DataSource = pagitos;
            GridView1.DataBind();

            GridView2.DataSource = pagitos2;
            GridView2.DataBind();
            
            
            /*
            GridView1.DataSource = presta.INFOPARACONTRATO(2147);
            GridView1.DataBind();
            
            string NombreCliente = presta.INFOPARACONTRATO(2147).Rows[0][0].ToString();
            string edad = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][1].ToString()).ToLower();
            string EstadoCivil = presta.INFOPARACONTRATO(2147).Rows[0][2].ToString();
            string Profesion = presta.INFOPARACONTRATO(2147).Rows[0][3].ToString();
            string DireccionCli = presta.INFOPARACONTRATO(2147).Rows[0][4].ToString();
            string Parte1DPI = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][5].ToString().Substring(0, 4)).ToLower();
            string Parte2DPI = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][5].ToString().Substring(4, 5)).ToLower();
            string Parte3DPI = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][5].ToString().Substring(9, 1)).ToLower();
            string Parte4DPI = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][5].ToString().Substring(10, 3)).ToLower();
            string DPI=Parte1DPI + ", " + Parte2DPI + ", " + Parte3DPI+", "+Parte4DPI+ " ("+presta.INFOPARACONTRATO(2147).Rows[0][5].ToString() +")" ;
            string MontoPresta = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][6].ToString()) + " QUETZALES" + " ( Q."+ presta.INFOPARACONTRATO(2147).Rows[0][6].ToString() + ")" ;
            string PeriodoContra = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][7].ToString()).ToLower();
            Decimal Prueba=Convert.ToDecimal(presta.INFOPARACONTRATO(2147).Rows[0][8].ToString());
            string CuotaContra = c.enletras(Convert.ToString(Math.Round(Prueba, 0)))+ " QUETZALES" +" (Q."+Convert.ToString(Math.Round(Prueba, 0))+")";
            string MoraContra = c.enletras(presta.INFOPARACONTRATO(2147).Rows[0][9].ToString()) + " QUETZALES" + " (Q." + presta.INFOPARACONTRATO(2147).Rows[0][9].ToString() + ")";
            string SemanasDias = presta.INFOPARACONTRATO(2147).Rows[0][10].ToString();
            string DirAgencia = presta.INFOPARACONTRATO(2147).Rows[0][11].ToString();
            string Nacionalidad = presta.INFOPARACONTRATO(2147).Rows[0][12].ToString();

            string Parte1FI = c.enletras(presta.FechaInicialYFinal(2147).Rows[0][0].ToString().Substring(0, 2)).ToLower();
            string Parte2FI = presta.FechaInicialYFinal(2147).Rows[0][0].ToString().Substring(3, 2);
            string Parte3FI = c.enletras(presta.FechaInicialYFinal(2147).Rows[0][0].ToString().Substring(6, 4)).ToLower();
            string mes = "mes";
            if (Parte2FI == "01")
            {
                 mes = "enero";
            }
            else if (Parte2FI == "02")
            {
                mes = "febrero";
            }
            else if (Parte2FI == "03")
            {
                mes = "marzo";
            }
            else if (Parte2FI == "04")
            {
               mes = "abril";
            }
            else if (Parte2FI == "05")
            {
                mes = "mayo";
            }
            else if (Parte2FI == "06")
            {
                 mes = "junio";
            }
            else if (Parte2FI == "07")
            {
                 mes = "julio";
            }
            else if (Parte2FI == "08")
            {
                 mes = "agosto";
            }
            else if (Parte2FI == "09")
            {
                 mes = "septiembre";
            }
            else if (Parte2FI == "10")
            {
                 mes = "octubre";
            }
            else if (Parte2FI == "11")
            {
                 mes = "noviembre";
            }
            else if (Parte2FI == "12")
            {
                mes = "diciembre";
            }

            string FechaInicialContra=Parte1FI +" de "+mes+" de " +Parte3FI;

            //fecha final
            string Parte1FF = c.enletras(presta.FechaInicialYFinal(2147).Rows[0][1].ToString().Substring(0, 2)).ToLower();
            string Parte2FF = presta.FechaInicialYFinal(2147).Rows[0][1].ToString().Substring(3, 2);
            string Parte3FF = c.enletras(presta.FechaInicialYFinal(2147).Rows[0][1].ToString().Substring(6, 4)).ToLower();
            string mes2 = "mes";
            if (Parte2FF == "01")
            {
                mes2 = "enero";
            }
            else if (Parte2FF == "02")
            {
                mes2 = "febrero";
            }
            else if (Parte2FF == "03")
            {
                mes2 = "marzo";
            }
            else if (Parte2FF == "04")
            {
                mes2 = "abril";
            }
            else if (Parte2FF == "05")
            {
                mes2 = "mayo";
            }
            else if (Parte2FF == "06")
            {
                mes2 = "junio";
            }
            else if (Parte2FF == "07")
            {
                mes2 = "julio";
            }
            else if (Parte2FF == "08")
            {
                mes2 = "agosto";
            }
            else if (Parte2FF == "09")
            {
                mes2 = "septiembre";
            }
            else if (Parte2FF == "10")
            {
                mes2 = "octubre";
            }
            else if (Parte2FF == "11")
            {
                mes2 = "noviembre";
            }
            else if (Parte2FF == "12")
            {
                mes2 = "diciembre";
            }

            string FechaFinallContra = Parte1FF + " de " + mes2 + " de " + Parte3FF;

            string GarantiasCon="";
            if (presta.GarantiasContrato(2147).Rows.Count==1 )
            {
                 GarantiasCon = presta.GarantiasContrato(2147).Rows[0][0].ToString();

            }
            else if (presta.GarantiasContrato(2147).Rows.Count == 2)
            {
               GarantiasCon = presta.GarantiasContrato(2147).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(2147).Rows[1][0].ToString();
            }
            else if (presta.GarantiasContrato(2147).Rows.Count == 3)
            {
                GarantiasCon = presta.GarantiasContrato(2147).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(2147).Rows[1][0].ToString() + "; " + presta.GarantiasContrato(2147).Rows[2][0].ToString();
            }



            presta.CrearContrato(NombreCliente, edad, EstadoCivil, Profesion, DireccionCli, DPI, MontoPresta, PeriodoContra, CuotaContra,FechaInicialContra, FechaFinallContra, MoraContra,SemanasDias, GarantiasCon, DirAgencia, true, Nacionalidad, 2147);

            


            Label2.Text = GarantiasCon ;*/
            /*
            string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime fecha = Convert.ToDateTime(fecha1);
            string verificar = repo.NumeroPagosAtrasados(fecha).Rows[0][0].ToString();
            int numero = Convert.ToInt32(verificar);
           
            if (numero > 0)
            {
                List<Int32> IDPAGO = new List<Int32>();
                List<Decimal> MORAPAGO = new List<Decimal>();
                List<String> FinesSemana = new List<String>();
                List<String> FechasFeriado = new List<String>();
                List<DateTime> Feriados=new List<DateTime>();

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
                            Cant =Cant + 1;
                        }

                        Ini = Ini.AddDays(1);

                    }


                    FinesSemana.Add(Convert.ToString(Cant));      
                    
                }

              
            }

           */
           


        /* //pago cuando son dias

            DateTime fechaInicial1 = fecha;
            DateTime fechaInicial = fechaInicial1.AddDays(1);

            List<DateTime> fechasList = new List<DateTime>();

            DateTime fechaTemp = fechaInicial;
            int feriados = Convert.ToInt32(presta.CantidadDiasFeriados(fecha).Rows[0][0].ToString());
            int DD2 = Convert.ToInt32(presta.InfoPlan(0).Rows[0][1].ToString());
            int CantidadDatosFeriado = feriados;
            int k = 0;
            int dias = DD2;
            for (int i = 0; i <= dias; i++)
            {
                fechaTemp = fechaInicial.AddDays(i);
                fechasList.Add(fechaTemp);
                Label1.Text = Convert.ToString(fechasList.Last());

                //ciclo para recorrer lista y comprobar si es domingo
                for (int j = 0; j < fechasList.Count; j++)
                {
                    ///si es domingo
                    if (fechasList[j].DayOfWeek == DayOfWeek.Sunday)
                    {

                        k++;
                        Label2.Text = Convert.ToString(k);
                        fechasList.RemoveAt(j);
                       
                       //fechasferiad
                        for (int c = 0; c < fechasList.Count; c++)
                        {
                            for (int m = 0; m < 2; m++)
                            {
                                if (fechasList[c] == Convert.ToDateTime(presta.FechasFeriado(fechaInicial1).Rows[m][0].ToString()))
                                {
                                    k++;
                                    Label2.Text = Convert.ToString(k);
                                    fechasList.RemoveAt(c);
                                   
                                }
                            }
                        }
                        //finfechasferiado
                    } //fin si es domingo


                }

            }
            //comprobar que k sea mayor a 0 para aumentar dias
            int comprobar = Convert.ToInt32(Label2.Text);
            DateTime fechaprueba = Convert.ToDateTime(Label1.Text);
            if (comprobar > 0)
            {
                fechaInicial = fechaprueba;
                for (int t = 1; t <= comprobar; t++)
                {
                    fechaTemp = fechaInicial.AddDays(t);
                    fechasList.Add(fechaTemp);
                }

            }
            //comprobar dias agregados si son domingos o feriados
            for (int j = 0; j < fechasList.Count; j++)
            {
                ///si es domingo
                if (fechasList[j].DayOfWeek == DayOfWeek.Sunday)
                {
                    Label1.Text = Convert.ToString(fechasList.Last());
                    k++;
                    Label2.Text = Convert.ToString(k);
                    fechasList.RemoveAt(j);
                    fechaInicial = Convert.ToDateTime(Label1.Text);
                    fechaTemp = fechaInicial.AddDays(1);
                    fechasList.Add(fechaTemp);
                   
                }

                for (int m = 0; m < 2; m++)
                {
                    if (fechasList[j] == Convert.ToDateTime(presta.FechasFeriado(fechaInicial1).Rows[m][0].ToString()))
                    {
                        Label1.Text = Convert.ToString(fechasList.Last());
                        k++;
                        Label2.Text = Convert.ToString(k);
                        fechasList.RemoveAt(j);
                        fechaInicial = Convert.ToDateTime(Label1.Text);
                        fechaTemp = fechaInicial.AddDays(1);
                        fechasList.Add(fechaTemp);
                    }
                }
               
                    
            }

           
                    //finpagos cuando son dias


            */
            
            

           

            

           /* List<DateTime> listaDiasFestivos = ListDiasFectivos();

            while (Ini != Fin)
            {
                if (!listaDiasFestivos.Contains(Ini))
                {
                    Cant = Cant + 1;
                }
                Ini = Ini.AddDays(1);
            }*/
        }

       
       
 
    }
}