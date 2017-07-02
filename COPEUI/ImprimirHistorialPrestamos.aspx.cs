﻿using System;
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
    public partial class ImprimirHistorialPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* try{*/
                if (!IsPostBack)
            {
               HistorialPrestamosGeneralTableAdapter ver = new HistorialPrestamosGeneralTableAdapter();
                string fecha1 = Request.QueryString["Valor"];
                string fecha2 = Request.QueryString["Ubicac"];
                DateTime f1=Convert.ToDateTime(fecha1);
                DateTime f2=Convert.ToDateTime(fecha2);
                int agencia = Convert.ToInt32(Session["idagencia"]);
                DataTable tabla = ver.GetDataImprimirHistoPrestamosGeneral(agencia,f1,f2);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteHistorialPrestamos.rdlc");
                ReportDataSource fuente = new ReportDataSource("DataSet1", tabla);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(fuente);

                ReportViewer1.LocalReport.Refresh();
            }

           /* }catch(Exception ex)
            {

            }*/
            
            
        }
    }
}