using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace COPEUI
{
    public partial class plan : System.Web.UI.Page
    {
        IngresosConfiEmpresa i = new IngresosConfiEmpresa();
        IngresosPrestamos presta = new IngresosPrestamos();
        IngresosPrestamos ingre = new IngresosPrestamos();
        ModificacionesPretamos mod = new ModificacionesPretamos();
        Permisos permiso = new Permisos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (permiso.CONOCERPERMISO(Convert.ToInt32(Session["idempleado"])).Rows[0][13].ToString() == "False")
            {
                Response.Redirect("Inicio.aspx");
            }

            if (!IsPostBack)
            {
                DropDownList1.DataSource = i.ListarMora();
                DropDownList1.DataTextField = "Nombre_mora";
                DropDownList1.DataValueField = "Id_mora";
                DropDownList1.DataBind();
                
            }

            GridView1.DataSource = presta.ListarPlanes();
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();

        }
        protected void svCliente_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                int idplan = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Label3.Text = Convert.ToString(idplan);
                TextNombre.Text = presta.InfoParaEditaPlan(idplan).Rows[0][1].ToString();
                TextDescripcion.Text = presta.InfoParaEditaPlan(idplan).Rows[0][2].ToString();
                TextPeriodo.Text = presta.InfoParaEditaPlan(idplan).Rows[0][3].ToString();
                if (presta.InfoParaEditaPlan(idplan).Rows[0][4].ToString() == "True")
                {
                    RadioButton1.Checked = true;
                }
                else if(presta.InfoParaEditaPlan(idplan).Rows[0][5].ToString()== "True") {
                    RadioButton2.Checked = true;
                }

                TextInteres.Text = presta.InfoParaEditaPlan(idplan).Rows[0][7].ToString();
                Label1.Text = presta.InfoParaEditaPlan(idplan).Rows[0][8].ToString();
                Button1.Visible = false;
                Button3.Visible = true;
                DropDownList1.Visible = false;
                CheckBox2.Visible = true;
                Label2.Visible = true;
                

            }
            catch (Exception ex) {
                string notificacion2;
                notificacion2 = "myFunction2();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "notificacion2", notificacion2, true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextNombre.Text = "";
            TextDescripcion.Text = "";
            TextPeriodo.Text = "";
            TextPeriodo.Text = "";
            TextInteres.Text = "";
            CheckBox2.Visible = false;
            DropDownList1.Visible = true;
            Button1.Visible = true;
            Button3.Visible = false;
            Label2.Visible = false;
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            CheckBox2.Checked = false;
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox2.Checked == true)
                {
                    string mora = DropDownList1.SelectedValue.ToString();
                    int mora1 = Convert.ToInt32(mora);
                    if (RadioButton1.Checked == true)
                    {
                        mod.MOdPlan(Convert.ToInt32(Label3.Text), TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), true, false, false, Convert.ToInt32(TextInteres.Text), mora1);

                    }
                    else
                    {
                        mod.MOdPlan(Convert.ToInt32(Label3.Text), TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), false, true, false, Convert.ToInt32(TextInteres.Text), mora1);
                    }

                }
                else
                {
                    if (RadioButton1.Checked == true)
                    {
                        mod.MOdPlan(Convert.ToInt32(Label3.Text), TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), true, false, false, Convert.ToInt32(TextInteres.Text), Convert.ToInt32(Label1.Text));
                        Bitacora bita = new Bitacora();
                        bita.RegistrarBitacora("Actualizar", "Plan " + TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
                    }
                    else
                    {
                        mod.MOdPlan(Convert.ToInt32(Label3.Text), TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), false, true, false, Convert.ToInt32(TextInteres.Text), Convert.ToInt32(Label1.Text));
                        Bitacora bita = new Bitacora();
                        bita.RegistrarBitacora("Actualizar", "Plan " + TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
                    }


                }
                GridView1.DataSource = presta.ListarPlanes();
                GridView1.Columns[0].Visible = false;
                GridView1.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {

            string mora = DropDownList1.SelectedValue.ToString();
            int mora1 = Convert.ToInt32(mora);
            if (RadioButton1.Checked == true)
            {
                ingre.Plan(TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), true, false, false, Convert.ToInt32(TextInteres.Text), mora1);
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Plan " + TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
            }
            else
            {
                ingre.Plan(TextNombre.Text, TextDescripcion.Text, Convert.ToInt32(TextPeriodo.Text), false, true, false, Convert.ToInt32(TextInteres.Text), mora1);
                Bitacora bita = new Bitacora();
                bita.RegistrarBitacora("Registro", "Plan " + TextNombre.Text, Convert.ToInt32(Session["idempleado"]));
            }

            GridView1.DataSource = presta.ListarPlanes();
            GridView1.Columns[0].Visible = false;
            GridView1.DataBind();

           
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