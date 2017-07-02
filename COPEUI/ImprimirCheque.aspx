<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ImprimirCheque.aspx.cs" Inherits="COPEUI.ImprimirCheque" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
      <div id="snackbar"> Cheque registrado exitosamente :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
            <div class="wrapper wrapper-content animated fadeInRight">
        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Imprimir Cheque</h5>
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
                        </div>
                        <div class="ibox-content">
                            <div class="form-horizontal">
                                
                                <div class="form-group"><label class="col-lg-2 control-label">Monto</label>
                                   
                                    <div class="col-lg-10">
                                         <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group"><label class="col-lg-2 control-label">Monto en letras</label>

                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                     
                                          <div class="form-group"><label class="col-sm-2 control-label">Préstamo</label>
                                    <div class="col-sm-9">


                                        <div class="radio  radio-inline">
                                           
                                            <asp:RadioButton ID="RadioButton1"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio1"> Negociable </label>
                                        </div>
                                        <div class="radio radio-inline">
                                            <asp:RadioButton ID="RadioButton2"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio2"> No Negociable </label>
                                        </div>

                                    </div>
                                    </div>

                                   
                                <div class="form-group">
                                    <div class="col-lg-offset-2 col-lg-10">
                                        <asp:Button ID="Button1" CssClass="btn btn-info btn-facebook btn-outline" runat="server" Text="Registrar" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                    <div class="col-lg-12">
                                        <div class="text-center">
                                     <rsweb:ReportViewer ID="ReportViewer1" Visible="true"  Width="100%" runat="server"></rsweb:ReportViewer>
                                    </div>
                                        </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
            </div>
                <!--reporte-->
                
                    
                   
                    
             </ContentTemplate>
    </asp:UpdatePanel>
    </div>


       
    


</asp:Content>
