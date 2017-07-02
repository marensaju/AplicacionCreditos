using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSetPermisosTableAdapters;
using System.Data;

namespace BLL
{
   public class Permisos
    {

       ActivarPermiso1TableAdapter per1 = new ActivarPermiso1TableAdapter();
       private ActivarPermiso1TableAdapter PER1
       {
           get { return per1; }
       }
       ActivarPermiso2TableAdapter per2 = new ActivarPermiso2TableAdapter();
       private ActivarPermiso2TableAdapter PER2
       {
           get { return per2; }
       }
       ActivarPermiso3TableAdapter per3 = new ActivarPermiso3TableAdapter();
       private ActivarPermiso3TableAdapter PER3
       {
           get { return per3; }
       }
       ActivarPermiso4TableAdapter per4 = new ActivarPermiso4TableAdapter();
       private ActivarPermiso4TableAdapter PER4
       {
           get { return per4; }
       }
       ActivarPermiso5TableAdapter per5 = new ActivarPermiso5TableAdapter();
       private ActivarPermiso5TableAdapter PER5
       {
           get { return per5; }
       }
       ActivarPermiso6TableAdapter per6 = new ActivarPermiso6TableAdapter();
       private ActivarPermiso6TableAdapter PER6
       {
           get { return per6; }
       }
       ActivarPermiso7TableAdapter per7 = new ActivarPermiso7TableAdapter();
       private ActivarPermiso7TableAdapter PER7
       {
           get { return per7; }
       }
       ActivarPermiso8TableAdapter per8 = new ActivarPermiso8TableAdapter();
       private ActivarPermiso8TableAdapter PER8
       {
           get { return per8; }
       }
       ActivarPermiso9TableAdapter per9 = new ActivarPermiso9TableAdapter();
       private ActivarPermiso9TableAdapter PER9
       {
           get { return per9; }
       }
       ActivarPermiso10TableAdapter per10 = new ActivarPermiso10TableAdapter();
       private ActivarPermiso10TableAdapter PER10
       {
           get { return per10; }
       }
       ActivarPermiso11TableAdapter per11 = new ActivarPermiso11TableAdapter();
       private ActivarPermiso11TableAdapter PER11
       {
           get { return per11; }
       }
       ActivarPermiso12TableAdapter per12 = new ActivarPermiso12TableAdapter();
       private ActivarPermiso12TableAdapter PER12
       {
           get { return per12; }
       }
       ActivarPermiso13TableAdapter per13 = new ActivarPermiso13TableAdapter();
       private ActivarPermiso13TableAdapter PER13
       {
           get { return per13; }
       }
       ActivarPermiso14TableAdapter per14 = new ActivarPermiso14TableAdapter();
       private ActivarPermiso14TableAdapter PER14
       {
           get { return per14; }
       }
       ActivarPermiso15TableAdapter per15 = new ActivarPermiso15TableAdapter();
       private ActivarPermiso15TableAdapter PER15
       {
           get { return per15; }
       }
       ActivarPermiso16TableAdapter per16 = new ActivarPermiso16TableAdapter();
       private ActivarPermiso16TableAdapter PER16
       {
           get { return per16; }
       }
       ActivarPermiso17TableAdapter per17 = new ActivarPermiso17TableAdapter();
       private ActivarPermiso17TableAdapter PER17
       {
           get { return per17; }
       }
       ActivarPermiso18TableAdapter per18 = new ActivarPermiso18TableAdapter();
       private ActivarPermiso18TableAdapter PER18
       {
           get { return per18; }
       }
       ActivarPermiso19TableAdapter per19 = new ActivarPermiso19TableAdapter();
       private ActivarPermiso19TableAdapter PER19
       {
           get { return per19; }
       }
       ActivarPermiso20TableAdapter per20 = new ActivarPermiso20TableAdapter();
       private ActivarPermiso20TableAdapter PER20
       {
           get { return per20; }
       }
       ActivarPermiso21TableAdapter per21 = new ActivarPermiso21TableAdapter();
       private ActivarPermiso21TableAdapter PER21
       {
           get { return per21; }
       }
       ActivarPermiso22TableAdapter per22 = new ActivarPermiso22TableAdapter();
       private ActivarPermiso22TableAdapter PER22
       {
           get { return per22; }
       }
       ActivarPermiso23TableAdapter per23 = new ActivarPermiso23TableAdapter();
       private ActivarPermiso23TableAdapter PER23
       {
           get { return per23; }
       }

       TienePermisoSITableAdapter per = new TienePermisoSITableAdapter();
       private TienePermisoSITableAdapter PER
       {
           get { return per; }
       }

       ConocerPermisosUsuarioTableAdapter conoper = new ConocerPermisosUsuarioTableAdapter();
       private ConocerPermisosUsuarioTableAdapter CONOPER
       {
           get { return conoper; }
       }
       
       //metodo

       public DataTable CONOCERPERMISO(int empleado)
       {
           return CONOPER.GetDataConocerPermisosUsuario(empleado);
       }
       public DataTable VerSiTienePermiso(int empleado)
       {
           return PER.GetDataTienePermisoSI(empleado);
       }
       public void Permiso1(int codigo, bool estado)
       {
           PER1.GetDataActivarPermiso1(codigo,estado);
       }
       public void Permiso2(int codigo, bool estado)
       {
           PER2.GetDataActivarPermiso2(codigo, estado);
       }
       public void Permiso3(int codigo, bool estado)
       {
           PER3.GetDataActivarPermiso3(codigo, estado);
       }
       public void Permiso4(int codigo, bool estado)
       {
           PER4.GetDataActivarPermiso4(codigo, estado);
       }
       public void Permiso5(int codigo, bool estado)
       {
           PER5.GetDataActivarPermiso5(codigo, estado);
       }
       public void Permiso6(int codigo, bool estado)
       {
           PER6.GetDataActivarPermiso6(codigo, estado);
       }
       public void Permiso7(int codigo, bool estado)
       {
           PER7.GetDataActivarPermiso7(codigo, estado);
       }
       public void Permiso8(int codigo, bool estado)
       {
           PER8.GetDataActivarPermiso8(codigo, estado);
       }
       public void Permiso9(int codigo, bool estado)
       {
           PER9.GetDataActivarPermiso9(codigo, estado);
       }
       public void Permiso10(int codigo, bool estado)
       {
           PER10.GetDataActivarPermiso10(codigo, estado);
       }
       public void Permiso11(int codigo, bool estado)
       {
           PER11.GetDataActivarPermiso11(codigo, estado);
       }
       public void Permiso12(int codigo, bool estado)
       {
           PER12.GetDataActivarPermiso12(codigo, estado);
       }
       public void Permiso13(int codigo, bool estado)
       {
           PER13.GetDataActivarPermiso13(codigo, estado);
       }
       public void Permiso14(int codigo, bool estado)
       {
           PER14.GetDataActivarPermiso14(codigo, estado);
       }
       public void Permiso15(int codigo, bool estado)
       {
           PER15.GetDataActivarPermiso15(codigo, estado);
       }
       public void Permiso16(int codigo, bool estado)
       {
           PER16.GetDataActivarPermiso16(codigo, estado);
       }
       public void Permiso17(int codigo, bool estado)
       {
           PER17.GetDataActivarPermiso17(codigo, estado);
       }
       public void Permiso18(int codigo, bool estado)
       {
           PER18.GetDataActivarPermiso18(codigo, estado);
       }
       public void Permiso19(int codigo, bool estado)
       {
           PER19.GetDataActivarPermiso19(codigo, estado);
       }
       public void Permiso20(int codigo, bool estado)
       {
           PER20.GetDataActivarPermiso20(codigo, estado);
       }
       public void Permiso21(int codigo, bool estado)
       {
           PER21.GetDataActivarPermiso21(codigo, estado);
       }
       public void Permiso22(int codigo, bool estado)
       {
           PER22.GetDataActivarPermiso22(codigo, estado);
       }
       public void Permiso23(int codigo, bool estado)
       {
           PER23.GetDataActivarPermiso23(codigo, estado);
       }




    }
}
