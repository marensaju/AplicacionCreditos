using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetIngresosPrestamosTableAdapters;
using System.Data;

namespace BLL
{
   public class IngresosPrestamos
    {
       AgregarPrestamoTableAdapter prestamo = new AgregarPrestamoTableAdapter();
       private AgregarPrestamoTableAdapter PRESTAMO
       {
           get { return prestamo; }
       }

       AgregarPagosTableAdapter pagos = new AgregarPagosTableAdapter();
       private AgregarPagosTableAdapter PAGO
       {
           get { return pagos; }
       }

       AgregarChequeTableAdapter cheque = new AgregarChequeTableAdapter();
       private AgregarChequeTableAdapter CHEQUE 
       {
           get { return cheque; }
       }

       AgregarPlanTableAdapter plan = new AgregarPlanTableAdapter();
       private AgregarPlanTableAdapter PLAN
       {
           get { return plan; }
       }

       AgregarMoraTableAdapter mora = new AgregarMoraTableAdapter();
       private AgregarMoraTableAdapter MORA
       {
           get { return mora; }
       }

       AgregarGarantiaTableAdapter garantia = new AgregarGarantiaTableAdapter();
       private AgregarGarantiaTableAdapter GARANTIA 
       {
           get { return garantia; }
       }
       ListarPlanesTableAdapter lplanes = new ListarPlanesTableAdapter();
       private ListarPlanesTableAdapter LPLANES
       {
           get { return lplanes; }
       }

       ListaEditarPlanTableAdapter ledit = new ListaEditarPlanTableAdapter();
       private ListaEditarPlanTableAdapter LEDIT
       {
           get { return ledit; }
       }

       LIstaEditarMoraTableAdapter lmora = new LIstaEditarMoraTableAdapter();
       private LIstaEditarMoraTableAdapter LMORA
       {
           get { return lmora; }
       }
       //metodo
       public DataTable InfoParaEditarMora(int mora)
       {
           return LMORA.GetDataListaEditarMora(mora);
       }
       public DataTable InfoParaEditaPlan(int plan)
       {
           return LEDIT.GetDataListarEditarPlan(plan);
       }
       public DataTable ListarPlanes()
       {
           return LPLANES.GetDataListarPlanes();
       }
       public void Garantia(string descripcion, string modelo, string seria, Decimal valor, int idprestamo)
       {
           GARANTIA.GetDataGarantia(descripcion, modelo, seria, valor, idprestamo);
       }
       public void Mora(string nombre, string texto, Decimal cantidad, bool estadomora) 
       {
           MORA.GetDataMora(nombre, texto, cantidad, estadomora);

       }
       public void Plan(string nombreplan, string descripcionplan, int periodo, bool dias, bool semana, bool mes, int cantidadinteres, int idmora)
       {
           PLAN.GetDataPlan(nombreplan, descripcionplan, periodo, dias, semana, mes, cantidadinteres, idmora);
       }
       public void Cheque(int idprestamo, Decimal monto, string letras, bool negociable)
       {
           CHEQUE.GetDataCheque(idprestamo, monto, letras, negociable);
       }
       public void Pagos(Decimal cuota, decimal mora, DateTime fechapago, bool estadopago,Decimal pagorealizar, Decimal saldo, int idprestamo, bool pagomora)
       {

           PAGO.GetDataPagos(cuota, mora, fechapago, estadopago, pagorealizar, saldo, idprestamo,pagomora);
       }


       public void Prestamo(Decimal monto, string observacion, bool tipoprestamo, Decimal montointeres, bool autorizacion, bool estadoprestamo, int cliente, int empleado, int plan, DateTime fecha, bool registro, bool desembolso)
       {
           PRESTAMO.GetDataPrestamo(monto, observacion, tipoprestamo, montointeres, autorizacion, estadoprestamo, cliente, empleado, plan,fecha, registro, desembolso);
 
       }

    }
}
