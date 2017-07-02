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
    public partial class ImprimirCheque : System.Web.UI.Page
    {
        PrestamosTodo presta = new PrestamosTodo();
        Conversion c = new Conversion();
        IngresosPrestamos ingre = new IngresosPrestamos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                string valor2 = Request.QueryString["Valor"];
                int prestamo = 3; //Convert.ToInt32(valor2);
                int comprobar = Convert.ToInt32(presta.SaberSiTieneCheque(prestamo).Rows[0][0].ToString());
                if (comprobar > 0)
                {
                    if (!IsPostBack)
                    {
                        ImprimirChequeTableAdapter ver = new ImprimirChequeTableAdapter();
                        DataTable tabla = ver.GetDataImprimirCheque(prestamo);
                        ReportViewer1.LocalReport.EnableExternalImages = true;
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteCheque.rdlc");
                        ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(fuente);
                        ReportViewer1.LocalReport.Refresh();
                        Button1.Visible = false;


                    }
                }
                else
                {
                    presta.MontoDeCheque(prestamo);
                    TextBox1.Text = presta.MontoDeCheque(prestamo).Rows[0][0].ToString();
                    TextBox2.Text = c.enletras(TextBox1.Text).ToLower();
                }
            
            
            
            }
            catch (Exception ex) { 
            
            }
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string valor2 = Request.QueryString["Valor"];
            int prestamo = 3;//Convert.ToInt32(valor2);
            if (RadioButton1.Checked == true)
            {
                ingre.Cheque(prestamo, Convert.ToDecimal(TextBox1.Text), TextBox2.Text, true);

            }
            else {
                ingre.Cheque(prestamo, Convert.ToDecimal(TextBox1.Text), TextBox2.Text, false);
            }

            
                ImprimirChequeTableAdapter ver = new ImprimirChequeTableAdapter();
                DataTable tabla = ver.GetDataImprimirCheque(prestamo);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteCheque.rdlc");
                ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(fuente);
                ReportViewer1.LocalReport.Refresh();

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