using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ListarEmpleadosTableAdapters;
using System.Data;

namespace BLL
{
    public class VerEmplead
    {

        VerEmpleadoGridTableAdapter verE = new VerEmpleadoGridTableAdapter();
        private VerEmpleadoGridTableAdapter VERe
        {
            get { return verE; }
        }
        FindEmpleadoTableAdapter feme = new FindEmpleadoTableAdapter();
        private FindEmpleadoTableAdapter FEME
        {
            get { return feme; }
        }

        ListadoReferenciaTableAdapter refe = new ListadoReferenciaTableAdapter();
        private ListadoReferenciaTableAdapter REFE
        {
            get { return refe; }
        }
        perfilEmpleadoTableAdapter perfil = new perfilEmpleadoTableAdapter();
        private perfilEmpleadoTableAdapter PERFIL
        {
            get { return perfil; }
        }
        InfoActualizarEmpleadoTableAdapter infoca = new InfoActualizarEmpleadoTableAdapter();
        private InfoActualizarEmpleadoTableAdapter INFOCA
        {
            get { return infoca; }
        }

        SaberPuestoEmpleadoTableAdapter sabe = new SaberPuestoEmpleadoTableAdapter();
        private SaberPuestoEmpleadoTableAdapter SABE
        {
            get { return sabe; }
        }
        ///metodo
        ///
        public DataTable SaberPuesto(int persona)
        {
            return SABE.GetDataSaberPue(persona);
        }
        public DataTable InfoActualizarEmpleado(int persona)
        {
            return INFOCA.GetDataInfoActClientes(persona);
        }
        public DataTable PErfilClientes(int empleado)
        {
            return PERFIL.GetDataPerfiEmpleado(empleado);
        }
        public DataTable ReferenciasEmpleado(int persona)
        {
            return REFE.GetDataReferencias(persona);
        }
        public DataTable FinEmpleado(string nombre, int agencia)
        {
            return FEME.GetDataFinEmpleado(nombre, agencia);
        }
        public DataTable ListaEmpleados(int agencia)
        {
            return VERe.GetDataVerEmpleadosG(agencia);
        }

    }
}
