using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetModificarEmpresaAgenciaTableAdapters;
using System.Data;

namespace BLL
{
    public class ModificacionConfiEmpresa
    {
        ModificacionEmpresaTableAdapter empresa = new ModificacionEmpresaTableAdapter();
        private ModificacionEmpresaTableAdapter EMPRESA
        {
            get { return empresa; }
        }

        ModificacionAgenciaTableAdapter agencia = new ModificacionAgenciaTableAdapter();
        private ModificacionAgenciaTableAdapter AGENCIA
        {
            get { return agencia; }
        }

        ModificacionOmitirDiasTableAdapter dias = new ModificacionOmitirDiasTableAdapter();
        private ModificacionOmitirDiasTableAdapter DIAS
        {
            get { return dias; }
        }
        AgregarCapitalAgenciaTableAdapter capi = new AgregarCapitalAgenciaTableAdapter();
        private AgregarCapitalAgenciaTableAdapter CAPI
        {
            get { return capi; }
        }
        //metodos
        public void AgregarCapital(int codigo, decimal capital)
        {
            CAPI.GetDataAgregarCapital(codigo, capital);
        }
        public void ModEmpresa(int codigo,string nombre, bool estado)
        {
            EMPRESA.GetDataModEmpresa(codigo,nombre, estado);
        }

        public void ModAgencia(int codigo,string nombreagencia, string direccionagencia, string telefonosagencia, bool estadoagencia, string departamento, string municipio, Decimal capital, int idempresa)
        {
            AGENCIA.GetDataModAgencia(codigo,nombreagencia, direccionagencia, telefonosagencia, estadoagencia, departamento, municipio, capital, idempresa);

        }

        public void ModOmitirDias(int codigo,DateTime fecha, bool estado, string descripcion)
        {
            DIAS.GetDataModOmitirDias(codigo,fecha, estado, descripcion);
        }

    }
}
