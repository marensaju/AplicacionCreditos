<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="PrestamosPorPrecalificar.aspx.cs" Inherits="COPEUI.PrestamosPorPrecalificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content  animated fadeInRight">
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox">
                        <div class="ibox-content">
                            <span class="text-muted small pull-right">Última solicitud: <i class="fa fa-clock-o"></i> 2:10 pm - 12.01.2017</span>
                            <h2>Necesitan aprobación</h2>
                            <p>
                                Puede verificar prestamos pendientes de aprobación.
                            </p>
                      
                            <div class="clients-list">
                            <ul class="nav nav-tabs">
                                <span class="pull-right small text-muted">1406 Elements</span>
                                <li class="active"><a data-toggle="tab" href="#tab-1"><i class="fa fa-user"></i> Solicitudes por aprobar</a></li>
                                
                            </ul>
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="full-height-scroll">
                                        <div class="table-responsive">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-hover" datakeynames="Id_prestamo"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
            <Columns>
                <asp:BoundField DataField="Id_prestamo" HeaderText="Presta"/>
                <asp:ImageField  ControlStyle-CssClass="client-avatar"  DataImageUrlField="Ruta_Fotografia" DataImageUrlFormatString="~/ImagenesCargadas/Clientes/{0}" HeaderText="Imagen">
                </asp:ImageField>
                <asp:BoundField DataField="name" HeaderText="Nombre"  /> 
               <asp:BoundField DataField="telefonos" HeaderText="Teléfono"/> 
                 <asp:BoundField DataField="Nempleado" HeaderText="Asesor"/>
                 <asp:BoundField DataField="Monto_presamo" HeaderText="Monto"/>
                <asp:BoundField DataField="FechaPrestamo" HeaderText="Fecha"/>
                <asp:BoundField DataField="Tipo" HeaderText="Estado"/>
                <asp:BoundField DataField="registro" HeaderText="Nuevo/Activo"/>
                 <asp:CommandField ButtonType="Button" ControlStyle-CssClass=" btn btn-sm btn-primary" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
        

                                        </div>
                                    </div>
                                </div>
                                
                            </div>

                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
        
</asp:Content>
