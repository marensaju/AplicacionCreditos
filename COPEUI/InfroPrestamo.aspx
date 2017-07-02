<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="InfroPrestamo.aspx.cs" Inherits="COPEUI.InfroPrestamo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table div {
        text-align:justify !important;
        }
    </style>
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
    <div id="snackbar">Préstamo procesado:) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="wrapper wrapper-content animated fadeIn">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>

            <div class="row">
                <asp:Label ID="Label1" runat="server" Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="Label2" runat="server" Visible="false" Text="Label"></asp:Label>
                <div class="col-lg-12">
                    <div class="tabs-container">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tab-1"> Préstamo</a></li>
                            <li class=""><a data-toggle="tab" href="#tab-2">Verificación</a></li>
                            <li class=""><a data-toggle="tab" href="#tab-3">Garantías</a></li>
                            <li class=""><a data-toggle="tab" href="#tab-4">Pagos</a></li>
                            <li class=""><a data-toggle="tab" href="#tab-5">Contrato</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="tab-1" class="tab-pane active">
                                <div class="panel-body">
                                    
                                    
                                    
                                    <div class="row m-b-lg m-t-lg">
                
                
                <div class="col-md-6">

                    <div class="profile-image">
                        <asp:Image ID="Image1"  CssClass="img-circle circle-border m-b-md" runat="server" />
                    </div>
                    <div class="profile-info">
                        <div class="">
                            <div>
                               <a href="#"> <h2 class="no-margins">
                                   <asp:Label ID="LabelNombre" runat="server" Text="Label"></asp:Label>
                                </h2></a>
                                <h4><asp:Label ID="LabeDireccion" runat="server" Text="Label"></asp:Label>,<asp:Label ID="LabelMunicipio" runat="server" Text="Label"></asp:Label> , <asp:Label ID="LabelCiudad" runat="server" Text="Label"></asp:Label> </h4>
                                
                               <p></p>
                                <small>Saldo total pendiente </small> 
                    <h2 class="no-margins"> <strong><asp:Label ID="LabelSaldoPendiente" runat="server" Text="Label"></asp:Label></strong></h2> 
                          <p></p>
                              
                            
                                <div class="col-md-10 no-padding">
                                  
                                    
                                      <asp:Button ID="Button1" CssClass="btn btn-info btn-facebook btn-outline " runat="server" Text="Precalificar préstamo" OnClick="Button1_Click" />
                                      <asp:Button ID="Button2"  CssClass="btn btn-danger btn-facebook btn-outline" runat="server" Text="Cancelar" OnClick="Button2_Click"  />
                                      
                                    <!--Boton de abonos-->
                                     <asp:Button ID="Button9"  CssClass="btn  btn-success btn-outline" Visible="false" runat="server" Text="Abono" OnClick="Button9_Click" />

                             <asp:Button ID="Button7"  CssClass="btn btn-primary btn-facebook btn-outline"  Visible="false" runat="server" Text=" Generar cheque" OnClick="Button7_Click"  />
                             <asp:Button ID="Button6" CssClass="btn btn-info btn-warning btn-outline " Visible="false" runat="server" Text="Eliminar Préstamo" OnClick="Button6_Click" />
      
                                       <p></p>
                                 </div>
                                
                               
                                
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <table class="table small m-b-xs">
                        <tbody>
                        <tr>
                            <td>
                                Deuda total: <strong>
                                    <asp:Label ID="LabelDeudaTotal" runat="server" Text="Label"></asp:Label></strong> 
                            </td>
                            <td>
                                Abono: <strong> <asp:Label ID="LabelAbono" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                            <td>
                                Saldo Total: <strong><asp:Label ID="LabelSaldo" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>

                        </tr>
                        <tr>
                            <td>
                               Desembolso: <strong><asp:Label ID="LabelDesembolso" runat="server" Text="Q0.00"></asp:Label></strong>   
                            </td>
                            <td>
                              Abono al capital: <strong><asp:Label ID="LabelAbonoCapital" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                            <td>
                                Saldo capital: <strong><asp:Label ID="LabelSaldoCapital" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Número de cuotas (Plan): <strong><asp:Label ID="LabelNoCuotas" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                            <td>
                                Cuotas pendientes: <strong><asp:Label ID="LabelCuotasPendientes" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                             <td>
                                Próx. Fecha de pago: <strong><asp:Label ID="LabelFechaPago" runat="server" Text="---------"></asp:Label></strong> 
                            </td>
                        </tr>
                            
                            <tr>
                            <td>
                                Observaciones: <strong><asp:Label ID="LabelObservaciones" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                            <td>
                                Gestor: <strong><asp:Label ID="LabelGestor" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                             <td>
                                Oficina: <strong><asp:Label ID="LabelAgencia" runat="server" Text="Q0.00"></asp:Label></strong> 
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </div>
                                        
                                          

            </div>
                  <div class="hr-line-dashed"></div>      
                                    
                                    <div class="ibox float-e-margins" id="DivHistoPagos"   visible="true" runat="server">
                      
                        <h2>Historial de pagos</h2>
                                        <div class="table-responsive">
                         <asp:GridView ID="GridView3" CssClass="table" runat="server"></asp:GridView>

                                        </div>
                        
                </div>
                      <asp:Button ID="Button5"   CssClass="btn btn-success"  runat="server" Text="Imprimir" OnClick="Button5_Click" />              
                                </div>
                            </div>
                            
                            <!--Tab2-->
                            <div id="tab-2" class="tab-pane">
                                <div class="panel-body">
                              <div class="row">
                                <div class="col-lg-6">
                                    <div class="m-b-md">
                                        <asp:Button ID="Button3"  CssClass="btn btn-white btn-xs pull-right" runat="server" Text="Actualizar Datos" OnClick="Button3_Click" />
                                        <asp:Button ID="Button4"   CssClass="btn btn-success"  runat="server" Text="Imprimir" OnClick="Button4_Click" />
                                        <h2>Hoja de verificación</h2>
                                    </div>
                                    <dl class="dl-horizontal">
                                        <dt>Status:</dt> <dd><span class="label label-primary">Activo</span></dd>
                                    </dl>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-5">
                                    <dl class="dl-horizontal">
                                        <dt>Información Persona</dt> <dd>    </dd>
                                        <dt>Nombre:</dt> <dd><asp:Label ID="LabelNombreTab2" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>CUI:</dt> <dd><asp:Label ID="LabelCuI" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Estado civil:</dt> <dd><asp:Label ID="LabelEstadoCivil" runat="server" Text="Label"></asp:Label>  </dd>
                                        <dt>Profesión:</dt> <dd> <asp:Label ID="LabelProfesion" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Teléfonos:</dt> <dd><asp:Label ID="LabelTelefonos" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Dirección:</dt> <dd><asp:Label ID="LabelDireccionPer" runat="server" Text="Label"></asp:Label>  </dd>
                                        <dt>Vive en:</dt> <dd><asp:Label ID="LabelDomicilio" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Información trabajo</dt>  <dd>    </dd>
                                        <dt>Nombre del negocio:</dt> <dd> <asp:Label ID="LabelLugarTrabajo" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Dirección del negocio:</dt> <dd>  <asp:Label ID="LabelDirTrabajo" runat="server" Text="Label"></asp:Label>  </dd>
                                        <dt>Teléfono:</dt> <dd>  <asp:Label ID="LabelTelTrabajo" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Tiempo de laborar:</dt> <dd>  <asp:Label ID="LabelTiempoLaborar" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Observaciones:</dt> <dd>  <asp:Label ID="LabelObservacionesTrabajo" runat="server" Text="Label"></asp:Label> </dd>
                                    </dl>
                                </div>
                                <div class="col-lg-7" id="cluster_info">
                                    <dl class="dl-horizontal">
                                         <dt>Información préstamo</dt>  <dd>    </dd>
                                        <dt>Monto:</dt> <dd>  <asp:Label ID="LabelMontoPre" runat="server" Text="Label"></asp:Label></dd>
                                        <dt>Deuda Total:</dt><dd><asp:Label ID="LabelDeudaTotalPre" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Cuotas:</dt> <dd><asp:Label ID="LabelPeriodPre" runat="server" Text="Label"></asp:Label> </dd>
                                        <dt>Gestor:</dt> <dd><asp:Label ID="LabelGestorPre" runat="server" Text="Label"></asp:Label></dd>
                                        <dt>Oficina:</dt> <dd> <asp:Label ID="LabelOficinaPre" runat="server" Text="Label"></asp:Label></dd>
                                        
                                    </dl>
                                </div>
                                    <div class="row">
                                <div class="col-lg-12">
                                    <div class="m-b-md">
                                        <h2>Referencias</h2>
                                    </div>

                                    <!--Referencias-->
                                        <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server">

                                        </asp:GridView>
                                         <!--Referencias-->
                                    
                                </div>
                            </div> 
                                    
                                    
                                </div>
                            </div>
                        </div>
                            <!--Tab3-->
                             <div id="tab-3" class="tab-pane">
                                <div class="panel-body">
                             
                            <div class="row">
                                <div class="col-lg-12">
                                    
                                     <div class="m-b-md">
                                        <h2>Garantías</h2>
                                    </div>
                                    <!--Garantias-->
                                        <asp:GridView ID="GridView2" CssClass="table table-bordered" runat="server">

                                        </asp:GridView>
                                         <!--Referencias-->
                                    
                                </div>
                                 
                                    
                                    
                                </div>
                            </div>
                        </div>

                            <!--Tab4-->
                            <div id="tab-4" class="tab-pane">
                                <div class="panel-body">
                       
                            <div class="row">
                                <div class="col-lg-12">

                                    <div class="m-b-md">
                                        <div class="col-lg-6">
                                             <h2>Lista de Pagos</h2>
                                            <asp:Button ID="Button8"   CssClass="btn btn-success" Visible="false" runat="server" Text="Imprimir" OnClick="Button8_Click" />
                                        </div>
                                        <div class="col-lg-6">
                                            <h1 >
                                                <asp:Label ID="Label3" CssClass="no-margins" runat="server" Visible="false" Text="Label"></asp:Label>
                                            </h1>
                                            <div id="textoc" runat="server" visible="false" class="font-bold text-navy"><small>Total cancelado</small></div>
                                             
                                        </div>
                                       
                                    </div>
                                    <!--pagos Tab-->
                                     <div class="hr-line-dashed"></div>      
                                    
                                    <div class="ibox float-e-margins">
                                        <div class="hr-line-dashed"></div>   
                                        <div class="table-responsive">
                                            
        <asp:GridView ID="GridView4"  CssClass="table table-striped table-bordered table-hover  " AutoGenerateColumns="false" datakeynames="Id_pago" onselectedindexchanging="svCliente_SelectedIndexChanging"    runat="server">
            <Columns>
                <asp:BoundField DataField="Id_pago" HeaderText="Presta"/>
                         <asp:BoundField DataField="Numero" HeaderText="Numero"  /> 
                  <asp:BoundField DataField="Cuota" HeaderText="Cuota"/> 
                   <asp:BoundField DataField="Mora" HeaderText="Mora"/>
                    <asp:BoundField DataField="Total" HeaderText="Total"/>
                    <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago"/>
                    <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Anular"  HeaderText="Anular" ControlStyle-CssClass=" btn btn-sm btn-primary" />
            </Columns>
        </asp:GridView>
                                        </div>
                                        
                                    </div>
                                        

                                  
          
                           <!--Rotulo no hay pagos-->
                        <div id="InformaPagos" runat="server"  visible="false" class="widget yellow-bg p-lg text-center">
                        <div class="m-b-md">
                            <i class="fa fa-warning fa-4x"></i>
                            <h1 class="m-xs">No hay pagos disponibles</h1>
                        </div>
                    </div> <!--Fin Rotulo no hay pagos-->
                                    
                                </div>
                                
                                    
                                    
                                    
                                </div>
                            </div>
                        </div>
                            <!--Tab5 contato-->
                             <div id="tab-5" class="tab-pane" >
                                <div class="panel-body">
                       
                            <div class="row">
                                <div class="col-lg-12">
                           <!--aviso Contrato-->
                                   <div id="ContratoAviso" runat="server" visible="false" class="widget red-bg p-lg text-center">
                        <div class="m-b-md">
                            <i class="fa fa-bell fa-4x"></i>
                           
                            <h3 class="font-bold no-margins">
                              No disponible
                            </h3>
                            
                        </div>
                    </div> <!--Fin aviso Contrato-->

                                    <div id="contra" runat="server">
                                        <rsweb:ReportViewer ID="ReportViewer1" width="90%" runat="server"></rsweb:ReportViewer>
                                    
                                    </div>

                                </div>
                                    
                                </div>
                            </div>
                        </div>

                    <!--Fin Tabs-->
                    </div>
                </div>
                
                
                
            </div>
        </div>
                 
              </ContentTemplate>
          </asp:UpdatePanel> 
             
</div>
</asp:Content>
