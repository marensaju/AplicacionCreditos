using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data;
using COPEUI.ReportesCopeTableAdapters;
using BLL;
namespace COPEUI
{
    public partial class InfroPrestamo : System.Web.UI.Page
    {

        PrestamosTodo presta = new PrestamosTodo();
        VerClientes ver = new VerClientes();
        Ripo r = new Ripo();
        IngresosPrestamos ingreso = new IngresosPrestamos();
        Conversion ca = new Conversion();
        Permisos permiso = new Permisos();
        Abonosos abo = new Abonosos();

        
        //funcion para llenar el tab de arriba
        private void llenar()
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            string tipopre = presta.InfoTabUNO(idprestamo).Rows[0][0].ToString();
            string desembolso = presta.InfoTabUNO(idprestamo).Rows[0][1].ToString();
            LabelNombre.Text = presta.InfoTabUNO(idprestamo).Rows[0][2].ToString();
            LabeDireccion.Text = presta.InfoTabUNO(idprestamo).Rows[0][3].ToString();
            LabelMunicipio.Text = presta.InfoTabUNO(idprestamo).Rows[0][4].ToString();
            LabelCiudad.Text = presta.InfoTabUNO(idprestamo).Rows[0][5].ToString();
            LabelSaldoPendiente.Text = presta.InfoTabUNO(idprestamo).Rows[0][6].ToString();
            LabelDeudaTotal.Text = presta.InfoTabUNO(idprestamo).Rows[0][6].ToString();
            LabelDesembolso.Text = presta.InfoTabUNO(idprestamo).Rows[0][7].ToString(); 
            LabelNoCuotas.Text = presta.InfoTabUNO(idprestamo).Rows[0][8].ToString();
            LabelObservaciones.Text = presta.InfoTabUNO(idprestamo).Rows[0][9].ToString();
            LabelAbono.Text = "Q.0.00";
            LabelAbonoCapital.Text = "-----";
            LabelCuotasPendientes.Text = presta.InfoTabUNO(idprestamo).Rows[0][8].ToString();
            LabelGestor.Text = presta.InfoTabUNO(idprestamo).Rows[0][10].ToString();
            LabelSaldo.Text = presta.InfoTabUNO(idprestamo).Rows[0][6].ToString();
            LabelSaldoCapital.Text = presta.InfoTabUNO(idprestamo).Rows[0][7].ToString();
            LabelFechaPago.Text = "---------";
            LabelAgencia.Text = presta.InfoTabUNO(idprestamo).Rows[0][11].ToString();
            Image1.ImageUrl = "~/ImagenesCargadas/Clientes/" + presta.InfoTabUNO(idprestamo).Rows[0][12].ToString();
 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //comprobar permiso para ver toda la info
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][5].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            //permiso para anular pagos
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][2].ToString() == "False")
            {
                GridView4.Visible = false;
                Label3.Visible = false;
                Button8.Visible = false;

            }
            else {
                GridView4.Visible = true;
                Label3.Visible = true;
                Button8.Visible = true;
            }
            //fin de permiso para anular pagos

            //permiso para cancelar solicitud
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][6].ToString() == "False")
            {
                Button2.Visible = false;
            }

            //fin de permiso

            //permiso para precalificar
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][7].ToString() == "False")
            {
                Button1.Visible = false;
            }
            //permiso para aprobar prestamo
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][6].ToString() == "False")
            {
                Button2.Visible = false;
            }

            //permiso para ver garatias
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][10].ToString() == "False")
            {
                GridView2.Visible = false;
            }
            //genrar cheque
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][10].ToString() == "False")
            {
                Button7.Visible = false;
                //permiso para genrar abonos si puede genrar cheque tambien abonos
                Button9.Visible = false;
            }
            Button5.Visible = false;
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            string tipopre=presta.InfoTabUNO(idprestamo).Rows[0][0].ToString();
            string desembolso=presta.InfoTabUNO(idprestamo).Rows[0][1].ToString();
           
            //Precalificar
            if (tipopre== "False" && desembolso=="False")
            {
                
                Button1.Text = "Precalificar préstamo";
                DivHistoPagos.Visible = false;
                InformaPagos.Visible = true;
                ContratoAviso.Visible = true;
                llenar();

            }
            //desembolsar
            if (tipopre == "True" && desembolso == "False")
            {
                //permiso para desembolsar
                if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][9].ToString() == "False")
                {
                    Button1.Visible = false;
                }
                Button1.Text = "Realizar desembolso";
                DivHistoPagos.Visible = false;
                InformaPagos.Visible = true;
                ContratoAviso.Visible = true;
                llenar();

            }

            if (tipopre == "True" && desembolso == "True")
            {
                DivHistoPagos.Visible = true;
                InformaPagos.Visible = false;
                ContratoAviso.Visible =  false;
                contra.Visible = true;
                if (!IsPostBack)
                {
                    InfoFULLContratoTableAdapter con = new InfoFULLContratoTableAdapter ();
                   
                    DataTable tabla = con.GetDataInfoFullContrato (idprestamo);
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportContrato.rdlc");
                    ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(fuente);

                    ReportViewer1.LocalReport.Refresh();
                }


                llenar();
                LabelCuotasPendientes.Text = r.CuotasPendientesInfoPresta(idprestamo).Rows[0][0].ToString();
                
                string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
               // DateTime fecha = DateTime.ParseExact(fecha1, "dd/MM/yyyy", null);
                DateTime fecha = Convert.ToDateTime(fecha1);
                if (r.ProximaFechaInfoPResta(fecha,idprestamo).Rows.Count != 0)
                {
                    LabelFechaPago.Text = r.ProximaFechaInfoPResta(fecha, idprestamo).Rows[0][0].ToString();
                }
                if (r.SaldoTotalInfoPresta(idprestamo).Rows.Count != 0)
                {
                    LabelSaldoPendiente.Text = r.SaldoTotalInfoPresta(idprestamo).Rows[0][0].ToString();
                    LabelSaldo.Text = r.SaldoTotalInfoPresta(idprestamo).Rows[0][0].ToString();
                }
                if (r.SaldoCapitalInfoPresta(idprestamo).Rows.Count != 0)
                {
                    LabelSaldoCapital.Text = r.SaldoCapitalInfoPresta(idprestamo).Rows[0][0].ToString();
                }

                if (abo.InfoAbono(idprestamo).Rows.Count != 0)
                {
                    LabelAbono.Text = abo.InfoAbono(idprestamo).Rows[0][0].ToString();
                }
                else { LabelAbono.Text = "Q.00"; }
                Button2.Visible = false;
                Button1.Visible = false;
                GridView3.DataSource = presta.TablaPagosTab(idprestamo);
                GridView3.DataBind();
                Button5.Visible = true;
                Button6.Visible = true;
                Button7.Visible = true;
                Button9.Visible = true;
                GridView4.DataSource = presta.TabPagosEfectuados(idprestamo);
                GridView4.Columns[0].Visible = false;
                GridView4.DataBind();
                if (presta.TOTAlPagosTab4(idprestamo).Rows[0][0].ToString() != "0")
                {
                    Label3.Visible = true;
                    textoc.Visible = true;
                   Label3.Text = "Q. " + presta.TOTAlPagosTab4(idprestamo).Rows[0][0].ToString();
                   Button8.Visible = true;
 
                }
                


 
            }

            //infotab2
            LabelNombreTab2.Text = presta.InfoTab2(idprestamo).Rows[0][0].ToString();
            LabelCuI.Text = presta.InfoTab2(idprestamo).Rows[0][1].ToString();
            LabelEstadoCivil.Text = presta.InfoTab2(idprestamo).Rows[0][2].ToString();
            LabelProfesion.Text = presta.InfoTab2(idprestamo).Rows[0][3].ToString();
            LabelTelefonos.Text = presta.InfoTab2(idprestamo).Rows[0][4].ToString();
            LabelDireccionPer.Text = presta.InfoTab2(idprestamo).Rows[0][5].ToString();
            LabelDomicilio.Text = presta.InfoTab2(idprestamo).Rows[0][6].ToString();
            LabelLugarTrabajo.Text = presta.InfoTab2(idprestamo).Rows[0][7].ToString();
            LabelDirTrabajo.Text = presta.InfoTab2(idprestamo).Rows[0][8].ToString();
            LabelTelTrabajo.Text = presta.InfoTab2(idprestamo).Rows[0][9].ToString();
            LabelTiempoLaborar.Text = presta.InfoTab2(idprestamo).Rows[0][10].ToString();
            LabelObservacionesTrabajo.Text = presta.InfoTab2(idprestamo).Rows[0][11].ToString();
            LabelMontoPre.Text = presta.InfoTab2(idprestamo).Rows[0][12].ToString();
            LabelDeudaTotalPre.Text = presta.InfoTab2(idprestamo).Rows[0][13].ToString();
            LabelPeriodPre.Text = presta.InfoTab2(idprestamo).Rows[0][14].ToString();
            LabelGestorPre.Text = presta.InfoTab2(idprestamo).Rows[0][15].ToString();
            LabelOficinaPre.Text = presta.InfoTab2(idprestamo).Rows[0][16].ToString();
            //referencias tab2
            GridView1.DataSource = ver.Listadore(Convert.ToInt32(presta.InfoTab2(idprestamo).Rows[0][17].ToString()));
            GridView1.DataBind();
            //Garantias tab3
            GridView2.DataSource = presta.GarantiasPrestamo(idprestamo);
            GridView2.DataBind();


        }
        ///anular pago
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                string valor2 = Request.QueryString["Valor"];
                int idprestamo = Convert.ToInt32(valor2);
                
                    int idpago = Convert.ToInt32(GridView4.DataKeys[e.NewSelectedIndex].Value);
                    presta.AnularPago(idpago);
                    string notificacion1;
                    notificacion1 = "myFunction();";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
                    GridView4.DataSource = presta.TabPagosEfectuados(idprestamo);
                    GridView4.Columns[0].Visible = false;
                    GridView4.DataBind();
                    Label3.Text = "Q. " + presta.TOTAlPagosTab4(idprestamo).Rows[0][0].ToString();

                    Bitacora bita = new Bitacora();
                    bita.RegistrarBitacora("Anular", "Anular pago de prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                 
                
            }
            catch (Exception ex)
            {

            }

        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            String Valor = Convert.ToString(idprestamo);
            Response.Redirect("ImprimirListaPagosTab.aspx?valor=" + Valor);
 
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           try {
                ///Si es prestamos nuevo
                string valor2 = Request.QueryString["Valor"];
                int idprestamo = Convert.ToInt32(valor2);
                string tipopre = presta.InfoTabUNO(idprestamo).Rows[0][0].ToString();
                string desembolso = presta.InfoTabUNO(idprestamo).Rows[0][1].ToString();
                if (tipopre == "False" && desembolso == "False")
                {

                    presta.Precalificar(true, idprestamo);
                    Button1.Enabled = false;
                    Button1.Visible = false;
                    string notificacion1;
                    notificacion1 = "myFunction();";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
                }
                //fin prestamos nuevo

                 //desembolsar
                if (tipopre == "True" && desembolso == "False")
                {
                    presta.Desembolsar(true,idprestamo);

                    ///crear pagos despues de desembolsar
                    
                    Decimal monto =Convert.ToDecimal(presta.InfoTabUNO(idprestamo).Rows[0][7].ToString());
                    Decimal MontoInteres = Convert.ToDecimal(presta.InfoTabUNO(idprestamo).Rows[0][6].ToString()) - Convert.ToDecimal(presta.InfoTabUNO(idprestamo).Rows[0][7].ToString());
                    int plan=Convert.ToInt32(presta.SaberIdPrestamoPlan(idprestamo).Rows[0][0].ToString());
                    string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
                   // DateTime fecha = DateTime.ParseExact(fecha1, "dd/MM/yyyy", null);
                   DateTime fecha = Convert.ToDateTime(fecha1);
                    //pago cuando son dias
                    if (presta.InfoPlan(plan).Rows[0][2].ToString() == "True")
                    {
                        //pago cuando son dias

                        DateTime fechaInicial1 = fecha;
                        DateTime fechaInicial = fechaInicial1.AddDays(1);

                        List<DateTime> fechasList = new List<DateTime>();

                        DateTime fechaTemp = fechaInicial;
                        int feriados = Convert.ToInt32(presta.CantidadDiasFeriados(fecha).Rows[0][0].ToString());
                        int DD2 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString());
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
                                        for (int m = 0; m < CantidadDatosFeriado; m++)
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

                            for (int m = 0; m < CantidadDatosFeriado; m++)
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

                        //int dias3 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString());
                        int dias3 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString()) - 1;
                        Decimal cuota = (monto + MontoInteres) / Convert.ToDecimal(presta.InfoPlan(plan).Rows[0][1].ToString());
                        Decimal mora = Convert.ToDecimal(0);
                        Decimal saldo = (monto + MontoInteres);
                        for (int f = 0; f <= dias3; f++)
                        {

                            saldo = saldo - cuota;
                            ingreso.Pagos(cuota, mora, fechasList[f], false, cuota, saldo, idprestamo,false);
                        }
                        DateTime fe = Convert.ToDateTime(r.SaberFechaVencimiento(idprestamo).Rows[0][0].ToString());
                        r.AgregarReporte(0, 0, 0, 0, 0, idprestamo, fe);

                    }///fin pago dias
                    //si se paga en semanas
                    else if (presta.InfoPlan(plan).Rows[0][3].ToString() == "True")
                    {
                        DateTime fechaInicial1 = fecha;
                        DateTime fechaInicial = fechaInicial1.AddDays(1);

                        List<DateTime> fechasList = new List<DateTime>();

                        DateTime fechaTemp = fechaInicial;
                        int feriados = Convert.ToInt32(presta.CantidadDiasFeriados(fechaInicial1).Rows[0][0].ToString());
                        int CantidadDatosFeriado = feriados;
                        int k = 0;
                        int DD2 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString());
                        int dias = DD2 * 6;
                        int i = 0;
                        for (i = 0; i <= dias; i++)
                        {
                            i = i + 6;
                            fechaTemp = fechaInicial.AddDays(i);
                            fechasList.Add(fechaTemp);

                            for (int j = 0; j < fechasList.Count; j++)
                            {
                                for (int m = 0; m < CantidadDatosFeriado; m++)
                                {
                                    if (fechasList[j] == Convert.ToDateTime(presta.FechasFeriado(fechaInicial1).Rows[m][0].ToString()))
                                    {
                                        Label1.Text = Convert.ToString(fechasList.Last());
                                        k++;
                                        Label2.Text = Convert.ToString(k);
                                        fechasList.RemoveAt(j);

                                        DateTime fechaprueba = Convert.ToDateTime(Label1.Text);
                                        fechaTemp = fechaprueba.AddDays(1);
                                        fechasList.Add(fechaTemp);

                                    }



                                }
                                if (fechasList[j].DayOfWeek == DayOfWeek.Sunday)
                                {
                                    Label1.Text = Convert.ToString(fechasList.Last());
                                    k++;
                                    Label2.Text = Convert.ToString(k);
                                    fechasList.RemoveAt(j);

                                    DateTime fechaprueba = Convert.ToDateTime(Label1.Text);
                                    fechaTemp = fechaprueba.AddDays(1);
                                    fechasList.Add(fechaTemp);

                                }

                            }

                        }




                        fechasList.Sort();


                        int dias3 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString()) - 1;
                        Decimal cuota = (monto + MontoInteres) / Convert.ToDecimal(presta.InfoPlan(plan).Rows[0][1].ToString());
                        Decimal mora = Convert.ToDecimal(0);
                        Decimal saldo = (monto + MontoInteres);
                        for (int f = 0; f <= dias3; f++)
                        {

                            saldo = saldo - cuota;
                            ingreso.Pagos(cuota, mora, fechasList[f], false, cuota, saldo, idprestamo,false);
                        }

                        //agregar campos para el reporte
                        DateTime fe = Convert.ToDateTime(r.SaberFechaVencimiento(idprestamo).Rows[0][0].ToString());
                        r.AgregarReporte(0, 0, 0, 0, 0, idprestamo, fe);
                      
                    }//fin de else if
                    //fin pago por mes
                    //fin de creacion de pagos
                    
                    //Hacer no visible el boton de cancelar
                    Button2.Visible = false;
                    Button1.Visible = false;
                    GridView3.DataSource = presta.TablaPagosTab(idprestamo);
                    GridView3.DataBind();
                    DivHistoPagos.Visible = true;
                    Button5.Visible = true;
                    Button6.Visible = true;
                    Button7.Visible = true;


                    //Datos de Contrato;
                    string NombreCliente = presta.INFOPARACONTRATO(idprestamo).Rows[0][0].ToString();
                    string edad = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][1].ToString()).ToLower();
                    string EstadoCivil = presta.INFOPARACONTRATO(idprestamo).Rows[0][2].ToString();
                    string Profesion = presta.INFOPARACONTRATO(idprestamo).Rows[0][3].ToString();
                    string DireccionCli = presta.INFOPARACONTRATO(idprestamo).Rows[0][4].ToString();
                    string Parte1DPI = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][5].ToString().Substring(0, 4)).ToLower();
                    string Parte2DPI = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][5].ToString().Substring(4, 5)).ToLower();
                    string Parte3DPI = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][5].ToString().Substring(9, 1)).ToLower();
                    string Parte4DPI = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][5].ToString().Substring(10, 3)).ToLower();
                    string DPI = Parte1DPI + ", " + Parte2DPI + ", " + Parte3DPI + ", " + Parte4DPI + " (" + presta.INFOPARACONTRATO(idprestamo).Rows[0][5].ToString() + ")";
                    string MontoPresta = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][6].ToString()) + " QUETZALES" + " ( Q." + presta.INFOPARACONTRATO(idprestamo).Rows[0][6].ToString() + ")";
                    string PeriodoContra = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][7].ToString()).ToLower();
                    Decimal Prueba = Convert.ToDecimal(presta.INFOPARACONTRATO(idprestamo).Rows[0][8].ToString());
                    string CuotaContra = ca.enletras(Convert.ToString(Math.Round(Prueba, 0))) + " QUETZALES" + " (Q." + Convert.ToString(Math.Round(Prueba, 0)) + ")";
                    string MoraContra = ca.enletras(presta.INFOPARACONTRATO(idprestamo).Rows[0][9].ToString()) + " QUETZALES" + " (Q." + presta.INFOPARACONTRATO(idprestamo).Rows[0][9].ToString() + ")";
                    string SemanasDias = presta.INFOPARACONTRATO(idprestamo).Rows[0][10].ToString();
                    string DirAgencia = presta.INFOPARACONTRATO(idprestamo).Rows[0][11].ToString();
                    string Nacionalidad = presta.INFOPARACONTRATO(idprestamo).Rows[0][12].ToString();

                    string Parte1FI = ca.enletras(presta.FechaInicialYFinal(idprestamo).Rows[0][0].ToString().Substring(0, 2)).ToLower();
                    string Parte2FI = presta.FechaInicialYFinal(idprestamo).Rows[0][0].ToString().Substring(3, 2);
                    string Parte3FI = ca.enletras(presta.FechaInicialYFinal(idprestamo).Rows[0][0].ToString().Substring(6, 4)).ToLower();
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

                    string FechaInicialContra = Parte1FI + " de " + mes + " de " + Parte3FI;

                    //fecha final
                    string Parte1FF = ca.enletras(presta.FechaInicialYFinal(idprestamo).Rows[0][1].ToString().Substring(0, 2)).ToLower();
                    string Parte2FF = presta.FechaInicialYFinal(idprestamo).Rows[0][1].ToString().Substring(3, 2);
                    string Parte3FF = ca.enletras(presta.FechaInicialYFinal(idprestamo).Rows[0][1].ToString().Substring(6, 4)).ToLower();
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

                    string GarantiasCon = "";
                    if (presta.GarantiasContrato(idprestamo).Rows.Count == 1)
                    {
                        GarantiasCon = presta.GarantiasContrato(idprestamo).Rows[0][0].ToString();

                    }
                    else if (presta.GarantiasContrato(idprestamo).Rows.Count == 2)
                    {
                        GarantiasCon = presta.GarantiasContrato(idprestamo).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(idprestamo).Rows[1][0].ToString();
                    }
                    else if (presta.GarantiasContrato(idprestamo).Rows.Count == 3)
                    {
                        GarantiasCon = presta.GarantiasContrato(idprestamo).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(idprestamo).Rows[1][0].ToString() + "; " + presta.GarantiasContrato(idprestamo).Rows[2][0].ToString();
                    }



                    presta.CrearContrato(NombreCliente, edad, EstadoCivil, Profesion, DireccionCli, DPI, MontoPresta, PeriodoContra, CuotaContra, FechaInicialContra, FechaFinallContra, MoraContra, SemanasDias, GarantiasCon, DirAgencia, true, Nacionalidad, idprestamo);

                    //final de crear contrato

                    Bitacora bita = new Bitacora();
                    bita.RegistrarBitacora("Registro", "Precalificar prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                 

                    string notificacion1;
                    notificacion1 = "myFunction();";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
 
                }//fin desembolar
            
          }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);

            
            }
           

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            String Valor = presta.InfoTab2(idprestamo).Rows[0][17].ToString();
            Response.Redirect("ActualizarCliente.aspx?valor=" + Valor);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            String Valor = Convert.ToString(idprestamo);
            Response.Redirect("ImprimirInfoTab2.aspx?valor=" + Valor);
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            String Valor = Convert.ToString(idprestamo);
            Response.Redirect("ImprimirTablaPagos.aspx?valor=" + Valor);
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);

            Bitacora bita = new Bitacora();
            bita.RegistrarBitacora("Registro", "Generar Cheque, de prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                 
            String Valor = Convert.ToString(idprestamo);
            Response.Redirect("ImprimirCheque.aspx?valor=" + Valor);
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            Bitacora bita = new Bitacora();
            bita.RegistrarBitacora("Eiliminar ", "Elimino prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                 
            presta.EliminarGarantia(idprestamo);
            presta.EliminarPagosPRestamo(idprestamo);
            presta.EliminarPrestamo(idprestamo);

            
            Response.Redirect("Inicio.aspx");
          
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            string tipopre = presta.InfoTabUNO(idprestamo).Rows[0][0].ToString();
            string desembolso = presta.InfoTabUNO(idprestamo).Rows[0][1].ToString();
            if (tipopre == "False" && desembolso == "False")
            {
                ////eliminarPrestamos
                
                presta.EliminarGarantia(idprestamo);
                presta.EliminarPrestamo(idprestamo);

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Cancelacion", "Cancelo prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                Response.Redirect("PrestamosPorPrecalificar.aspx");
            }
            if (tipopre == "True" && desembolso == "False")
            {
                ////eliminarPrestamos

                presta.EliminarGarantia(idprestamo);
                presta.EliminarPrestamo(idprestamo);

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Cancelacion", "Cancelo prestamo No. " + Convert.ToString(idprestamo), Convert.ToInt32(Session["idempleado"]));
                Response.Redirect("Desembolsos.aspx");
            }


           
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idprestamo = Convert.ToInt32(valor2);
            String Valor3 = Convert.ToString(idprestamo);
            Response.Redirect("Abono.aspx?valor3=" + Valor3);

        }

    }
}