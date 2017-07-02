using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetIngresoBitacoraTableAdapters;
namespace BLL
{
    public class Bitacora
    {
        AgregarBitacoraTableAdapter bita = new AgregarBitacoraTableAdapter();
        private AgregarBitacoraTableAdapter BITA
        {
            get { return bita; }
        }
        //metodo 
        public void RegistrarBitacora(string accion, string observacion, int empleado)
        {
            BITA.GetDataInsertarbitacora(accion, observacion, empleado);
        }
    }
}
