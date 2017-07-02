using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetPrestamosTableAdapters;
using System.Data;
namespace BLL
{  
   
    public class PrestamosTodo
    {
        AsesorDropDownListTableAdapter ase = new AsesorDropDownListTableAdapter();
        private   AsesorDropDownListTableAdapter ASE
        {
            get { return ase; }
        }

        PlanDropDownListTableAdapter pla = new PlanDropDownListTableAdapter();
        private PlanDropDownListTableAdapter PLA
        {
            get { return pla; }
        }
        SaberCantidaInteresTableAdapter sabein = new SaberCantidaInteresTableAdapter();
        private SaberCantidaInteresTableAdapter SabeIn
        {
            get { return sabein; }
        }


        SaberIdClienteTableAdapter idcli = new SaberIdClienteTableAdapter();
        private SaberIdClienteTableAdapter IDCLI
        {
            get { return idcli; }
        }

        ultimoprestamoTableAdapter ulti = new ultimoprestamoTableAdapter();
        private ultimoprestamoTableAdapter ULTI
        {
            get { return ulti; }
        }
        ConsultaDiasFeriadoTableAdapter feriado = new ConsultaDiasFeriadoTableAdapter();
        private ConsultaDiasFeriadoTableAdapter FERIADO
        {
            get { return feriado; }
        }
        CantidadDiasFeriadoTableAdapter canti = new CantidadDiasFeriadoTableAdapter();
        private CantidadDiasFeriadoTableAdapter CANTI
        {
            get { return canti; }
        }

        InfoPlanTableAdapter infop = new InfoPlanTableAdapter();
        private InfoPlanTableAdapter INFOP
        {
            get { return infop; }
         }

        PorAprobarTableAdapter apro = new PorAprobarTableAdapter();
        private PorAprobarTableAdapter APRO
        {
            get { return apro; }
        }

        InfoPrestamoTab1TableAdapter info1 = new InfoPrestamoTab1TableAdapter();
        private InfoPrestamoTab1TableAdapter INFO 
        {
            get { return info1; }
        }
        PrecalificarTableAdapter preca = new PrecalificarTableAdapter();
        private PrecalificarTableAdapter PRECA
        {
            get { return preca; }
        }
        InfoTab2TableAdapter tab2 = new InfoTab2TableAdapter();
        private InfoTab2TableAdapter TAB2
        {
            get { return tab2; }
        }
        GarantiasPrestamoTableAdapter gara = new GarantiasPrestamoTableAdapter();
        private GarantiasPrestamoTableAdapter GARA
        {
            get { return gara; }
        }
        PorDesembolsoTableAdapter dese = new PorDesembolsoTableAdapter();
        private PorDesembolsoTableAdapter DESE
        {
            get { return dese; }
        }

        DesembolsarTableAdapter bolsar = new DesembolsarTableAdapter();
        private DesembolsarTableAdapter BOLSAR
        {
            get { return bolsar; }
        }
        EliminarGarantiasTableAdapter eligaran = new EliminarGarantiasTableAdapter();
        private EliminarGarantiasTableAdapter ELIGran
        {
            get { return eligaran; }
        }
        EliminarPrestamosTableAdapter elipre = new EliminarPrestamosTableAdapter();
        private EliminarPrestamosTableAdapter ELIPRE
        {
            get { return elipre; }
        }

        PlanDePrestamoTableAdapter planito = new PlanDePrestamoTableAdapter();
        private PlanDePrestamoTableAdapter PLANITO
        {
            get { return planito; }
        }
        TablaPagosTabTableAdapter tablapagos = new TablaPagosTabTableAdapter();
        private TablaPagosTabTableAdapter TABLAPAGOS
        {
            get { return tablapagos; }
        }
        EliminarTodolosPagosDelPrestamoTableAdapter Eli = new EliminarTodolosPagosDelPrestamoTableAdapter();
        private EliminarTodolosPagosDelPrestamoTableAdapter ELI
        {
            get { return Eli; }
        }
        MontoChequeTableAdapter moto = new MontoChequeTableAdapter();
        private MontoChequeTableAdapter MOTO
        {
            get { return moto; }
        }
        procedureSaberSiTieneChequeTableAdapter sc = new procedureSaberSiTieneChequeTableAdapter();
        private procedureSaberSiTieneChequeTableAdapter SC
        {
            get { return sc; }
         }
        HistorialPrestamosGeneralTableAdapter pg = new HistorialPrestamosGeneralTableAdapter();
        private HistorialPrestamosGeneralTableAdapter PG
        {
            get { return pg; }
        }

        TabPagosEfectuadosTableAdapter pagui = new TabPagosEfectuadosTableAdapter();
        private TabPagosEfectuadosTableAdapter PAGUI
        {
            get { return pagui; }
        }
        TotalTabPagosEfectuadosTableAdapter tota = new TotalTabPagosEfectuadosTableAdapter();
        private TotalTabPagosEfectuadosTableAdapter TOTA
        {
            get { return tota; }
        }
        AnularPagoTableAdapter anula = new AnularPagoTableAdapter();
        private AnularPagoTableAdapter ANULA
        {
            get { return anula; }
        }
        SumaHistorialPrestamosGeneralTableAdapter suma = new SumaHistorialPrestamosGeneralTableAdapter();
        private SumaHistorialPrestamosGeneralTableAdapter SUMA
        {
            get { return suma; }
        }

        GuardarContratoTableAdapter contra = new GuardarContratoTableAdapter();
        private GuardarContratoTableAdapter CONTRA
        {
            get { return contra; }
        }

        ContratoTableAdapter Infoc = new ContratoTableAdapter();
        private ContratoTableAdapter INFOC
        {
            get { return Infoc; }
        }
        SaberInicioYFinalPrestamoTableAdapter ifa = new SaberInicioYFinalPrestamoTableAdapter();
        private SaberInicioYFinalPrestamoTableAdapter IFA
        {
            get { return ifa; }
        }

        GarantiasContratoTableAdapter gcon = new GarantiasContratoTableAdapter();
        private GarantiasContratoTableAdapter GCON
        {
            get { return gcon; }
        }
        NoPuedePrestarTableAdapter nopre = new NoPuedePrestarTableAdapter();
        private NoPuedePrestarTableAdapter NOPRE
        {
            get { return nopre; }
        }

        SaberSiPuedePrestarTableAdapter sipuede = new SaberSiPuedePrestarTableAdapter();
        private SaberSiPuedePrestarTableAdapter SIPUEDE
        {
            get { return sipuede; }
        }

        PermitirPrestarTableAdapter permip = new PermitirPrestarTableAdapter();
        private PermitirPrestarTableAdapter PERMIP
        {
            get { return permip; }
        }
        //metodo 
        public void PermitirPrestar(int cliente)
        {
            PERMIP.GetDataPermitirPrestar(cliente);
        }
        public DataTable SipuedePrestar(int persona)
        {
           return SIPUEDE.GetDataSaberSiPuedePrestar(persona);
        }
        public void NoPUedePrestar(int cliente)
        {
            NOPRE.GetDataNoPuedePrestar(cliente);
        }
        public DataTable GarantiasContrato(int prestamo)
        {
            return GCON.GetDataGarantiasContrato(prestamo);
        }

        public DataTable FechaInicialYFinal(int prestamo)
        {
            return IFA.GetDataFechaInicialYFinal(prestamo);
        }
        public DataTable INFOPARACONTRATO(int prestamo)
        {
            return INFOC.GetDataInfoContrato(prestamo);
        }
        public void CrearContrato(string cliente, string edad, string estadocivil, string profesion, string direccion, string dpi, string montoMasInteres, string periodo, string cuota, string Finicio, string Ffinal, string MoraCuota, string diasSemanas, string garantias, string DirAgencia, bool EstadoPre, string nacionalidad, int presta)
        {
            CONTRA.GetDataGuardarContrato(cliente, edad, estadocivil, profesion, direccion, dpi, montoMasInteres, periodo, cuota, Finicio, Ffinal, MoraCuota, diasSemanas, garantias, DirAgencia, EstadoPre,nacionalidad,presta);
        }
        public DataTable SumaPrestamos(int agencia, DateTime f1, DateTime f2)
        {
            return SUMA.GetDataSumaHistoPresta(agencia, f1, f2);
        }
        public DataTable AnularPago(int idpago)
        {
            return ANULA.GetDataAnularPago(idpago);
        }
        public DataTable TOTAlPagosTab4(int prestamo)
        {
            return TOTA.GetDataTotaltabPagosEfectuado(prestamo);
        }
        public DataTable TabPagosEfectuados(int prestamos)
        {
            return PAGUI.GetDataTabPagosEfectuados(prestamos); 
        }
        public DataTable HPrestamosGeneral(int agencia, DateTime f1, DateTime f2) 
        {
            return PG.GetDataHitoPrestamoGeneral(agencia, f1, f2);
        }
        public DataTable SaberSiTieneCheque(int prestamo)
        {
            return SC.GetDataSaberCuantosCheques(prestamo);
        }
        public DataTable MontoDeCheque(int prestamos)
        {
            return MOTO.GetDataMontoCheque(prestamos);
        }
        public DataTable EliminarPagosPRestamo(int prestamo)
        {
            return ELI.GetDataEliminarTodosLosPagos(prestamo);
        }
        public DataTable TablaPagosTab(int prestamo)
        {
            return TABLAPAGOS.GetDataTablaPagosTab(prestamo);
        }
        public DataTable SaberIdPrestamoPlan(int prestamo)
        {
            return PLANITO.GetDataPlanPrestamo(prestamo);
        }
        public DataTable EliminarPrestamo(int prestamo)
        {
            return ELIPRE.GetDataEliminarPrestamos(prestamo);
        }
        public DataTable EliminarGarantia(int prestamo)
        {
            return ELIGran.GetDataEliminarGarantias(prestamo);
        }
        public DataTable Desembolsar(bool estado, int prestamo)
        {
            return BOLSAR.GetDataDesembolsar(estado, prestamo);
        }
        public DataTable ListaDesembolso(int agencia)
        {
            return DESE.GetDataPorDesembolso(agencia);
        }
        public DataTable GarantiasPrestamo(int prestamo )
        {
            return GARA.GetDataGarantiasPrestamo(prestamo);
        }
        public DataTable InfoTab2(int prestamo)
        {
            return TAB2.GetDataInfoTab2(prestamo);
        }
        public DataTable Precalificar(bool tipo, int prestamo)
        {
            return PRECA.GetDataPrecalificar(tipo, prestamo);
        }
        public DataTable InfoTabUNO(int prestamo)
        {
            return INFO.GetDataInfoTabUno(prestamo);
        }


        public DataTable LIstadoPOrAprobar(int agencia)
        {
            return APRO.GetDataPorAprobar(agencia);
        }
        public DataTable InfoPlan(int idplan)
        {
            return INFOP.GetDataInfoplan(idplan);
 
        }
        public DataTable CantidadDiasFeriados( DateTime fecha)
        {
            return CANTI.GetDataCantiDiasFeriado(fecha);
        }
        public DataTable FechasFeriado(DateTime hoy)
        {
            return FERIADO.GetDataConsultaDiasFeriado(hoy);
        }
           

        public DataTable UltimoPrestamo()
        {
            return ULTI.GetDataUlitmoPresta();
        }
        public DataTable SaberIDcliente(int persona)
        {
            return IDCLI.GetDataSaberCliente(persona);
        }
        public DataTable SaberCantidadInteres(int plan)
        {
            return SabeIn.GetDataSaberCantidaInteress(plan);
        }

        public DataTable PlanDropDown()
        {
            return PLA.GetDataPlanDrop();
        }
        public DataTable ListarAsesor(int puesto, int agencia)
        {
            return ASE.GetDataAsesorDrop(puesto, agencia);
        }



    }
}
