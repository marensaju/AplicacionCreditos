<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="COPEUI.Inicio" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

   
    
    <div class="wrapper wrapper-content">
        <div class="row">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <div class="col-lg-2">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <span class="label label-success pull-right">Hoy</span>
                        <h5>Capital</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"> <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h1>
                        <div class="stat-percent font-bold text-success"> <i class="fa fa-level-up"></i></div>
                        <small>Capital recuperado</small>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <span class="label label-info pull-right">Hoy</span>
                        <h5>Intereses</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h1>
                        <div class="stat-percent font-bold text-info"><i class="fa fa-level-up"></i></div>
                        <small>Intereses cobrados</small>
                    </div>
                </div>
            </div>
            
            <div class="col-lg-2">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <span class="label label-success pull-right">Hoy</span>
                        <h5>Mora</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></h1>
                        <div class="stat-percent font-bold text-success"><i class="fa fa-level-up"></i></div>
                        <small>Mora recaudada</small>
                    </div>
                </div>
            </div>
            
            <div class="col-lg-2">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <span class="label label-primary pull-right">Hoy</span>
                        <h5>Total</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins">
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></h1>
                        <div class="stat-percent font-bold text-success"><i class="fa fa-level-up"></i></div>
                        <small>Total de efectivo</small>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <span class="label label-primary pull-right">Actualidad</span>
                        <h5>Cartera activa</h5>
                    </div>
                    <div class="ibox-content">

                        <div class="row">
                            <div class="col-md-6">
                                <h1 class="no-margins">
                                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></h1>
                                <div class="font-bold text-navy"><small>Clientes activos</small></div>
                            </div>
                            <div class="col-md-6">
                                <h1 class="no-margins">
                                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                </h1>
                                <div class="font-bold text-navy"><small>Prestamos activos</small></div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
            
            
        </div>
        <div class="row">
            <div class="col-lg-8">
                
                
                 <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Pagos para el día de hoy</h5>
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
                        
                        <div class="table-responsive">
                    
                   <!--Aver que sucede-->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                   <ContentTemplate>
    <div id="snackbar">Pago realizado exitosamente</div>
    <div id="snackbar2">Ha ocurrido un error</div>
                                       <asp:Label  ID="Label1" runat="server" CssClass="widget style1 lazur-bg" Text="No hay pagos disponibles  :(" Font-Size="X-Large" Height="110" Width="200" Visible="False"></asp:Label>   
                                       <asp:GridView ID="GridView2"  CssClass="table table-striped table-bordered table-hover  " AutoGenerateColumns="false" datakeynames="Codigo" onselectedindexchanging="svpagos_SelectedIndexChanging"    runat="server">
            <Columns>
                
                <asp:BoundField DataField="Codigo" HeaderText="Codigo"  /> 
                <asp:BoundField DataField="Id_cliente" HeaderText="Id_cliente"  /> 
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"  />  
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"  />  
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Pagar"  HeaderText="Pagar" ControlStyle-CssClass=" btn btn-sm btn-primary" />
            <asp:BoundField DataField="Id_cliente" HtmlEncode="False" DataFormatString="<a  href='Prueba.aspx?code={0}'>Info</a>" />
            </Columns>
        </asp:GridView>
                                   </ContentTemplate>
                             

                     </asp:UpdatePanel>
                         <!--Aver que sucede-->
                            
                        </div>
                        

                    </div>
                      
                </div>
           
            </div>

            
            <div class="col-lg-4">
                
                <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Totales recaudados</h5>
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
                        <div class="ibox-content ibox-heading">
                        <h4>Hoy
                            <div class="stat-percent text-navy">
                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>

                            </div>
                        </h4>
                        <small><i class="fa fa-stack-exchange"></i> Total recaudado.</small>
                    </div>
                        <div class="ibox-content">
                            <div>
                                <h4>Semana
                            <div class="stat-percent text-navy">
                                <asp:Label ID="Label11" runat="server" Text="Q.0.00"></asp:Label>
                            </div>
                        </h4>
                        <small><i class="fa fa-stack-exchange"></i> Total recaudado.</small>
                            </div>
                        </div>
                        <div class="ibox-content ibox-heading">
                        <h4>Mes
                            <div class="stat-percent text-navy">
                                <asp:Label ID="Label10" runat="server" Text="Q.0.00"></asp:Label>
                            </div>
                        </h4>
                        <small><i class="fa fa-stack-exchange"></i> Total recaudado.</small>
                    </div>
                        
                    </div>
            </div>

        </div>

        <div class="row">

        <div class="col-lg-12">

            
    
        </div>

        </div>


      </div>
 

</asp:Content>
