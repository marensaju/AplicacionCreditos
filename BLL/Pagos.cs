using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetPagosTableAdapters;

namespace BLL
{
    public class Pagos
    {
        
        HistorialPagosTableAdapter histo = new HistorialPagosTableAdapter();
        private HistorialPagosTableAdapter HISTO
        {
           
            get { return histo; }
        }
        TotalHistorialPagosTableAdapter tohis = new TotalHistorialPagosTableAdapter();
        private TotalHistorialPagosTableAdapter TOHIS
        {
            get { return tohis; }
        }
        AsesoresAgenciaTableAdapter asesor = new AsesoresAgenciaTableAdapter();
        private AsesoresAgenciaTableAdapter ASESOR
        {
            get { return asesor; }
        }
        
        FaltaDePagoTableAdapter falta = new FaltaDePagoTableAdapter();
        private FaltaDePagoTableAdapter FALTA
        {
            get { return falta; }
        }
        ListaPrestamosConMorasTableAdapter pm = new ListaPrestamosConMorasTableAdapter();
        private ListaPrestamosConMorasTableAdapter PM
        {
            get { return pm; }
        }

        ListadoPagosConMoraTableAdapter pagosm = new ListadoPagosConMoraTableAdapter();
        private ListadoPagosConMoraTableAdapter PAGOSM
        {
            get { return pagosm; }
        }

        OmitirMoraDePagoTableAdapter omi = new OmitirMoraDePagoTableAdapter();
        private OmitirMoraDePagoTableAdapter OMI
        {
            get { return omi; }
        }

        IDULTIMOPAGOFULLTableAdapter ulti = new IDULTIMOPAGOFULLTableAdapter();
        private IDULTIMOPAGOFULLTableAdapter ULTI
        {
            get { return ulti; }
        }

        LIstadoPagosFUllTableAdapter listaP = new LIstadoPagosFUllTableAdapter();
        private LIstadoPagosFUllTableAdapter LISTAP
        {
            get { return listaP; }
        }
        PrestamoFinalizadoTableAdapter fina = new PrestamoFinalizadoTableAdapter();
        private PrestamoFinalizadoTableAdapter FINA
        {
            get { return fina; }
        }

        COnocerIDPrestamoDelPagoTableAdapter cono = new COnocerIDPrestamoDelPagoTableAdapter();
        private COnocerIDPrestamoDelPagoTableAdapter CONO
        {
            get { return cono; }
        }
        //metodo
        public DataTable IDPRESTAMO(int pago)
        {
            return CONO.GetDataConocerIDprestamo(pago);

        }
        public void FinalizarPrestamo(int prestamo)
        {
            FINA.GetDataPrestamoFinalizado(prestamo);
        }
        public DataTable LIstadoPagosFUll(int presta)
        {
            return LISTAP.GetDataListadoPagosFULL(presta);
        }

        public DataTable UltimoPagoID(int prestamo)
        {
            return ULTI.GetDataIDULTIMOPAGOFULL(prestamo);
        }

        public void OmitirMora(int pago, bool estado,DateTime fecha,int empleado,bool mora)
        {
            OMI.GetDataOmitirMoraDePago(pago, estado, fecha, empleado,mora);
        }
        public DataTable PagosConMora(int prestamos)
        {
            return PAGOSM.GetDataListadoPagosConMora(prestamos);
        }
        public DataTable PrestamosConMoras(int agencia, int empleado)
        {
            return PM.GetDataListaPrestamosConMoras(agencia, empleado);
        }
        public DataTable FALTADEPAGO(DateTime f1, int agencia, int empleado)
        {
            return FALTA.GetDataFaltaDePago(f1, agencia, empleado);

        }
        
        public DataTable AsesoresDropdown(int agencia)
        {
            return ASESOR.GetDataAsesoresAgencia(agencia);
        }
        public DataTable TotalHistoPagos(DateTime fecha1, DateTime fecha2, int empleado, int agencia)
        {
            return TOHIS.GetDataTotalHisto(fecha1, fecha2, empleado, agencia);
        }
        
        public DataTable HistorialPagos( DateTime fecha1, DateTime fecha2, int agencia, int empleado)
        {
            return HISTO.GetDataHistoPagos(fecha1, fecha2,agencia,empleado);
        }

    }
}
