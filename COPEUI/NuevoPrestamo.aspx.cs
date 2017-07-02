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
    public partial class NuevoPrestamo : System.Web.UI.Page
    {
        VerClientes ver = new VerClientes();
        PrestamosTodo presta = new PrestamosTodo();
        IngresosPrestamos ingreso = new IngresosPrestamos();
        Ripo r = new Ripo();
        Conversion ca = new Conversion();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][4].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
            

            int agencia = Convert.ToInt32(Session["idagencia"]);
            if (!IsPostBack)
            {
                DropDownList1.DataSource = presta.ListarAsesor(1,agencia);
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "Id_empleado";
                DropDownList1.DataBind();

                DropDownList2.DataSource = presta.PlanDropDown(); ;
                DropDownList2.DataTextField = "Nombre_plan";
                DropDownList2.DataValueField = "Id_plan";
                DropDownList2.DataBind();

            }

        }

        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idpersona = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Label8.Text = idpersona.ToString();

                LabelNombre.Text = ver.PerfilC(idpersona).Rows[0][1].ToString();
                LabelDPI.Text = ver.PerfilC(idpersona).Rows[0][2].ToString();
                LabelDireccion.Text= ver.PerfilC(idpersona).Rows[0][3].ToString();
                Labeltelefono.Text = ver.PerfilC(idpersona).Rows[0][4].ToString();
                LabelTrabajo.Text= ver.PerfilC(idpersona).Rows[0][5].ToString();
                
                Image1.ImageUrl = "~/ImagenesCargadas/Clientes/" + ver.PerfilC(idpersona).Rows[0][7].ToString();
                

                //idpersona
                LabelIDPersona.Text = ver.PerfilC(idpersona).Rows[0][0].ToString();

                if (presta.SipuedePrestar(idpersona).Rows[0][0].ToString() == "False")
                {
                    Button2.Visible = false;
                }
                else { Button2.Visible = true; }
                



            }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int agencia = Convert.ToInt32(Session["idagencia"]);
                GridView1.DataSource = ver.FINDCLIENTEE(TextBox1.Text, agencia);
                GridView1.Columns[4].Visible = false;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);

            }

        }
       
      

        protected void Button2_Click(object sender, EventArgs e)
        {

            string asesor1 = DropDownList1.SelectedValue.ToString();
            int asesor=Convert.ToInt32(asesor1);
            Decimal monto=Convert.ToDecimal(TextMonto.Text);
            string plan1 = DropDownList2.SelectedValue.ToString();
            int plan=Convert.ToInt32(plan1);
            //garantias
            
            string des1=TextRef1.Text;
            string modelo1 = TextRef2.Text;
            string serie1 = TextRef3.Text;
            Decimal valor1 = Convert.ToDecimal(TextRef4.Text);
            string des2 = TextRef5.Text;
            string modelo2 = TextRef6.Text;
            string serie2 = TextRef7.Text;
        
            string des3 = TextRef9.Text;
            string modelo3 = TextRef10.Text;
            string serie3 = TextRef11.Text;
         
            //para llenar nuevo prestamo
            bool estado = false;
            bool tipoPrestamo = false;
            bool autorizacion = false;
            //calculo de interes
            string recuperarInt = presta.SaberCantidadInteres(plan).Rows[0][0].ToString();
            int cantidadInteres = Convert.ToInt32(recuperarInt);

            Decimal MontoInteres = monto * Convert.ToDecimal(cantidadInteres) / 100;
            /*string s = MontoInteres.ToString().Replace(",", ".");
            Decimal hola=Convert.ToDecimal(s);*/
           
            ///autorizacion se usa para saber si un prestamo ya esta pagado totalmente

           int persona=Convert.ToInt32(Label8.Text);
           string persona2 = presta.SaberIDcliente(persona).Rows[0][0].ToString();
           int cliente = Convert.ToInt32(persona2);
         string fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
         DateTime fecha = Convert.ToDateTime(fecha1);
  
        try {
                   //prestamo nuevo
             if (RadioButton1.Checked == true)
             {

                 ingreso.Prestamo(monto, "ninguna", tipoPrestamo, MontoInteres, autorizacion, estado, cliente, asesor, plan, fecha, true, false);
                 //para no permitir que pueda prestar
                 presta.NoPUedePrestar(cliente);

                 //Garantias
                 int IDultimo = Convert.ToInt32(presta.UltimoPrestamo().Rows[0][0].ToString());
                 if (TextRef5.Text.Trim() == "" && TextRef6.Text.Trim() == "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "" && TextRef10.Text.Trim() == "" && TextRef11.Text.Trim() == "" && TextRef12.Text.Trim() == "")
                 {
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                 }
                 else if (TextRef9.Text.Trim() == "" && TextRef10.Text.Trim() == "" && TextRef11.Text.Trim() == "" && TextRef12.Text.Trim() == "")
                 {

                     Decimal valor2 = Convert.ToDecimal(TextRef8.Text);
                     ingreso.Garantia(des2, modelo2, serie2, valor2, IDultimo);
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                 }
                 else
                 {
                     Decimal valor3 = Convert.ToDecimal(TextRef12.Text);
                     Decimal valor2 = Convert.ToDecimal(TextRef8.Text);
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                     ingreso.Garantia(des2, modelo2, serie2, valor2, IDultimo);
                     ingreso.Garantia(des3, modelo3, serie3, valor3, IDultimo);

                 }//fin garantias


                 Bitacora bita = new Bitacora();
                 bita.RegistrarBitacora("Registro", "Nuevo Prestamo " + Convert.ToString(IDultimo), Convert.ToInt32(Session["idempleado"]));
                 


             }//prestamos activo
             else
             {

                 ingreso.Prestamo(monto, "ninguna", true, MontoInteres, false, true, cliente, asesor, plan, fecha, false, true);
                 //para no permitir que pueda prestar
                 presta.NoPUedePrestar(cliente);
                 int IDultimoPrestamo = Convert.ToInt32(presta.UltimoPrestamo().Rows[0][0].ToString());
                
                 //generacion de pagos
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
                     int dias3 = Convert.ToInt32(presta.InfoPlan(plan).Rows[0][1].ToString());  
                     Decimal cuota = (monto + MontoInteres)/Convert.ToDecimal(presta.InfoPlan(plan).Rows[0][1].ToString());
                     Decimal mora = Convert.ToDecimal(0);
                     Decimal saldo = (monto+MontoInteres);
                     for (int f = 1; f <= dias3; f++)
                     {
                         
                         saldo=saldo-cuota;
                         ingreso.Pagos(cuota, mora, fechasList[f], false, cuota, saldo, IDultimoPrestamo,false);
                     }
                     //agregar campos para el reporte
                     DateTime fe=Convert.ToDateTime(r.SaberFechaVencimiento(IDultimoPrestamo).Rows[0][0].ToString());
                     r.AgregarReporte(0, 0, 0, 0, 0, IDultimoPrestamo, fe);
 
                 }

                 //si se paga en semanas
                 else   if (presta.InfoPlan(plan).Rows[0][3].ToString() == "True")
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
                         ingreso.Pagos(cuota, mora, fechasList[f], false, cuota, saldo, IDultimoPrestamo,false);
                     }

                     DateTime fe = Convert.ToDateTime(r.SaberFechaVencimiento(IDultimoPrestamo).Rows[0][0].ToString());
                     r.AgregarReporte(0, 0, 0, 0, 0, IDultimoPrestamo, fe);
                     

                 }//fin de else if

               
                 //fin de generacion de pagos

                 //Garantias
                 int IDultimo = Convert.ToInt32(presta.UltimoPrestamo().Rows[0][0].ToString());
                 if (TextRef5.Text.Trim() == "" && TextRef6.Text.Trim() == "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "" && TextRef10.Text.Trim() == "" && TextRef11.Text.Trim() == "" && TextRef12.Text.Trim() == "")
                 {
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                 }
                 else if (TextRef9.Text.Trim() == "" && TextRef10.Text.Trim() == "" && TextRef11.Text.Trim() == "" && TextRef12.Text.Trim() == "")
                 {

                     Decimal valor2 = Convert.ToDecimal(TextRef8.Text);
                     ingreso.Garantia(des2, modelo2, serie2, valor2, IDultimo);
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                 }
                 else
                 {
                     Decimal valor3 = Convert.ToDecimal(TextRef12.Text);
                     Decimal valor2 = Convert.ToDecimal(TextRef8.Text);
                     ingreso.Garantia(des1, modelo1, serie1, valor1, IDultimo);
                     ingreso.Garantia(des2, modelo2, serie2, valor2, IDultimo);
                     ingreso.Garantia(des3, modelo3, serie3, valor3, IDultimo);

                 }//fin garantias



                 //Datos de Contrato;
                 string NombreCliente = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][0].ToString();
                 string edad = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][1].ToString()).ToLower();
                 string EstadoCivil = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][2].ToString();
                 string Profesion = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][3].ToString();
                 string DireccionCli = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][4].ToString();
                 string Parte1DPI = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][5].ToString().Substring(0, 4)).ToLower();
                 string Parte2DPI = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][5].ToString().Substring(4, 5)).ToLower();
                 string Parte3DPI = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][5].ToString().Substring(9, 1)).ToLower();
                 string Parte4DPI = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][5].ToString().Substring(10, 3)).ToLower();
                 string DPI = Parte1DPI + ", " + Parte2DPI + ", " + Parte3DPI + ", " + Parte4DPI + " (" + presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][5].ToString() + ")";
                 string MontoPresta = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][6].ToString()) + " QUETZALES" + " ( Q." + presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][6].ToString() + ")";
                 string PeriodoContra = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][7].ToString()).ToLower();
                 Decimal Prueba = Convert.ToDecimal(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][8].ToString());
                 string CuotaContra = ca.enletras(Convert.ToString(Math.Round(Prueba, 0))) + " QUETZALES" + " (Q." + Convert.ToString(Math.Round(Prueba, 0)) + ")";
                 string MoraContra = ca.enletras(presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][9].ToString()) + " QUETZALES" + " (Q." + presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][9].ToString() + ")";
                 string SemanasDias = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][10].ToString();
                 string DirAgencia = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][11].ToString();
                 string Nacionalidad = presta.INFOPARACONTRATO(IDultimoPrestamo).Rows[0][12].ToString();

                 string Parte1FI = ca.enletras(presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][0].ToString().Substring(0, 2)).ToLower();
                 string Parte2FI = presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][0].ToString().Substring(3, 2);
                 string Parte3FI = ca.enletras(presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][0].ToString().Substring(6, 4)).ToLower();
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
                 string Parte1FF = ca.enletras(presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][1].ToString().Substring(0, 2)).ToLower();
                 string Parte2FF = presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][1].ToString().Substring(3, 2);
                 string Parte3FF = ca.enletras(presta.FechaInicialYFinal(IDultimoPrestamo).Rows[0][1].ToString().Substring(6, 4)).ToLower();
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
                 if (presta.GarantiasContrato(IDultimoPrestamo).Rows.Count == 1)
                 {
                     GarantiasCon = presta.GarantiasContrato(IDultimoPrestamo).Rows[0][0].ToString();

                 }
                 else if (presta.GarantiasContrato(IDultimoPrestamo).Rows.Count == 2)
                 {
                     GarantiasCon = presta.GarantiasContrato(IDultimoPrestamo).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(IDultimoPrestamo).Rows[1][0].ToString();
                 }
                 else if (presta.GarantiasContrato(IDultimoPrestamo).Rows.Count == 3)
                 {
                     GarantiasCon = presta.GarantiasContrato(IDultimoPrestamo).Rows[0][0].ToString() + "; " + presta.GarantiasContrato(IDultimoPrestamo).Rows[1][0].ToString() + "; " + presta.GarantiasContrato(IDultimoPrestamo).Rows[2][0].ToString();
                 }



                 presta.CrearContrato(NombreCliente, edad, EstadoCivil, Profesion, DireccionCli, DPI, MontoPresta, PeriodoContra, CuotaContra, FechaInicialContra, FechaFinallContra, MoraContra, SemanasDias, GarantiasCon, DirAgencia, true, Nacionalidad, IDultimoPrestamo);

                 //final de crear contrato

                 Bitacora bita = new Bitacora();
                 bita.RegistrarBitacora("Registro", "Nuevo Prestamo " + Convert.ToString(IDultimoPrestamo), Convert.ToInt32(Session["idempleado"]));
                 

             }






            
             string notificacion1;
             notificacion1 = "myFunction();";
             ScriptManager.RegisterStartupScript(UpdatePanel4, UpdatePanel4.GetType(), "notificacion1", notificacion1, true);

         }catch (Exception ex) {
             string notificacion2;
             notificacion2 = "myFunction2();";
             ScriptManager.RegisterStartupScript(UpdatePanel4, UpdatePanel4.GetType(), "notificacion2", notificacion2, true);

         }


         


        }


    }
}