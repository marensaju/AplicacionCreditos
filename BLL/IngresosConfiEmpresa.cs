using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetIngresoEmpresaAgenciaTableAdapters;
using System.Data;

namespace BLL
{
    public class IngresosConfiEmpresa
    {
        AgregarEmpresaTableAdapter empresa = new AgregarEmpresaTableAdapter();
        private AgregarEmpresaTableAdapter EMPRESA
        {
            get { return empresa; }
        }

        AgregarAgenciaTableAdapter agencia = new AgregarAgenciaTableAdapter();
        private AgregarAgenciaTableAdapter AGENCIA
        {
            get { return agencia; }
        }

        AgregarOmitirDiasTableAdapter dias = new AgregarOmitirDiasTableAdapter();
        private AgregarOmitirDiasTableAdapter DIAS
        {
            get { return dias; }
        }
        ListadoAgenciasTableAdapter liagen = new ListadoAgenciasTableAdapter();
        private ListadoAgenciasTableAdapter LIAGEN
        {
            get { return liagen; }
        }

        ListadoAgenciasEditarTableAdapter ediagen = new ListadoAgenciasEditarTableAdapter();
        private ListadoAgenciasEditarTableAdapter EDIAGEN
        {
            get { return ediagen; }
        }

        ListarMoraTableAdapter lmora = new ListarMoraTableAdapter();
        private ListarMoraTableAdapter LMORA
        {
            get { return lmora; }
        }

         ListadoDeFeriadosTableAdapter feria = new ListadoDeFeriadosTableAdapter();
         private ListadoDeFeriadosTableAdapter FERIA
         {
             get { return feria; }
         }

         EliminarFeriadosTableAdapter eli = new EliminarFeriadosTableAdapter();
         private EliminarFeriadosTableAdapter ELI
         {
             get { return eli; }
         }
        //metodos

         public void EliminarDiasFeriado(int id)
         {
             ELI.GetDataEliminarFeriados(id);
         }
         public DataTable VerFeriados()
         {
             return FERIA.GetDataFeriados();
         }
        public DataTable ListarMora()
        {
            return LMORA.GetDataListarMora();
        }
        public DataTable LIstadoEditarAgencias(int agencia)
        {
            return EDIAGEN.GetDataListaEditarAgencias(agencia); 
        }
        public DataTable ListadoAgencias(int empresa)
        {
            return LIAGEN.GetDataListadoAgencias(empresa);
        }
        public void Empresa(string nombre, bool estado)
        {
            EMPRESA.GetDataEmpresa(nombre, estado);
        }

        public void Agencia(string nombreagencia, string direccionagencia, string telefonosagencia, bool estadoagencia, string departamento, string municipio, Decimal capital, int idempresa)
        {
            AGENCIA.GetDataAgencia(nombreagencia, direccionagencia, telefonosagencia, estadoagencia, departamento, municipio, capital, idempresa);
 
        }

        public void OmitirDias(DateTime fecha,bool estado,string descripcion)
        {
            DIAS.GetDataOmitirDias(fecha, estado, descripcion);
        }




    }
}
