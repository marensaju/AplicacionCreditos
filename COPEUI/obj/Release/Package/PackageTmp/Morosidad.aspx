<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Morosidad.aspx.cs" Inherits="COPEUI.Morosidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!--Contenido-->
<div id="contenido" runat="server" class="row">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-lg-12">
                <div class="wrapper wrapper-content animated fadeInUp">

                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>Morosidad</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row m-b-sm m-t-sm">
                               
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList1"  Visible="false" runat="server"></asp:DropDownList>
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
                                      <asp:GridView ID="GridView2"  CssClass="table table-striped table-bordered table-hover  " AutoGenerateColumns="false"     runat="server">
            <Columns>
                
                         <asp:BoundField DataField="Num" HeaderText="No."  />   
                <asp:HyperLinkField DataNavigateUrlFields="Id_prestamo" DataNavigateUrlFormatString="InfroPrestamo.aspx?valor={0}" DataTextField="Id_prestamo" SortExpression="NewsHeadline" HeaderText="Prestamo #"  />
                <asp:BoundField DataField="name" HeaderText="Cliente"  /> 
                <asp:BoundField DataField="Periodo" HeaderText="Periodo"  />  
                <asp:BoundField DataField="Desembolso" HeaderText="Desembolso"  />                 
                <asp:BoundField DataField="MontoInteres" HeaderText="Interes"  />  
                <asp:BoundField DataField="MontoOriginal" HeaderText="Monto original"  />
                <asp:BoundField DataField="MontoAbonado" HeaderText="Monto abonado"  />    
                <asp:BoundField DataField="PagosAtrasados" HeaderText="Pagos atrasados"  />   
                <asp:BoundField DataField="MontoAtrasado" HeaderText="Monto atrasado"  />   
                <asp:BoundField DataField="Mora" HeaderText="Mora"  />
                <asp:BoundField DataField="MontroAtrasadoMasMora" HeaderText="Monto atrasado + mora"  />   
                <asp:BoundField DataField="SaldoTotalMasMora" HeaderText="Saldo total + mora"  />       
            </Columns>
        </asp:GridView>

                                </div>                             
                                <!--fin de grid de info prestamos-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
            
        </div>
</asp:Content>
