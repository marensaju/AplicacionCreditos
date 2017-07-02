<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="DiasFeriado.aspx.cs" Inherits="COPEUI.DiasFeriado" %>
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
      <div id="snackbar">Operación exitosa :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <div class="wrapper wrapper-content animated fadeInRight">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
            
            <div class="row">
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Días de feriado existenes</h5>
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
                                     <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" datakeynames="Id_dia"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
            <Columns>
                <asp:BoundField DataField="Id_dia" HeaderText="ID"  /> 
               <asp:BoundField DataField="fecha_dia" HeaderText="Nombre"  /> 
               <asp:BoundField DataField="Descripcion" HeaderText="Descripción"  /> 
                         
                 <asp:CommandField ButtonType="Button"  SelectText="Eliminar" ControlStyle-CssClass=" btn btn-sm btn-primary" ShowSelectButton="True" />
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
                            <h5>Agregar nuevo día de feriado</h5>
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
                                <div class="form-group"><label class="col-sm-2 control-label">Fecha*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div id="data_1">
                                        <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" value="01/01/2017" runat="server"></asp:TextBox>  

                                </div>
                                    </div>
                                        </div>
                                    </div>
                                </div>

                                   <div class="form-group"><label class="col-sm-2 control-label">Descripción*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextDescripcion" placeholder="Descripción de feriado" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                

                               

                            

                                
                                  <div class="hr-line-dashed"></div>
                                 
                    <div class="form-group">
                                   
                    
                        <div class="col-md-2 text-center">
                             <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click"  />
                            </div>
                 </div>
     

                            </div>
                        </div>
       
                    </div>
                </div>




            </div>
                
              
           

   
    </div>
</asp:Content>
