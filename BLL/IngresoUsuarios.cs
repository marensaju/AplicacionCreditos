using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IngresoApliTableAdapters;
using System.Data;

namespace BLL
{
   public class IngresoUsuarios
    {
        LoginUsuarioTableAdapter loge = new LoginUsuarioTableAdapter();
        private LoginUsuarioTableAdapter LOG
        {
            get { return loge; }
        }
        saberAgenciaTableAdapter sabe = new saberAgenciaTableAdapter();
        private saberAgenciaTableAdapter SABE
        {
            get { return sabe; }
        }
        //metodo
        public string s(string us, string con, string me)
        {
            SABE.GetDataSaberAgen(us,con, ref me);
            return me;
        }
        public string i(string n, string p, string t)
        {
            LOG.GetDataloginUsuarios(n, p, ref t);
            return t;

        }


    }
}
