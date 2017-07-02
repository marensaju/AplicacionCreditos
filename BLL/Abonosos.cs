using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbonoTableAdapters;
using System.Data;
namespace BLL
{
    public class Abonosos
    {
        InsertarAbonoTableAdapter abi = new InsertarAbonoTableAdapter();
        private InsertarAbonoTableAdapter ABI
        {
            get { return abi; }
        }

        ConocerSiSePuedeAbonarTableAdapter cb = new ConocerSiSePuedeAbonarTableAdapter();
        private ConocerSiSePuedeAbonarTableAdapter CB
        {
            get { return cb; }
        }

        ListaPagosPendientesTableAdapter pagitos = new ListaPagosPendientesTableAdapter();
        private ListaPagosPendientesTableAdapter PAGITOS
        {
            get { return pagitos; }
        }

        CantidadExactaPagosAbonosTableAdapter cantipa = new CantidadExactaPagosAbonosTableAdapter();
        private CantidadExactaPagosAbonosTableAdapter CANTIPA
        {
            get { return cantipa; }
        }

        IDPAGOABONOSTableAdapter forid =new IDPAGOABONOSTableAdapter();
        private IDPAGOABONOSTableAdapter FORID
        {
            get { return forid; }
        }

        ListaAbonosPrestamoTableAdapter labo = new ListaAbonosPrestamoTableAdapter();
        private ListaAbonosPrestamoTableAdapter LABO
        {
            get { return labo; }
        }

        InfoAbonoTableAdapter infoabo = new InfoAbonoTableAdapter();
        private InfoAbonoTableAdapter INFOABO
        {
            get { return infoabo; }
        }

        //metodo

        public DataTable InfoAbono(int presta)
        {
            return INFOABO.GetDataInfoAbono(presta);
        }

        public DataTable LISTAABONOS(int presta)
        {
            return LABO.GetDataListaAbonos(presta);
        }
        public DataTable IDPAGOSINICIOABONO(int presta)
        {
            return FORID.GetDataIDPAgoAbonosFor(presta);
        }


        public DataTable CantiPagosAbonosFOr(int prestamo)
        {
            return CANTIPA.GetDataCantidadPagosAbonosFOr(prestamo);
        }

        public DataTable ListaPagosPendientes(int presta)
        {
            return PAGITOS.GetDataListaPagosPendientes(presta);
        }

        public DataTable ConocerSiPuedeAbonar(int presta)
        {
            return CB.GetDataConocerAbonar(presta);
 
        }
        public void RegistrarAbono(decimal monto, string observacion, int prestamo)
        {
            ABI.GetDataInsertarAbono(monto, observacion, prestamo);
 
        }

    }
}
