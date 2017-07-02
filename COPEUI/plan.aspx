<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="COPEUI.plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/toast2.css" rel="stylesheet"/>
    <link href="css/toast3.css" rel="stylesheet"/>
    <script type="text/javascript" >
        function myFunction() {
            var x = document.getElementById("snackbar")
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
    </script>
    <script type="text/javascript" >
        function myFunction2() {
            var x = document.getElementById("snackbar2")
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }


    </script>

    <script runat="server">

      void Check_Clicked(Object sender, EventArgs e) 
      {

          DropDownList1.Visible = true;

      }
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="snackbar">Datos guardados exitosamente :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <div class="wrapper wrapper-content animated fadeInRight">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="row">
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Planes</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="form-horizontal"> 
                                <div class="table-responsive">
                                     <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" datakeynames="Id_plan"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
            <Columns>
                <asp:BoundField DataField="Id_plan" HeaderText="ID"  /> 
               <asp:BoundField DataField="Nombre_plan" HeaderText="Nombre"  /> 
               <asp:BoundField DataField="Periodo" HeaderText="Período"  /> 
                 <asp:BoundField DataField="Dia" HeaderText="Dia"  /> 
                <asp:BoundField DataField="Semana" HeaderText="Semana"  /> 
                <asp:BoundField DataField="CantidadInteres" HeaderText="Interés %"  /> 
                 <asp:CommandField ButtonType="Button" ControlStyle-CssClass=" btn btn-sm btn-primary" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>




                                </div>
                            </div>
                        </div>
       
                    </div>
                </div>

                <!--segunda row-->
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Datos de plan</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="form-horizontal"> 
                                <div class="form-group"><label class="col-sm-2 control-label">Nombre*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextNombre" placeholder="Nombre plan" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                 <div class="form-group"><label class="col-sm-2 control-label">Descripción*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextDescripcion" placeholder="Descripción de plan" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group"><label class="col-sm-2 control-label">Período*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextPeriodo" placeholder="26" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group"><label class="col-sm-2 control-label">Tiempo*</label>
                                    <div class="col-sm-9">

                                        <div class="radio  radio-inline">
                                            <asp:RadioButton ID="RadioButton1"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio1"> Días </label>
                                        </div>
                                        <div class="radio radio-inline">
                                            <asp:RadioButton ID="RadioButton2"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio2"> Semanas </label>
                                        </div>

                                    </div>
                                    </div>

                                <div class="form-group"><label class="col-sm-2 control-label">Interés %</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextInteres" placeholder="30" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group"><label class="col-sm-2 control-label">Mora*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:Label ID="Label1" runat="server" visible="false" Text="Label"></asp:Label>
                                                 <asp:Label ID="Label2" runat="server" visible="false" Text="Cambiar Mora"></asp:Label>
                                                 <asp:CheckBox ID="CheckBox2"  runat="server" visible="false" OnCheckedChanged="Check_Clicked" AutoPostBack="True" />
                                                <asp:DropDownList ID="DropDownList1" CssClass="chosen-select" runat="server" AutoPostBack="False"></asp:DropDownList>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                
                                  <div class="hr-line-dashed"></div>
                                 
                    <div class="form-group">
                                    <div class="col-md-2 text-center">
                                        
                                        <asp:Button ID="Button2"  CssClass="btn btn-white" runat="server" Text="Limpiar" OnClick="Button2_Click"  />
                                </div>
                    
                        <div class="col-md-2 text-center">
                             <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click"  />
                            <asp:Button ID="Button3"  CssClass="btn btn-primary" runat="server" Text="Actualizar" Visible="false" OnClick="Button3_Click"  />
                             </div>
                 </div>
     

                            </div>
                        </div>
       
                    </div>
                </div>




            </div>
                
                <asp:Label ID="Label3"  Visible="false" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

   
    </div>
</asp:Content>
