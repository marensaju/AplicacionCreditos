using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ReporteListarClientesTableAdapters;
using System.Data;

namespace BLL
{
   public class VerClientes
    {
       

       VerClientesGridTableAdapter lis = new VerClientesGridTableAdapter();
       private VerClientesGridTableAdapter LIS
       {
           get { return lis; }
       }

       perfilclientesTableAdapter perfi = new perfilclientesTableAdapter();
       private perfilclientesTableAdapter PERFI
       {
           get { return perfi; }
       }

       ListadoReferenciaTableAdapter refe = new ListadoReferenciaTableAdapter();
       private ListadoReferenciaTableAdapter REFE
       {
           get { return refe; }

       }
       historialPrestamosTableAdapter histo = new historialPrestamosTableAdapter();
       private historialPrestamosTableAdapter HISTO
       {
           get { return histo; }
       }
       FindClienteTableAdapter fi = new FindClienteTableAdapter();
       private FindClienteTableAdapter FI
       {
           get { return fi; }
       }
       EnviarAListaNegraTableAdapter lNegra = new EnviarAListaNegraTableAdapter();
       private EnviarAListaNegraTableAdapter LNEGRA
       {
           get { return lNegra; }
       }

       InfoActualizarClienteTableAdapter infoc = new InfoActualizarClienteTableAdapter();
       private InfoActualizarClienteTableAdapter INFOC
       {
           get { return infoc; }
       }

       ReferenciasClienteTableAdapter refc = new ReferenciasClienteTableAdapter();
       private ReferenciasClienteTableAdapter REFC
       {
           get { return refc;}
       }

       VerClienteslistanegraGridTableAdapter negra = new VerClienteslistanegraGridTableAdapter();
       private VerClienteslistanegraGridTableAdapter NEGRA
       {
           get { return negra; }
       }
       QuitarDeListaNegraTableAdapter quita = new QuitarDeListaNegraTableAdapter();
       private QuitarDeListaNegraTableAdapter QUITA
       {
           get { return quita; }
       }

       FindClienteNegraTableAdapter fn = new FindClienteNegraTableAdapter();
       private FindClienteNegraTableAdapter FN
       {
           get { return fn; }
       }
       ////
       public DataTable NegraFincliente(string texto, int agencia)
       {
           return FN.GetDataFinClienteNegra(texto, agencia);
       }
       public DataTable QuitardeLista(int cliente)
       {
           return QUITA.GetDataQuitarLista(cliente);
       }

       public DataTable ListaNegra(int agencia)
       {
           return NEGRA.GetDataListaNegra(agencia);
       }
       public DataTable ReferenciasCli(int perso)
       {
           return REFC.GetDataRefCliente(perso);
       }
       public DataTable InfoClientes(int codigop)
       {
           return INFOC.GetDataInfoActualizarC(codigop);
 
       }
       public void EnviarListaNegra(int codigo)
       {
           LNEGRA.GetDataEnviarListaNEgra(codigo);
       }

       public DataTable FINDCLIENTEE(string texto, int agencia)
       {
           return FI.GetDataFindCli(texto, agencia);
       }
       public DataTable Historiales(int persona)
       {
           return HISTO.GetDataHistoPrestamo(persona);
       }
       public DataTable Listadore(int persona)
       {
           return REFE.GetDataListadoReferencia(persona);
       }
       public DataTable VERCLIENTES(int agencia)
       {
           return LIS.GetDataListadoGrid1(agencia);
 
       }

       public DataTable PerfilC(int agencia)
       {
           return PERFI.GetDataPerfilClientes(agencia);
       }

    }
}
