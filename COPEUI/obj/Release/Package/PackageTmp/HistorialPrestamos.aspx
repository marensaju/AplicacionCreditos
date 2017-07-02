<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="HistorialPrestamos.aspx.cs" Inherits="COPEUI.HistorialPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
<div class="row">
    

        
       
            <div class="col-lg-12">
                <div class="wrapper wrapper-content animated fadeInUp">

                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>Historial de préstamos Búsqueda por fecha</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row m-b-sm m-t-sm">
                                
                           
                                    <div class="form-group" id="data_1">
                                <div class="col-md-4">

                                <label class="font-noraml">Fecha Inicial</label>
                                <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" value="01/01/2017" runat="server"></asp:TextBox>  

                                </div>

                                </div>
                                <div class="col-md-4">
                                    <label class="font-noraml">Fecha Final</label>
                                <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" value="01/01/2017" runat="server"></asp:TextBox>  

                                </div>
                                    
                                </div>
                            </div>
                                
                                 
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:Button ID="Button1" CssClass="btn btn-sm btn-primary" runat="server" Text="Buscar" OnClick="Button1_Click" />
                                        <asp:Button ID="Button2" CssClass="btn btn-sm btn-info" Visible="false" runat="server" Text="Imprimir" OnClick="Button2_Click" />
                                    </div>
                                </div>

                                    <div class="col-md-6">
                                            <h1 >
                                                <asp:Label ID="Label1" CssClass="no-margins" runat="server" Visible="false" Text="Label"></asp:Label>
                                            </h1>
                                            <div id="Div1" runat="server" visible="false" class="font-bold text-navy"><small>No.Prestamos</small></div>
                                             
                                        </div>
                                <div class="col-md-6">
                                            <h1 >
                                                <asp:Label ID="Label3" CssClass="no-margins" runat="server" Visible="false" Text="Label"></asp:Label>
                                            </h1>
                                            <div id="textoc" runat="server" visible="false" class="font-bold text-navy"><small>Total </small></div>
                                             
                                        </div>
                                
                                
                            
                            </div>

                            

                            <div class="project-list">
                               <!--Grid de infro de prestamos-->
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-hover" datakeynames="Id_prestamo"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
                                            <Columns>
                                                 
                                                <asp:BoundField DataField="Id_prestamo" HeaderText="Presta"/>
                                                 <asp:BoundField DataField="Num" HeaderText="No."/> 
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

                                </div>                             
                                <!--fin de grid de info prestamos-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>

 
            
        </div>
     
</asp:Content>
