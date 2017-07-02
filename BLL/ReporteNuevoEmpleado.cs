using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetReporteNuevoEmpleadoTableAdapters;
using System.Data;

namespace BLL
{
    public class ReporteNuevoEmpleado
    {
        ParalistadeAgenciaTableAdapter agen = new ParalistadeAgenciaTableAdapter();
        private ParalistadeAgenciaTableAdapter AGEN
        {
            get { return agen; }
        }

        ParalistadePuestoTableAdapter pues = new ParalistadePuestoTableAdapter();
        private ParalistadePuestoTableAdapter PUES
        {
            get { return pues; }
        }

        //metodo
        public DataTable ListarPuesto()
        {
            return PUES.GetDataListaPuesto();
        }


        public DataTable ListarAgencia()
        {
            return AGEN.GetDataListaAgencia();
        }



    }
}
