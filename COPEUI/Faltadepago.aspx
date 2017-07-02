<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Faltadepago.aspx.cs" Inherits="COPEUI.Faltadepago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="row">
   
            <div class="col-lg-12">
                <div class="wrapper wrapper-content animated fadeInUp">

                    <div class="ibox">
                        <div class="ibox-title">
                            <h5>Falta de pago</h5>
                        </div>
                        <div class="ibox-content">
                            <div id="SuperAdmin" runat="server" class="row m-b-sm m-t-sm">
                             <div class="col-md-4">
                                <div class="input-group date"> 
                                    
                                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                                </div>
                                </div>
                            </div>
                            <div class="row m-b-sm m-t-sm">
                                <div class="col-md-4">
                                    <div class="form-group" id="data_1">
                                        <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" value="01/01/2017" runat="server"></asp:TextBox>  

                                </div>
                                    </div>


                                
                                </div>
                                
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:Button ID="Button1" CssClass="btn btn-sm btn-primary" runat="server" Text="Buscar" OnClick="Button1_Click" />
                                        <asp:Button ID="Button2" CssClass="btn btn-sm btn-info" Visible="false" runat="server" Text="Imprimir" OnClick="Button2_Click" />
                                    </div>
                                </div>
                                  
                                
                                
                            
                            </div>

                            

                            <div class="project-list">
                              
                                <div class="table-responsive">


                                

          <asp:GridView ID="GridView2"  CssClass="table table-striped table-bordered table-hover  " AutoGenerateColumns="false"     runat="server">
            <Columns>
                
                           
                <asp:HyperLinkField DataNavigateUrlFields="Id_prestamo" DataNavigateUrlFormatString="InfroPrestamo.aspx?valor={0}" DataTextField="Id_prestamo" SortExpression="NewsHeadline" HeaderText="Prestamo #"  />
                <asp:BoundField DataField="Tel" HeaderText="Tel"  /> 
                <asp:BoundField DataField="name" HeaderText="Cliente"  />  
                <asp:BoundField DataField="vence" HeaderText="Vence"  />                 
                <asp:BoundField DataField="Cuota Normal" HeaderText="Cuota Normal"  />  
                <asp:BoundField DataField="Saldo" HeaderText="Saldo"  />
                <asp:BoundField DataField="Total" HeaderText="Total"  />    
            </Columns>
        </asp:GridView>

                                </div>                             
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

      
        </div>
</asp:Content>
