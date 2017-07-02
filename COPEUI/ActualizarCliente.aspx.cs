using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class ActualizarCliente : System.Web.UI.Page
    {
        VerClientes ver = new VerClientes();
        ModificarPersonas mo=new ModificarPersonas();
        IngresosPersonas per = new IngresosPersonas();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }
            string valor2 = Request.QueryString["Valor"];
            int idperson = Convert.ToInt32(valor2);
            if (!IsPostBack)
            {
                


                TextPrimerNombre.Text = ver.InfoClientes(idperson).Rows[0][0].ToString();
                TextSegundoNombre.Text = ver.InfoClientes(idperson).Rows[0][1].ToString();
                TextPrimerApellido.Text = ver.InfoClientes(idperson).Rows[0][2].ToString();
                TextSegundoApellido.Text = ver.InfoClientes(idperson).Rows[0][3].ToString();
                string genero = ver.InfoClientes(idperson).Rows[0][4].ToString();
                if (genero == "True")
                {
                    RadioButton1.Checked = true;
                }
                else
                {
                    RadioButton2.Checked = true;
                }
                TextDPI.Text = ver.InfoClientes(idperson).Rows[0][5].ToString();
                TextExtendido.Text = ver.InfoClientes(idperson).Rows[0][6].ToString();
                TextEstadoCivil.Text = ver.InfoClientes(idperson).Rows[0][7].ToString();
                TextCorreo.Text = ver.InfoClientes(idperson).Rows[0][8].ToString();
                TextProfesion.Text = ver.InfoClientes(idperson).Rows[0][9].ToString();
                TextNacimiento.Text = ver.InfoClientes(idperson).Rows[0][10].ToString();
                TextTelefonoPersonal.Text = ver.InfoClientes(idperson).Rows[0][11].ToString();
                TextDepartamento.Text = ver.InfoClientes(idperson).Rows[0][12].ToString();
                TextMunicipio.Text = ver.InfoClientes(idperson).Rows[0][13].ToString();
                TextDomicilio.Text = ver.InfoClientes(idperson).Rows[0][14].ToString();
                string casa = ver.InfoClientes(idperson).Rows[0][15].ToString();
                if (casa == "True")
                {
                    RadioButton3.Checked = true;
                }
                else
                {
                    RadioButton4.Checked = true;
                }
                TextTelefonoResidencial.Text = ver.InfoClientes(idperson).Rows[0][16].ToString();
                string foto = ver.InfoClientes(idperson).Rows[0][17].ToString();
                Image1.ImageUrl = "~/ImagenesCargadas/Clientes/" + foto;
                //variables cliente
                TextTrabajo.Text = ver.InfoClientes(idperson).Rows[0][18].ToString();
                TextDirTrabajo.Text = ver.InfoClientes(idperson).Rows[0][19].ToString();
                TextTelefonoTra.Text = ver.InfoClientes(idperson).Rows[0][20].ToString();
                TextTiempoTra.Text = ver.InfoClientes(idperson).Rows[0][21].ToString();
                TextObservaciones.Text = ver.InfoClientes(idperson).Rows[0][22].ToString();

                //variables de referencia
                TextRef1.Text = ver.ReferenciasCli(idperson).Rows[0][0].ToString();
                TextRef2.Text = ver.ReferenciasCli(idperson).Rows[0][1].ToString();
                TextRef3.Text = ver.ReferenciasCli(idperson).Rows[0][2].ToString();
                LaRef1.Text = ver.ReferenciasCli(idperson).Rows[0][3].ToString();

                int nrorows = ver.ReferenciasCli(idperson).Rows.Count;

                if (nrorows == 2)
                {
                    TextRef4.Text = ver.ReferenciasCli(idperson).Rows[1][0].ToString();
                    TextRef5.Text = ver.ReferenciasCli(idperson).Rows[1][1].ToString();
                    TextRef6.Text = ver.ReferenciasCli(idperson).Rows[1][2].ToString();
                    LaRef2.Text = ver.ReferenciasCli(idperson).Rows[1][3].ToString();

                }


                if (nrorows == 3)
                {
                    TextRef4.Text = ver.ReferenciasCli(idperson).Rows[1][0].ToString();
                    TextRef5.Text = ver.ReferenciasCli(idperson).Rows[1][1].ToString();
                    TextRef6.Text = ver.ReferenciasCli(idperson).Rows[1][2].ToString();
                    LaRef2.Text = ver.ReferenciasCli(idperson).Rows[1][3].ToString();
                    TextRef7.Text = ver.ReferenciasCli(idperson).Rows[2][0].ToString();
                    TextRef8.Text = ver.ReferenciasCli(idperson).Rows[2][1].ToString();
                    TextRef9.Text = ver.ReferenciasCli(idperson).Rows[2][2].ToString();
                    LaRef3.Text = ver.ReferenciasCli(idperson).Rows[2][3].ToString();
                }

            }
            else {
                string foto = ver.InfoClientes(idperson).Rows[0][17].ToString();
                Image1.ImageUrl = "~/ImagenesCargadas/Clientes/" + foto;
 
            }
            
          


        }

       
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            string valor2 = Request.QueryString["Valor"];
            int idperson = Convert.ToInt32(valor2);
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

            string telcasa = TextTelefonoResidencial.Text;
            //variables cliente
            string lugartrabajo = TextTrabajo.Text;
            string dirtrabajo = TextDirTrabajo.Text;
            string telefonotrabajo = TextTelefonoTra.Text;
            string tiempolaborar = TextTiempoTra.Text;
            string observacion = TextObservaciones.Text;

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
            string ref10 = LaRef1.Text;
            string ref11 = LaRef2.Text;
            string ref12 = LaRef3.Text;
            int agencia = Convert.ToInt32(Session["idagencia"]);

            try
            {
                
                if (CheckBox1.Checked == true)
                {
                    string foto = "";
                    //carga de imagenes
                    Boolean fileOK = false;
                    String path = Server.MapPath("~/ImagenesCargadas/Clientes/");
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
                            mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, true, foto, telcasa, agencia);
                        }
                        else
                        {
                            mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, false, foto, telcasa, agencia);
                        }


                    }
                    else
                    {

                        if (RadioButton3.Checked == true)
                        {
                            mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, true, foto, telcasa, agencia);
                        }
                        else
                        {
                            mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, false, foto, telcasa, agencia);
                        }

                    }
                    //cliente;

                   
                    mo.ModCliente(idperson, f_registro, lugartrabajo, dirtrabajo, telefonotrabajo, tiempolaborar, observacion);
                    //referencia

                    int nrorows = ver.ReferenciasCli(idperson).Rows.Count;
                    if (TextRef1.Text.Trim() != "" && TextRef1.Text.Trim() != "" && TextRef3.Text.Trim() != "" && TextRef4.Text.Trim() == "" && TextRef5.Text.Trim() == "" && TextRef6.Text.Trim() == "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                    {
                        if (nrorows == 1)
                        {
                            mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                        }
                    }
                    else if (TextRef4.Text.Trim() != "" && TextRef5.Text.Trim() != "" && TextRef6.Text.Trim() != "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                    {
                        if (nrorows == 1)
                        {
                            mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                            per.Referencia(ref4, ref5, ref6, true, idperson);
                        }
                        else if (nrorows == 2)
                        {
                            mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                            mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                        }

                    }
                    else if (TextRef1.Text.Trim() != "" && TextRef2.Text.Trim() != "" && TextRef3.Text.Trim() != "" && TextRef4.Text.Trim() != "" && TextRef5.Text.Trim() != "" && TextRef6.Text.Trim() != "" && TextRef7.Text.Trim() != "" && TextRef8.Text.Trim() != "" && TextRef9.Text.Trim() != "")
                    {
                        if (nrorows == 2)
                        {
                            mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                            mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                            per.Referencia(ref7, ref8, ref9, true, idperson);
                        }
                        else if (nrorows == 3)
                        {
                            mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                            mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                            mo.ModReferencia(Convert.ToInt32(ref12), ref7, ref8, ref9, true);
                        }

                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");
                    }
                }
                    else
                    {

                        //si el chek no esta seleccionado
                        string foto = ver.InfoClientes(idperson).Rows[0][17].ToString();
                        if (RadioButton1.Checked == true)
                        {
                            if (RadioButton3.Checked == true)
                            {
                                mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, true, foto, telcasa, agencia);
                            }
                            else
                            {
                                mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, true, false, foto, telcasa, agencia);
                            }


                        }
                        else
                        {

                            if (RadioButton3.Checked == true)
                            {
                                mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, true, foto, telcasa, agencia);
                            }
                            else
                            {
                                mo.ModPersona(idperson, dpi, pnombre, snombre, papell, sappell, f_registro, telper, dirper, ciudad, muni, correo, true, extendido, profesion, estadocivil, false, false, foto, telcasa, agencia);
                            }

                        }
                        //cliente;
                        mo.ModCliente(idperson, f_registro, lugartrabajo, dirtrabajo, telefonotrabajo, tiempolaborar, observacion);
                        //referencia
                        int nrorows = ver.ReferenciasCli(idperson).Rows.Count;
                        if (TextRef1.Text.Trim() != "" && TextRef1.Text.Trim() != "" && TextRef3.Text.Trim() != "" && TextRef4.Text.Trim() == "" && TextRef5.Text.Trim() == "" && TextRef6.Text.Trim() == "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                        {
                            if (nrorows == 1)
                            {
                                mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                            }
                        }
                        else if (TextRef4.Text.Trim() != "" && TextRef5.Text.Trim() != "" && TextRef6.Text.Trim() != "" && TextRef7.Text.Trim() == "" && TextRef8.Text.Trim() == "" && TextRef9.Text.Trim() == "")
                        {
                            if (nrorows == 1)
                            {
                                mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                                per.Referencia(ref4, ref5, ref6, true, idperson);
                            }
                            else if (nrorows == 2)
                            {
                                mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                                mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                            }

                        }
                        else if (TextRef1.Text.Trim() != "" && TextRef2.Text.Trim() != "" && TextRef3.Text.Trim() != "" && TextRef4.Text.Trim() != "" && TextRef5.Text.Trim() != "" && TextRef6.Text.Trim() != "" && TextRef7.Text.Trim() != "" && TextRef8.Text.Trim() != "" && TextRef9.Text.Trim() != "")
                        {
                            if (nrorows == 2)
                            {
                                mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                                mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                                per.Referencia(ref7, ref8, ref9, true, idperson);
                            }
                            else if (nrorows == 3)
                            {
                                mo.ModReferencia(Convert.ToInt32(ref10), ref1, ref2, ref3, true);
                                mo.ModReferencia(Convert.ToInt32(ref11), ref4, ref5, ref6, true);
                                mo.ModReferencia(Convert.ToInt32(ref12), ref7, ref8, ref9, true);
                            }

                        }



                        Bitacora bita = new Bitacora();
                        bita.RegistrarBitacora("Actualizar", "actualizo datos de cliente idpersona: "+ Convert.ToString(idperson), Convert.ToInt32(Session["idempleado"]));
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction();</script>");





                    }




                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:myFunction2();</script>");
            }

                
                

           

        }
    }
}