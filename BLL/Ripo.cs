using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSetReportesFInTableAdapters;
namespace BLL
{
   public  class Ripo
    {
       AgregarReportesTableAdapter arepo = new AgregarReportesTableAdapter();
       private AgregarReportesTableAdapter AREPO
       {
           get { return arepo; }
       }

       MODAgregarReportesTableAdapter mrepo = new MODAgregarReportesTableAdapter();
       private MODAgregarReportesTableAdapter MREPO
       {
           get { return mrepo; }
       }
       SaberUltimaFechaTableAdapter fe = new SaberUltimaFechaTableAdapter();
       private SaberUltimaFechaTableAdapter FE
       {
           get { return fe; }
       }
       InfoReporteTableAdapter infr = new InfoReporteTableAdapter();
       private InfoReporteTableAdapter INFR
       {
           get { return infr; }
       }

       SaldoTotalTableAdapter saldo = new SaldoTotalTableAdapter();
       private SaldoTotalTableAdapter SALDO
       {
           get { return saldo; }
       }

       SaberIDPRestamoPagoTableAdapter preta = new SaberIDPRestamoPagoTableAdapter();
       private SaberIDPRestamoPagoTableAdapter PRETA
       {
           get { return preta; }

   }
       ReporteBalanceTableAdapter balance = new ReporteBalanceTableAdapter();
       private ReporteBalanceTableAdapter BALANCE
       {
           get { return balance; }
       }

       ReporteMorosidadTableAdapter morosidad = new ReporteMorosidadTableAdapter();
       private ReporteMorosidadTableAdapter MOROSIDAD
       {
           get { return morosidad; }
       }

       ReporteCarteraVencidaTableAdapter carterA = new ReporteCarteraVencidaTableAdapter();
       private ReporteCarteraVencidaTableAdapter CARTERA
       {
           get { return carterA; }
       }

       ReporteCarteraMuertaTableAdapter muerta = new ReporteCarteraMuertaTableAdapter();
       private ReporteCarteraMuertaTableAdapter MUERTA
       {
           get { return muerta; }
       }
       CuotasPendienteInfoPrestamoTableAdapter cuo = new CuotasPendienteInfoPrestamoTableAdapter();
       private CuotasPendienteInfoPrestamoTableAdapter CUO
       {
           get { return cuo; }
       }
       ProxFechaPagoInfoPrestaTableAdapter pfecha = new ProxFechaPagoInfoPrestaTableAdapter();
       private ProxFechaPagoInfoPrestaTableAdapter PFECHA
       {
           get { return pfecha; }
       }

       SaldoTotalInfoPrestaTableAdapter saldot = new SaldoTotalInfoPrestaTableAdapter();
       private SaldoTotalInfoPrestaTableAdapter SALDOT
       {
           get { return saldot; }
       }
       SaldoCapitalInfoPrestaTableAdapter capi = new SaldoCapitalInfoPrestaTableAdapter();
       private SaldoCapitalInfoPrestaTableAdapter CAPI
       {
           get { return capi; }
       }
       //metodo
       public DataTable SaldoCapitalInfoPresta(int prestamo )
       {
           return CAPI.GetDataSaldoCapital(prestamo);
       }
       public DataTable SaldoTotalInfoPresta(int prestamo)
       {
           return SALDOT.GetDataSaldoTotal(prestamo);
       }
       public DataTable ProximaFechaInfoPResta(DateTime fecha, int prestamo)
       {
           return PFECHA.GetDataProximaFechaPago(fecha, prestamo);
       }
       public DataTable CuotasPendientesInfoPresta(int prestamo)
       {
           return CUO.GetDataCuotasPendientes(prestamo);
       }
       public DataTable CarteraMuerta(int agencia, int empleado)
       {
           return MUERTA.GetDataCarteraMuerta(agencia, empleado);
       }
       public DataTable ReporteCarteraVencida(int agencia, int empleado)
       {
           return CARTERA.GetDataCarteraVencida(agencia, empleado);
       }
       public DataTable ReporteMorosidad(int agencia, int emplead)
       {
           return MOROSIDAD.GetDataReporteMorosidad(agencia, emplead);
       }
       public DataTable ReporteBalance(int agencia, int empleado)
       {
           return BALANCE.GetDataBalance(agencia, empleado);
       }
       public DataTable SaberIDPrestamo(int pago)
       {
           return PRETA.GetDataSaberIDPrestamo(pago);
       }
       public DataTable SaldoTotal(int prestamo)
       {
           return SALDO.GetDataSaldoTotal(prestamo);
       }

       public DataTable InfoReporte(int prestamo)
       {
           return INFR.GetDataInfoReporte(prestamo);
       }
       public DataTable SaberFechaVencimiento(int prestamo)
       {
           return FE.GetDataUltimaFecha(prestamo);
       }
       public void ModificarAgregarReporte(int PagoAtrasados, Decimal MontoAtrasado, Decimal mora, Decimal MontoAMasMora,Decimal SaldoTotalMasMora,int prestamo)
       {
           MREPO.GetDataModificarAgregarReporte(PagoAtrasados, MontoAtrasado, mora, MontoAMasMora, SaldoTotalMasMora, prestamo);
       }
           public void AgregarReporte(int PagoAtrasados, Decimal MontoAtrasado, Decimal mora, Decimal MontoAMasMora,Decimal SaldoTotalMasMora,int prestamo, DateTime fechaV)
       {
           AREPO.GetDataAgregarReporte(PagoAtrasados,MontoAtrasado,mora,MontoAMasMora, SaldoTotalMasMora,prestamo, fechaV);
       }
    }
}
