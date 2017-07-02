<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Abono.aspx.cs" Inherits="COPEUI.Abono" %>
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

      <div id="snackbar">Abono exitoso!! :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
       <div class="wrapper wrapper-content animated fadeInRight">
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="row">
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Abonos de prestamo</h5>
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
                                    
                                    <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered table-hover" runat="server"></asp:GridView>



                                </div>
                            </div>
                        </div>
       
                    </div>
                </div>

                <!--segunda row-->
                <div class="col-lg-6">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Realizar abono</h5>
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
                                <div class="form-group"><label class="col-sm-2 control-label">Monto*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextMonto" placeholder="2578,78" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                   
                    
                        <div class="col-md-2 text-center">
                             <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Verificar" OnClick="Button1_Click"  />
                             </div>
                 </div>

                                 <div class="form-group"><label class="col-sm-2 control-label">Observación*</label>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextOB" placeholder="Observación" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              
                                  <div class="hr-line-dashed"></div>
                                 <div class="form-group">
                                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                 </div>
                                  <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                     <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                 </div>
                                

                                
                                  <div class="hr-line-dashed"></div>


                                 <div class="form-group">
                                   
                    
                        <div class="col-md-2 text-center">
                             <asp:Button ID="Button2"  CssClass="btn btn-primary" runat="server" Text="Registrar abono" OnClick="Button2_Click"  />
                             </div>
                 </div>
                    
     

                            </div>
                        </div>
       
                    </div>
                </div>




            </div>
                <asp:Label ID="Label3" runat="server"  Visible="false" Text="Label"></asp:Label>
                <asp:Label ID="Label4" runat="server" Visible="false" Text="Label"></asp:Label>
        
            </ContentTemplate>
        </asp:UpdatePanel>

   
    </div>
</asp:Content>
