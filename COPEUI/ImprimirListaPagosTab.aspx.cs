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
namespace COPEUI
{
    public partial class ImprimirListaPagosTab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 TabPagosEfectuadosTableAdapter ver = new TabPagosEfectuadosTableAdapter();
                 string valor2 = Request.QueryString["Valor"];
                 int idprestamo = Convert.ToInt32(valor2);
                DataTable tabla = ver.GetDataTabPagosEfectuados(idprestamo);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteTabPagos.rdlc");
                ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(fuente);

                ReportViewer1.LocalReport.Refresh();
            }

        }
    }
}