using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetIngresosConfiEmpleadosTableAdapters;
using System.Data;

namespace BLL
{
    public class IngresosConfiEmpleados
    {
        AgregarPuestoTableAdapter puesto = new AgregarPuestoTableAdapter();
        private AgregarPuestoTableAdapter PUESTO
        {
            get { return puesto; }
        }

        

        AgregarUsuariosPermisoTableAdapter usper = new AgregarUsuariosPermisoTableAdapter();
        private AgregarUsuariosPermisoTableAdapter USPER
        {
            get { return usper; }
        }

        AgregarPagoPlanillaTableAdapter pago = new AgregarPagoPlanillaTableAdapter();
        private AgregarPagoPlanillaTableAdapter PAGO
        {
            get { return pago; }
        }

        SaberSitieneUsuarioTableAdapter us = new SaberSitieneUsuarioTableAdapter();
        private SaberSitieneUsuarioTableAdapter US
        {
            get { return us; }
        }

        SaberIDEmpleadoPOrPersonaTableAdapter emplea = new SaberIDEmpleadoPOrPersonaTableAdapter();
        private SaberIDEmpleadoPOrPersonaTableAdapter EMPLEA
        {
            get { return emplea; }
        }
        ConocerUsuarioPOEmpleadoTableAdapter usa = new ConocerUsuarioPOEmpleadoTableAdapter();
        private ConocerUsuarioPOEmpleadoTableAdapter USA
        {
            get { return usa; }
        }

        LIstarPermisosTableAdapter verp = new LIstarPermisosTableAdapter();
        private LIstarPermisosTableAdapter VERP
        {
            get { return verp; }
        }
        ///metodos
        
        public DataTable ListarPermisos(int empleado)
        {
            return VERP.GetDataListarPermisos(empleado);

        }
        public DataTable ConocerUsuarioE(int emplead)
        {
            return USA.GetDataConocerUsuario(emplead);
        }

        public DataTable SaberIDEmpleadoP(int persona)
        {
            return EMPLEA.GetDataIDEMpleadoPer(persona);
        }

        public DataTable SaberSiTieneUsuario(int empleado)
        {
           return  US.GetDataSaberSiTieneUsuario(empleado);
        }
        public void Puesto(string nombrepuesto, string descpuesto, bool estado)
        {
            PUESTO.GetDataPuesto(nombrepuesto, descpuesto, estado);
 
        }

      

        public void UsuarioPermiso(int usuario )
        {
            USPER.GetDataUsuarioPermiso(usuario);

        }

        public void PagoPlanilla(Decimal montocomision, decimal sueldototal, bool estadopago, DateTime fechapago, int idempleado)
        {

            PAGO.GetDataPagoPlanilla(montocomision, sueldototal, estadopago, fechapago, idempleado);
        }

    }
}
