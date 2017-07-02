using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetModificacionPersonasTableAdapters;
using System.Data;

namespace BLL
{
    public class ModificarPersonas
    {
        ModificarPersonaTableAdapter  persona = new ModificarPersonaTableAdapter();
        private ModificarPersonaTableAdapter PERSONA
        {
            get { return persona; }
        }

       ModificacionClienteTableAdapter cliente = new ModificacionClienteTableAdapter();
        private ModificacionClienteTableAdapter CLIENTE
        {
            get { return cliente; }
        }

       ModificacionEmpleadoTableAdapter empleado = new ModificacionEmpleadoTableAdapter();
        private ModificacionEmpleadoTableAdapter EMPLEADO
        {
            get { return empleado; }
        }

       ModificacionReferenciaTableAdapter referencia = new ModificacionReferenciaTableAdapter();
        private ModificacionReferenciaTableAdapter REFERENCIA
        {
            get { return referencia; }
        }

        ModificacionUsuariosTableAdapter usuarios = new ModificacionUsuariosTableAdapter();
        private ModificacionUsuariosTableAdapter USUARIOS
        {
            get { return usuarios; }
        }



        ///metodos
        public void ModPersona(int codigo, string dpi, string primernombre, string segundonombre, string primerapellido, string segundoapellido, DateTime fecha, string telefonos, string direccion, string ciudad, string municipio, string correo, bool estado, string extdpi, string profesion, string civil, bool genero, bool domicilio, string foto, string tel2,int agencia)
        {
            PERSONA.GetDataModPersona(codigo,dpi, primernombre, segundonombre, primerapellido, segundoapellido, fecha, telefonos, direccion, ciudad, municipio, correo, estado, extdpi, profesion, civil, genero, domicilio, foto,agencia,tel2);
        }

        public void ModCliente(int codigo,DateTime fecharegistro, string lugartrabajo, string direcciontrabajo, string telefonotrabajo, string tiempolaborarempresa, string observaciones)
        {
            CLIENTE.GetDataModCliente(codigo,fecharegistro, lugartrabajo, direcciontrabajo, telefonotrabajo, tiempolaborarempresa, observaciones);
        }

        public void ModEmpleado(int codigo, DateTime fechacontra, bool estadoempleado, Decimal sueldo, int porcentajecomision, Decimal CantidadCobroComision, int idpuesto)
        {   
            EMPLEADO.GetDataModEmpleado(codigo,fechacontra, estadoempleado, sueldo, porcentajecomision, CantidadCobroComision, idpuesto);
        }

        public void ModReferencia(int codigo, string nombrereferencia, string direccionreferencia, string telefonoreferencia, bool estado)
        {
            REFERENCIA.GetDataModReferencia(codigo,nombrereferencia, direccionreferencia, telefonoreferencia, estado);
        }

        public void ModUsuario(int codigo, string contrasena)
        {
            USUARIOS.GetDataGetDataModUsuarios(codigo, contrasena);
        }


    }
}
