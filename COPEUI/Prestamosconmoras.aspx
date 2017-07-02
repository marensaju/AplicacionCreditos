<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Prestamosconmoras.aspx.cs" Inherits="COPEUI.Prestamosconmoras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="row">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-lg-12">
                <div class="wrapper wrapper-content animated fadeInUp">

                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>Préstamos pendientes de pagos con mora</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row m-b-sm m-t-sm">
                                
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownList1" Visible="false" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:Button ID="Button1" CssClass="btn btn-sm btn-primary" Visible="false" runat="server" Text="Buscar" OnClick="Button1_Click" />
                                        
                                    </div>
                                </div>
                                
                            </div>

                            

                            <div class="project-list">
                               <!--Grid de infro de prestamos-->
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-hover" datakeynames="Id_prestamo"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="Id_prestamo" HeaderText="presta"  /> 
                                                <asp:BoundField DataField="Numero" HeaderText="N#" /> 
                                                 <asp:BoundField DataField="name" HeaderText="Cliente"/>
                                                 <asp:BoundField DataField="Tel" HeaderText="Tel"/>
                                                <asp:BoundField DataField="PagosConMora" HeaderText="Pagos con mora"/>
                                               
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

        </ContentTemplate>
    </asp:UpdatePanel>
            
        </div>
</asp:Content>
