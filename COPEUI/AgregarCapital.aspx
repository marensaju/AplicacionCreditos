<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AgregarCapital.aspx.cs" Inherits="COPEUI.AgregarCapital" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="snackbar">Capital agregada exitosamente! :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <div class="wrapper wrapper-content animated fadeInRight">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="row">
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Agencias</h5>
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
                                     <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" datakeynames="Id_agencia"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
            <Columns>
                <asp:BoundField DataField="Id_agencia" HeaderText="ID"  /> 
               <asp:BoundField DataField="Nombre_agencia" HeaderText="Nombre"  /> 
               <asp:BoundField DataField="Departamento_agencia" HeaderText="Departamento"  /> 
                 <asp:BoundField DataField="Municipio_agencia" HeaderText="Municipio"  /> 
                <asp:BoundField DataField="Capital" HeaderText="Capital"  /> 
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
                            <h5>Datos de agencia</h5>
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
                             

                                <div class="form-group"><label class="col-sm-2 control-label">Agregar capital*</label>
                                    <div class="col-sm-9">
                                        <asp:Label ID="Label2" runat="server" Text="El capital actual es: "></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="Q.0000.00"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Visible="false" Text="7"></asp:Label>
                                        <div class="row">
                                            <div class="col-md-12">

                                                <asp:TextBox ID="TextCapital" placeholder="2578,78" required="" CssClass="form-control required" runat="server"></asp:TextBox>
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
                             <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="Button1_Click"  />
                           
                             </div>
                 </div>
     

                            </div>
                        </div>
       
                    </div>
                </div>




            </div>
                
        
            </ContentTemplate>
        </asp:UpdatePanel>

   
    </div>
</asp:Content>
