using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetReportePaginaInicioTableAdapters;
using System.Data;

namespace BLL
{
    public class ReportePaginaInicio
    {
        ListadoClientesPaganHoyTableAdapter listadopagan = new ListadoClientesPaganHoyTableAdapter();
        private ListadoClientesPaganHoyTableAdapter LISTADOPAGAN
        {
            get { return listadopagan; }
        }

        VerificarSiHayPagosTableAdapter verificar = new VerificarSiHayPagosTableAdapter();
        private VerificarSiHayPagosTableAdapter VERIFICAR
        {
            get { return verificar; }
        }

        TotalPagosAtrasadosTableAdapter totap = new TotalPagosAtrasadosTableAdapter();
        private TotalPagosAtrasadosTableAdapter TOTAP
        {
            get { return totap; }
        }

        TotalPagosAtrasadosIDPagoTableAdapter moraid = new TotalPagosAtrasadosIDPagoTableAdapter();
        private TotalPagosAtrasadosIDPagoTableAdapter MORAID
        {
            get { return moraid; }
        }

        TotalPagosAtrasadosMoraTableAdapter moramo = new TotalPagosAtrasadosMoraTableAdapter();
        private TotalPagosAtrasadosMoraTableAdapter MORAMO
        {
            get { return moramo; }
        }

        AgregarMoraAPagosAtrasadosTableAdapter agregam = new AgregarMoraAPagosAtrasadosTableAdapter();
        private AgregarMoraAPagosAtrasadosTableAdapter AGREGAM
        {
            get { return agregam; }
        }

        SaberIDEMpleadoTableAdapter ide = new SaberIDEMpleadoTableAdapter();
        private SaberIDEMpleadoTableAdapter IDE
        {
            get { return ide; }
        }

        fechasPagosAtrasadosMoraTableAdapter pf = new fechasPagosAtrasadosMoraTableAdapter();
        private fechasPagosAtrasadosMoraTableAdapter PF
        {
            get { return pf; }
        }

        LIstadoFeriadoMoraTableAdapter feriado = new LIstadoFeriadoMoraTableAdapter();
        private LIstadoFeriadoMoraTableAdapter FERIADO
        {
            get { return feriado; }
            
        }
        CantidadLIstadoFeriadoMoraTableAdapter cdm = new CantidadLIstadoFeriadoMoraTableAdapter();
        private CantidadLIstadoFeriadoMoraTableAdapter CDM
        {
            get { return cdm; }
        }

        TotalEfectivoTableAdapter efectivo = new TotalEfectivoTableAdapter();
        private TotalEfectivoTableAdapter EFECTIVO
        {
            get { return efectivo; }
        }

        MoraRecaudadaTableAdapter moraw = new MoraRecaudadaTableAdapter();
        private MoraRecaudadaTableAdapter MORAW
        {
            get { return moraw; }
        }

        InteresesCobradosTableAdapter intere = new InteresesCobradosTableAdapter();
        private InteresesCobradosTableAdapter INTERE
        {
            get { return intere; }
        }

        CapitalRecaudadoTableAdapter capio = new CapitalRecaudadoTableAdapter();
        private CapitalRecaudadoTableAdapter CAPIO
        {
            get { return capio; }
        }
        TotalClientesActivosTableAdapter cactivos = new TotalClientesActivosTableAdapter();
        private TotalClientesActivosTableAdapter CACTIVOS
        {
            get { return cactivos; }
        }
        TotalPrestamosActivosTableAdapter cpresta = new TotalPrestamosActivosTableAdapter();
        private TotalPrestamosActivosTableAdapter CPRESTA
        {
            get { return cpresta; }
        }

        CalculoTotalEntreFechasTableAdapter cal = new CalculoTotalEntreFechasTableAdapter();
        private CalculoTotalEntreFechasTableAdapter CAL
        {
            get { return cal; }
        }

        perfilInicioTableAdapter pi = new perfilInicioTableAdapter();
        private perfilInicioTableAdapter PI
        {
            get { return pi; }
        }

        TotalPOrAprobarTableAdapter aproba = new TotalPOrAprobarTableAdapter();
        private TotalPOrAprobarTableAdapter APROBA
        {
            get { return aproba; }
        }

        TotalPOrDesembolsoTableAdapter dese = new TotalPOrDesembolsoTableAdapter();
        private TotalPOrDesembolsoTableAdapter DESE
        {
            get { return dese; }
        }
        ///metodo
        ///
        public DataTable TotalPorDesembolso(int agencia)
        {
            return DESE.GetDataPOrDesembolso(agencia);
        }

        public DataTable TotalPOrAprobar(int agencia)
        {
            return APROBA.GetDataPorAbobar(agencia);
        }
        public DataTable PerfilInicio(int empleado)
        {
            return PI.GetDataPerfilInicio(empleado);
        }

        public DataTable CalculoTotalPOrFechas(DateTime f1, DateTime f2, int agencia)
        {
            return CAL.GetDataCalculototalEntreFechas(f1, f2, agencia);
        }
        public DataTable PrestamosActivos(int agencia)
        {
            return CPRESTA.GetDataTotalPrestamosActivos(agencia);
        }
        public DataTable ClientesActivos(int agencia)
        {
            return CACTIVOS.GetDataClientesActivos(agencia);
        }

        public DataTable CapitalRecaudadoHOy(DateTime fecha, int agencia)
        {
            return CAPIO.GetDataCapiRecaudado(fecha, agencia);
        }
        public DataTable InteresesRecaudadosHoy(DateTime fecha, int agencia)
        {
            return INTERE.GetDataInteresRecaudado(fecha,agencia);
        }

        public DataTable MoraRecaudadaHoy(DateTime fecha,int agencia)
        {
            return MORAW.GetDataMoraRecaudada(fecha,agencia);
        }

        public DataTable TotalEfectivoHoy(DateTime fecha, int agencia)
        {
            return EFECTIVO.GetDataTotalEfectivo(fecha, agencia);
        }

        public DataTable CantidadFeriadosMora(DateTime f1, DateTime f2)
        {
            return CDM.GetDataCantidadDiasFeriadoMora(f1, f2);
        }
        public DataTable ListaFeriado(DateTime f1, DateTime f2)
        {
            return FERIADO.GetDataListaFeriadoMora(f1,f2);
        }
        public DataTable LIstadoFechasPagosAtrasados(DateTime fecha)
        {
            return PF.GetDataFechasPagosAtrasados(fecha);
        }
        public DataTable SaberIdEmpleado(string usuario, string contra)
        {
            return IDE.GetDataSaberIDEMpleado(usuario, contra);
        }
        public void AgregarCantidaMora(int pago, Decimal cantidad, bool pagi)
        {
            AGREGAM.GetDataAgregarMora(pago, cantidad,pagi);
        }
        public DataTable CantidadMoraPagosAtrasados(DateTime fecha)
        {
            return MORAMO.GetDataPagosAtrasadosMora(fecha);
        }
        public DataTable NumeroPagosAtradasoIDPago(DateTime fecha)
        {
            return MORAID.GetDataTotalPagosAtrasadoIDPago(fecha);
        }
        public DataTable NumeroPagosAtrasados(DateTime fecha)
        {
            return TOTAP.GetDataTotalPagosAtrasados(fecha);
        }
        public DataTable CantidadPagos(int agencias)
        {
            return VERIFICAR.GetDataVerificarSiHayPagos(agencias);
        }
        public DataTable PaganHoy( int agencia)
        {
            return LISTADOPAGAN.GetDataPaganHoy(agencia);
 
        }
    }
}
