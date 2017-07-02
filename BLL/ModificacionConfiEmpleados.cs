using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetModificarConfiEmpleadosTableAdapters;
using System.Data;

namespace BLL
{
    public class ModificacionConfiEmpleados
    {
     ModificacionPuestoTableAdapter puesto = new ModificacionPuestoTableAdapter();
        private ModificacionPuestoTableAdapter PUESTO
        {
            get { return puesto; }
        }

        

        ModificacionUsuariosPermisoTableAdapter usper = new ModificacionUsuariosPermisoTableAdapter();
        private ModificacionUsuariosPermisoTableAdapter USPER
        {
            get { return usper; }
        }

        ModificacionPagoPlanillaTableAdapter pago = new ModificacionPagoPlanillaTableAdapter();
        private ModificacionPagoPlanillaTableAdapter PAGO
        {
            get { return pago; }
        }


        ///metodos
        public void ModPuesto(int codigo,string nombrepuesto, string descpuesto, bool estado)
        {
            PUESTO.GetDataModPuesto(codigo,nombrepuesto, descpuesto, estado);
 
        }

       
        public void ModUsuarioPermiso(int codigo, int usuario, int idpermiso, bool estado )
        {
            USPER.GetDataAsignarPermisos(codigo,usuario, idpermiso, estado);

        }

        public void ModPagoPlanilla(int codigo,Decimal montocomision, decimal sueldototal, bool estadopago, DateTime fechapago, int idempleado)
        {

            PAGO.GetDataModPagoPlanilla(codigo,montocomision, sueldototal, estadopago, fechapago, idempleado);
        }
    }
}
