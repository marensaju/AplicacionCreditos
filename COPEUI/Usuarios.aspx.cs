using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class Usuarios : System.Web.UI.Page
    {
        IngresosConfiEmpleados co = new IngresosConfiEmpleados();
        IngresosPersonas per = new IngresosPersonas();
        ModificarPersonas mo = new ModificarPersonas();
        Permisos p = new Permisos();

        private void ListarPermisoso()
        {
            //permiso para crear usuarios
            if (p.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][19].ToString() == "False")
            {
                CrearUsuaio.Visible = false;
            }
            //permiso para resetear contrasenas
            if (p.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][20].ToString() == "False")
            {
                ResetearContra.Visible = false;
            }

            //Permiso del superAdmin
            //el campo saltar pagos ahora es asignar permisos
            if (Session["idempleado"] != "0")
            {
                CheckBox2.Visible = false;
            }

            string valor2 = Request.QueryString["Valor"];
            int idperson = Convert.ToInt32(valor2);
            string conocer = co.SaberIDEmpleadoP(idperson).Rows[0][0].ToString();
            int empleado = Convert.ToInt32(conocer);

            //aqui lo de permisos como es de esperar que el usuario ya fue creado
          
            string registrarpagos = co.ListarPermisos(empleado).Rows[0][2].ToString();
            string saltarpagos = co.ListarPermisos(empleado).Rows[0][3].ToString();
            string anular = co.ListarPermisos(empleado).Rows[0][4].ToString();
            string eliminarmora = co.ListarPermisos(empleado).Rows[0][5].ToString();
            string registranuevasolivitud = co.ListarPermisos(empleado).Rows[0][6].ToString();
            string verinfoprestamo = co.ListarPermisos(empleado).Rows[0][7].ToString();
            string cancelarsolicitud = co.ListarPermisos(empleado).Rows[0][8].ToString();
            string precalificar = co.ListarPermisos(empleado).Rows[0][9].ToString();
            string aprobarPrestamo = co.ListarPermisos(empleado).Rows[0][10].ToString();
            string desembolso = co.ListarPermisos(empleado).Rows[0][11].ToString();
            string verinfogarantias = co.ListarPermisos(empleado).Rows[0][12].ToString();
            string generarpagare = co.ListarPermisos(empleado).Rows[0][13].ToString();
            string genrarnotodecobro = co.ListarPermisos(empleado).Rows[0][14].ToString();
            string veringresosPapeleria = co.ListarPermisos(empleado).Rows[0][15].ToString();
            string transferircarteras = co.ListarPermisos(empleado).Rows[0][16].ToString();
            string balance = co.ListarPermisos(empleado).Rows[0][17].ToString();
            string morosidad = co.ListarPermisos(empleado).Rows[0][18].ToString();
            string carteraVencida = co.ListarPermisos(empleado).Rows[0][19].ToString();
            string cartermuerta = co.ListarPermisos(empleado).Rows[0][20].ToString();
            string crearusuarios = co.ListarPermisos(empleado).Rows[0][21].ToString();
            string resetearcontrasenas = co.ListarPermisos(empleado).Rows[0][22].ToString();
            string modificarfatosUsuario = co.ListarPermisos(empleado).Rows[0][23].ToString();
            string suspendersuaurios = co.ListarPermisos(empleado).Rows[0][24].ToString();
            
            if (registrarpagos == "False")
            {
                CheckBox1.Checked = false;
            }
            else {
                CheckBox1.Checked = true;
            }
            //
            if (saltarpagos== "False")
            {
                CheckBox2.Checked = false;
            }
            else
            {
                CheckBox2.Checked = true;
            }
            //
            if (anular == "False")
            {
                CheckBox3.Checked = false;
            }
            else
            {
                CheckBox3.Checked = true;
            }
            //
            if (eliminarmora == "False")
            {
                CheckBox4.Checked = false;
            }
            else
            {
                CheckBox4.Checked = true;
            }
            //
            if (registranuevasolivitud == "False")
            {
                CheckBox5.Checked = false;
            }
            else
            {
                CheckBox5.Checked = true;
            }
            //
            if (verinfoprestamo == "False")
            {
                CheckBox6.Checked = false;
            }
            else
            {
                CheckBox6.Checked = true;
            }
            //
            if (cancelarsolicitud == "False")
            {
                CheckBox7.Checked = false;
            }
            else
            {
                CheckBox7.Checked = true;
            }
            //
            if (precalificar == "False")
            {
                CheckBox8.Checked = false;
            }
            else
            {
                CheckBox8.Checked = true;
            }
            //
            if (aprobarPrestamo == "False")
            {
                CheckBox9.Checked = false;
            }
            else
            {
                CheckBox9.Checked = true;
            }
            //
            if (desembolso == "False")
            {
                CheckBox10.Checked = false;
            }
            else
            {
                CheckBox10.Checked = true;
            }
            //
            if (verinfogarantias == "False")
            {
                CheckBox11.Checked = false;
            }
            else
            {
                CheckBox11.Checked = true;
            }
            //
            if (generarpagare == "False")
            {
                CheckBox12.Checked = false;
            }
            else
            {
                CheckBox12.Checked = true;
            }
            //
            if (genrarnotodecobro == "False")
            {
                CheckBox13.Checked = false;
            }
            else
            {
                CheckBox13.Checked = true;
            }
            //
            if (veringresosPapeleria == "False")
            {
                CheckBox14.Checked = false;
            }
            else
            {
                CheckBox14.Checked = true;
            }
            //
            if (transferircarteras == "False")
            {
                CheckBox15.Checked = false;
            }
            else
            {
                CheckBox15.Checked = true;
            }
            //
            if (balance == "False")
            {
                CheckBox16.Checked = false;
            }
            else
            {
                CheckBox16.Checked = true;
            }
            //
            if (morosidad == "False")
            {
                CheckBox17.Checked = false;
            }
            else
            {
                CheckBox17.Checked = true;
            }
            //
            if (carteraVencida == "False")
            {
                CheckBox18.Checked = false;
            }
            else
            {
                CheckBox18.Checked = true;
            }
            //
            if (cartermuerta == "False")
            {
                CheckBox19.Checked = false;
            }
            else
            {
                CheckBox19.Checked = true;
            }
            //
            if (crearusuarios == "False")
            {
                CheckBox20.Checked = false;
            }
            else
            {
                CheckBox20.Checked = true;
            }
            //
            if (resetearcontrasenas == "False")
            {
                CheckBox21.Checked = false;
            }
            else
            {
                CheckBox21.Checked = true;
            }
            //
            if (modificarfatosUsuario== "False")
            {
                CheckBox22.Checked = false;
            }
            else
            {
                CheckBox22.Checked = true;
            }
            //
            if (suspendersuaurios == "False")
            {
                CheckBox23.Checked = false;
            }
            else
            {
                CheckBox23.Checked = true;
            }
            //fin de if jajja



 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string valor2 = Request.QueryString["Valor"];
                int idperson = Convert.ToInt32(valor2);


                string verificar = co.SaberSiTieneUsuario(idperson).Rows[0][0].ToString();
                if (verificar == "0")
                {
                    ResetearContra.Visible = false;
                    Permisos.Visible = false;

                }
                //empleados con usuarios ya creados
                else
                {
                    InformaPermisos.Visible = false;
                    CrearUsuaio.Visible = false;
                    ResetearContra.Visible = true;
                    Permisos.Visible = true;
                    //listar Permisos
                    ListarPermisoso();


                }
            }
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                //crear usuarios
                string valor2 = Request.QueryString["Valor"];
                int idperson = Convert.ToInt32(valor2);
                string conocer = co.SaberIDEmpleadoP(idperson).Rows[0][0].ToString();
                int empleado = Convert.ToInt32(conocer);

                //crear el usuario
                per.Usuario(TextUsuario.Text, TextContra.Text, true, empleado);
                //crear permisos
                co.UsuarioPermiso(Convert.ToInt32(co.ConocerUsuarioE(empleado).Rows[0][0].ToString()));
                //ocultar cosas
                InformaPermisos.Visible = false;
                CrearUsuaio.Visible = false;
                Permisos.Visible = true;
                ResetearContra.Visible = true;
                    //refresco la lista de permisos
                ListarPermisoso();

                //bitacora
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Creo Usuario"+ TextUsuario.Text, Convert.ToInt32(Session["idempleado"]));

                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);

            
            
            }
            catch (Exception ew) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);

            }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //resetear contrasena

            try {

                 string valor2 = Request.QueryString["Valor"];
                int idperson = Convert.ToInt32(valor2);
                string conocer = co.SaberIDEmpleadoP(idperson).Rows[0][0].ToString();
                int empleado = Convert.ToInt32(conocer);
                mo.ModUsuario(empleado,TextBox1.Text);

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Resetear Contrasena", "ID EMpleado "+ conocer , Convert.ToInt32(Session["idempleado"]));


                string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
            
            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idperson = Convert.ToInt32(valor2);
            string conocer = co.SaberIDEmpleadoP(idperson).Rows[0][0].ToString();
            int empleado = Convert.ToInt32(conocer);

            //aqui lo de permisos como es de esperar que el usuario ya fue creado

           int codigo = Convert.ToInt32(co.ListarPermisos(empleado).Rows[0][0].ToString());
           
                //guardadPermisos
           try
            {

                if (CheckBox1.Checked == true)
                {
                    p.Permiso1(codigo, true);
                }
                else {
                    p.Permiso1(codigo, false);
 
                }
                    if (CheckBox2.Checked == true)
                    {
                        p.Permiso2(codigo, true);
                    }
                    else
                    {
                        p.Permiso2(codigo, false);
                    }
                    if (CheckBox3.Checked == true)
                    {
                        p.Permiso3(codigo, true);
                    }
                    else
                    {
                        p.Permiso3(codigo, false);
                    }
                    if (CheckBox4.Checked == true)
                    {
                        p.Permiso4(codigo, true);
                    }
                    else
                    {
                        p.Permiso4(codigo, false);
                    }
                    if (CheckBox5.Checked == true)
                    {
                        p.Permiso5(codigo, true);
                    }
                    else
                    {
                        p.Permiso5(codigo, false);
                    }
                    if (CheckBox6.Checked == true)
                    {
                        p.Permiso6(codigo, true);
                    }
                    else
                    {
                        p.Permiso6(codigo, false);
                    }
                    if (CheckBox7.Checked == true)
                    {
                        p.Permiso7(codigo, true);
                    }
                    else
                    {
                        p.Permiso7(codigo, false);
                    }
                    if (CheckBox8.Checked == true)
                    {
                        p.Permiso8(codigo, true);
                    }
                    else
                    {
                        p.Permiso8(codigo, false);
                    }
                    if (CheckBox9.Checked == true)
                    {
                        p.Permiso9(codigo, true);
                    }
                    else
                    {
                        p.Permiso9(codigo, false);
                    }
                    if (CheckBox10.Checked == true)
                    {
                        p.Permiso10(codigo, true);
                    }
                    else
                    {
                        p.Permiso10(codigo, false);
                    }
                    if (CheckBox11.Checked == true)
                    {
                        p.Permiso11(codigo, true);
                    }
                    else
                    {
                        p.Permiso11(codigo, false);
                    }
                    if (CheckBox12.Checked == true)
                    {
                        p.Permiso12(codigo, true);
                    }
                    else
                    {
                        p.Permiso12(codigo, false);
                    }
                    if (CheckBox13.Checked == true)
                    {
                        p.Permiso13(codigo, true);
                    }
                    else
                    {
                        p.Permiso13(codigo, false);
                    }
                    if (CheckBox14.Checked == true)
                    {
                        p.Permiso14(codigo, true);
                    }
                    else
                    {
                        p.Permiso14(codigo, false);
                    }
                    if (CheckBox15.Checked == true)
                    {
                        p.Permiso15(codigo, true);
                    }
                    else
                    {
                        p.Permiso15(codigo, false);
                    }
                    if (CheckBox16.Checked == true)
                    {
                        p.Permiso16(codigo, true);
                    }
                    else
                    {
                        p.Permiso16(codigo, false);
                    }
                    if (CheckBox17.Checked == true)
                    {
                        p.Permiso17(codigo, true);
                    }
                    else
                    {
                        p.Permiso17(codigo, false);
                    }
                    if (CheckBox18.Checked == true)
                    {
                        p.Permiso18(codigo, true);
                    }
                    else
                    {
                        p.Permiso18(codigo, false);
                    }
                    if (CheckBox19.Checked == true)
                    {
                        p.Permiso19(codigo, true);
                    }
                    else
                    {
                        p.Permiso19(codigo, false);
                    }
                    if (CheckBox20.Checked == true)
                    {
                        p.Permiso20(codigo, true);
                    }
                    else
                    {
                        p.Permiso20(codigo, false);
                    }
                    if (CheckBox21.Checked == true)
                    {
                        p.Permiso21(codigo, true);
                    }
                    else
                    {
                        p.Permiso21(codigo, false);
                    }
                    if (CheckBox22.Checked == true)
                    {
                        p.Permiso22(codigo, true);
                    }
                    else
                    {
                        p.Permiso22(codigo, false);
                    }
                    if (CheckBox23.Checked == true)
                    {
                        p.Permiso23(codigo, true);
                    }
                    else
                    {
                        p.Permiso23(codigo, false);
                    }
                
                
                


                //fin de ifs
                //refrescamos
                ListarPermisoso();

               //bitacora
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro","Configuro Permisos a Id Empledo"+ conocer, Convert.ToInt32(Session["idempleado"]));
                
               string notificacion1;
                notificacion1 = "myFunction();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion1", notificacion1, true);
          }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            
            }

        }
    }
}