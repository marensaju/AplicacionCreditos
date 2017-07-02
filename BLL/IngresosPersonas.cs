using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetIngresoPersonasTableAdapters;
using System.Data;


namespace BLL
{
    public class IngresosPersonas
    {
        AgregarPersonaTableAdapter persona = new AgregarPersonaTableAdapter();
    private AgregarPersonaTableAdapter PERSONA
    {
        get { return persona; }
    }

    AgregarClienteTableAdapter cliente = new AgregarClienteTableAdapter();
    private AgregarClienteTableAdapter CLIENTE
    {
        get { return cliente; }
    }

    AgregarEmpleadoTableAdapter empleado = new AgregarEmpleadoTableAdapter();
    private AgregarEmpleadoTableAdapter EMPLEADO
    {
        get { return empleado; }
    }

    AgregarReferenciaTableAdapter referencia = new AgregarReferenciaTableAdapter();
    private AgregarReferenciaTableAdapter REFERENCIA
    {
        get { return referencia; }
    }

    AgregarUsuariosTableAdapter usuarios = new AgregarUsuariosTableAdapter();
    private AgregarUsuariosTableAdapter USUARIOS
    {
        get { return usuarios; }
    }
    ultimoidpersonaTableAdapter ulti = new ultimoidpersonaTableAdapter();
    private ultimoidpersonaTableAdapter ULTI
    {
        get { return ulti; }
    }
        
///metodos
///
       public DataTable ultimoID()
       {
          return  ULTI.GetDataUltimoID();

        }
    public void Persona(string dpi, string primernombre, string segundonombre, string primerapellido, string segundoapellido, DateTime fecha, string telefonos, string direccion, string ciudad, string municipio, string correo, bool estado, string extdpi, string profesion, string civil, bool genero, bool domicilio, string foto, string telre,int agencia)
    {
        PERSONA.GetDataPersona(dpi, primernombre, segundonombre, primerapellido, segundoapellido, fecha, telefonos, direccion, ciudad, municipio, correo, estado, extdpi, profesion, civil, genero, domicilio, foto,telre,agencia);
    }

    public void Cliente(DateTime fecharegistro, bool estado, string lugartrabajo, string direcciontrabajo, string telefonotrabajo,string tiempolaborarempresa, string observaciones, bool prestamoactivo, int idpersona,bool lita)
    {
        CLIENTE.GetDataCliente(fecharegistro, estado, lugartrabajo, direcciontrabajo, telefonotrabajo, tiempolaborarempresa, observaciones, prestamoactivo, idpersona,lita);
    }

    public void Empleado(DateTime fechacontra, bool estadoempleado, Decimal sueldo, int porcentajecomision, Decimal CantidadCobroComision, int idpuesto, int idpersona)
    {
        EMPLEADO.GetDataEmpleado(fechacontra, estadoempleado, sueldo, porcentajecomision, CantidadCobroComision, idpuesto, idpersona);
    }

    public void Referencia(string nombrereferencia, string direccionreferencia, string telefonoreferencia, bool estado, int idpersona)
    {
        REFERENCIA.GetDataReferencias(nombrereferencia, direccionreferencia, telefonoreferencia, estado, idpersona);
    }

    public void Usuario(string nombreuser, string contrasena, bool estado, int idempleado)
    {
        USUARIOS.GetDataUsuarios(nombreuser,contrasena,estado,idempleado);
    }



    }
}
