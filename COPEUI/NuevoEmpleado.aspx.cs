using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class NuevoEmpleado : System.Web.UI.Page
    {
        ReporteNuevoEmpleado re = new ReporteNuevoEmpleado();
        IngresosPersonas per = new IngresosPersonas();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = re.ListarAgencia();
                DropDownList1.DataTextField = "Nombre_Agencia";
                DropDownList1.DataValueField = "Id_agencia";
                DropDownList1.DataBind();

                DropDownList2.DataSource = re.ListarPuesto();
                DropDownList2.DataTextField = "Nombre_puesto";
                DropDownList2.DataValueField = "Id_Puesto";
                DropDownList2.DataBind();
            }
            

        }

        public void limpiar()
        {
            TextDPI.Text = "";
            TextPrimerNombre.Text = "";
            TextSegundoNombre.Text = "";
            TextPrimerApellido.Text = "";
            TextSegundoApellido.Text = "";
            TextTelefonoPersonal.Text = "";
            TextDomicilio.Text = "";
            TextDepartamento.Text = "";
            TextMunicipio.Text = "";
            TextCorreo.Text = "";
            TextExtendido.Text = "";
            TextProfesion.Text = "";
            TextEstadoCivil.Text = "";

            TextTelefonoResidencial.Text = "";
            //variables cliente
            TextTrabajo.Text = "";
            TextSalario.Text = "";
            TextPorcentaje.Text = "";
            TextCantidadPorComision.Text = "";


            //variables de referencia
            TextRef1.Text = "";
            TextRef2.Text = "";
            TextRef3.Text = "";
            TextRef4.Text = "";
            TextRef5.Text = "";
            TextRef6.Text = "";
            TextRef7.Text = "";
            TextRef9.Text = "";

        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
 
            //variables persona
            string fecha_llegada = TextNacimiento.Text;
            DateTime f_registro = Convert.ToDateTime(fecha_llegada);
            string dpi = TextDPI.Text;
            string pnombre = TextPrimerNombre.Text;
            string snombre = TextSegundoNombre.Text;
            string papell = TextPrimerApellido.Text;
            string sappell = TextSegundoApellido.Text;
            string telper = TextTelefonoPersonal.Text;
            string dirper = TextDomicilio.Text;
            string ciudad = TextDepartamento.Text;
            string muni = TextMunicipio.Text;
            string correo = TextCorreo.Text;
            string extendido = TextExtendido.Text;
            string profesion = TextProfesion.Text;
            string estadocivil = TextEstadoCivil.Text;
            string foto = "";
            string telcasa = TextTelefonoResidencial.Text;
            
            //variables empleado
            string fecha_contratacion =TextTrabajo.Text;
            DateTime f_contra = Convert.ToDateTime(fecha_contratacion);
            Decimal sueldo = Convert.ToDecimal(TextSalario.Text);
            int porcentaje = Convert.ToInt32(TextPorcentaje.Text);
            Decimal comision = Convert.ToDecimal(TextCantidadPorComision.Text);
            //int puesto= Convert.ToString()

            //variables de referencia
            string ref1 = TextRef1.Text;
            string ref2 = TextRef2.Text;
            string ref3 = TextRef3.Text;
            string ref4 = TextRef4.Text;
            string ref5 = TextRef5.Text;
            string ref6 = TextRef6.Text;
            string ref7 = TextRef7.Text;
            string ref8 = TextRef8.Text;
            string ref9 = TextRef9.Text;
            string agencia1 = DropDownList1.SelectedValue.ToString();
            int agencia = Convert.ToInt32(agencia1);
            string puesto1 = DropDownList2.SelectedValue.ToString();
            int puesto = Convert.ToInt32(puesto1);
          
           

            try
            {

                //carga de imagenes
                Boolean fileOK = false;
                String path = Server.MapPath("~/ImagenesCargadas/Empleados/");
                if (FileUpload1.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(path
                            + FileUpload1.FileName);
                        Label1.Text = "File uploaded!";
                        foto = FileUpload1.FileName.ToString();
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "File could not be uploaded.";
                    }
                }
                else
                {
                    Label1.Text = "Cannot accept files of this type.";
                }

                if (RadioButton1.Checked == true)
                {
                    if (RadioButton3.Checked == true)
                    {
                        per.Persona(dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, true, foto, telcasa, agencia);
                    }
                    else
                    {
                        per.Persona(dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, false, foto, telcasa, agencia);
                    }


                }
                else
                {

                    if (RadioButton3.Checked == true)
                    {
                        per.Persona(dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, true, foto, telcasa, agencia);
                    }
                    else
                    {
                        per.Persona(dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, false, foto, telcasa, agencia);
                    }

                }


                int id = Convert.ToInt32(per.ultimoID().Rows[0][0].ToString());
                //empleado;
                per.Empleado(f_contra,true,sueldo,porcentaje,comision,puesto,id);
                //referencia
                if (TextRef4.Text.Trim() == "" && TextRef5.Text.Trim() == "" && TextRef6.Text.Trim() == "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                {
                    per.Referencia(ref1, ref2, ref3, true, id);
                }
                else if (TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                {
                    per.Referencia(ref1, ref2, ref3, true, id);
                    per.Referencia(ref4, ref5, ref6, true, id);
                }
                else
                {
                    per.Referencia(ref1, ref2, ref3, true, id);
                    per.Referencia(ref4, ref5, ref6, true, id);
                    per.Referencia(ref7, ref8, ref9, true, id);

                }

                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Nuevo Empleado con id persona" +Convert.ToString(id), Convert.ToInt32(Session["idempleado"]));

                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");
                limpiar();

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction2();</script>");
            }
            



        }
    }
}