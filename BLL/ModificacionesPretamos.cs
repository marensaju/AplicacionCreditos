using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetModificarPrestamosTableAdapters;
using System.Data;

namespace BLL
{
    public class ModificacionesPretamos
    {
        

        RealizarPagoTableAdapter pagos = new RealizarPagoTableAdapter();
        private RealizarPagoTableAdapter PAGO
        {
            get { return pagos; }
        }

        ModificacionChequeTableAdapter cheque = new ModificacionChequeTableAdapter();
        private ModificacionChequeTableAdapter CHEQUE
        {
            get { return cheque; }
        }

        ModificarPlanTableAdapter plan = new ModificarPlanTableAdapter();
        private ModificarPlanTableAdapter PLAN
        {
            get { return plan; }
        }

       ModificacionMoraTableAdapter mora = new ModificacionMoraTableAdapter();
        private ModificacionMoraTableAdapter MORA
        {
            get { return mora; }
        }

        ModificacionGarantiaTableAdapter garantia = new ModificacionGarantiaTableAdapter();
        private ModificacionGarantiaTableAdapter GARANTIA
        {
            get { return garantia; }
        }
        AuorizacionPrestamoPrimeraTableAdapter autorizacion = new AuorizacionPrestamoPrimeraTableAdapter();
        private AuorizacionPrestamoPrimeraTableAdapter AUTO
        {
            get { return autorizacion; }
        }
      
      
//metodo
        public void Autorizacion(int codigo, bool auto, bool estado)
        {
            AUTO.GetDataAutorizarPrestamoPrimera(codigo, auto, estado);
        }
        public void ModGarantia(int codigo,string descripcion, string modelo, string seria, Decimal valor, int idprestamo)
        {
            GARANTIA.GetDataModGarantia(codigo,descripcion, modelo, seria, valor, idprestamo);
        }
        public void ModMora(int codigo,string nombre, string texto, Decimal cantidad, bool estadomora)
        {
            MORA.GetDataModMora(codigo,nombre, texto, cantidad, estadomora);

        }
        public void MOdPlan(int codigo,string nombreplan, string descripcionplan, int periodo, bool dias, bool semana, bool mes, int cantidadinteres, int idmora)
        {
            PLAN.GetDataModPlan(codigo,nombreplan, descripcionplan, periodo, dias, semana, mes, cantidadinteres, idmora);
        }
        public void ModCheque(int codigo,int idprestamo, Decimal monto, string letras, bool negociable)
        {
            CHEQUE.GetDataModCheque(codigo,idprestamo, monto, letras, negociable);
        }
        public void RealizarPago( int codigo, bool estadopago, DateTime fecha, int empleado, bool mora)
        {

            PAGO.GetDataRealizarPago(codigo, estadopago, fecha, empleado, mora);
        }
    }
}
