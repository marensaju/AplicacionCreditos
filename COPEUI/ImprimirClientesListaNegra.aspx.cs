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
    public partial class ImprimirClientesListaNegra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               VerClienteslistanegraGridTableAdapter ver = new VerClienteslistanegraGridTableAdapter();
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DataTable tabla = ver.GetDataVerClientesGridNegra(agencia);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteListaNegra.rdlc");
                ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(fuente);

                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}