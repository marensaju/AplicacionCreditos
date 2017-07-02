<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NuevoPrestamo.aspx.cs" Inherits="COPEUI.NuevoPrestamo" %>
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
    <div id="snackbar">Prestamos Registrado exitosamente :) </div>
    <div id="snackbar2">Ha ocurrido un error con los datos!! :(</div>
      <div class="wrapper wrapper-content  animated fadeInRight">
            <div class="row">

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <!--Inicio de ver clientes-->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" Visible="false" runat="server" Text="Label"></asp:Label>
                         <asp:Label ID="Label2" Visible="false" runat="server" Text="Label"></asp:Label>
                         <asp:Label ID="Label3" Visible="false" runat="server" Text="Label"></asp:Label>
                           
                         <div class="col-sm-6">
                    <div class="ibox">
                        <div class="ibox-content">
                            <span class="text-muted small pull-right">ültima consulta: <i class="fa fa-clock-o"></i> 2:10 pm - 12.01.2017</span>
                            <h2>Clientes</h2>
                            <p>
                                Utiliza el buscador para ubicar a un cliente por su nombre o número de DPI.
                            </p>
                             <div class="input-group">
                                <asp:TextBox ID="TextBox1" placeholder="Buscar cliente " CssClass="input form-control " runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                       
                                <asp:Button ID="Button1" CssClass="btn btn btn-primary" runat="server" Text="Buscar" ToolTip="Buscar" OnClick="Button1_Click" />
                                </span>
                                
                            </div>
                            <div class="clients-list">
                            <ul class="nav nav-tabs">
                                <span class="pull-right small text-muted">1406 Clientes</span>
                                <li class="active"><a data-toggle="tab" href="#tab-1"><i class="fa fa-user"></i> Clientes</a></li>

                            </ul>
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="full-height-scroll">
                                        <div class="table-responsive">                       
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-hover" datakeynames="Id_persona"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
            <Columns>
                <asp:ImageField  ControlStyle-CssClass="client-avatar"  DataImageUrlField="Ruta_Fotografia" DataImageUrlFormatString="~/ImagenesCargadas/Clientes/{0}" HeaderText="Imagen">
                </asp:ImageField>
                <asp:BoundField DataField="name" HeaderText="Nombre"  /> 
               <asp:BoundField DataField="Direccion_persona" HeaderText="Dirección"  /> 
               <asp:BoundField DataField="Telefonos_Persona" HeaderText="Teléfono"  /> 
                 <asp:BoundField DataField="Id_persona" HeaderText="ID"  /> 
                 <asp:CommandField ButtonType="Button" ControlStyle-CssClass=" btn btn-sm btn-primary" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
                                           
                                             


                 <asp:Label ID="Label8" runat="server" Font-Underline="False" Enabled="True" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            </div>
                        </div>
                    </div>

                    

                </div>

                         <asp:GridView ID="GridView2" runat="server"></asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>
                <!--Fin de ver clientes-->
               
                
                





                <div class="col-lg-6">
                    <!--perfil de cliente-->
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="col-sm-12 no-padding">
                <div class="contact-box">

                    <div class="col-sm-4">
                        <div class="text-center">
                            <asp:Image ID="Image1" CssClass="img-circle m-t-xs img-responsive"  ImageUrl="img/a3.jpg"  height="128" width="128" runat="server" />
                            

                        </div>
                    </div>
                    <div class="col-sm-8">
                        <a href="profile.html"><h3>
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre"></asp:Label></h3></a>
                        <p><i class="fa fa-map-marker"></i> <asp:Label ID="LabelDireccion" runat="server" Text="Direccion"></asp:Label>

</p>
                        <address>
                            
                            DPI: <asp:Label ID="LabelDPI" runat="server" Text="DPI"></asp:Label><br>
                            Trabaja en :<asp:Label ID="LabelTrabajo" runat="server" Text="Trabaja en"></asp:Label><br>
                            Tel: <asp:Label ID="Labeltelefono" runat="server" Text="Telefono"></asp:Label>
                            <asp:Label ID="LabelIDPersona" runat="server" Visible="false" Text="Label"></asp:Label>
                        </address>
                    </div>
                    <div class="clearfix"></div>

                </div>
            </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                    <!--Final perfil de cliente -->
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Nueva solicitud de préstamo <small>Verifique todos los campos antes de finalizar.</small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                           </div>
                        </div>
                        <div class="ibox-content">
                  <div class="form-horizontal">


                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                             <div class="form-group"><label class="col-sm-2 control-label">Registro*</label>
                                    <div class="col-sm-9">


                                        <div class="radio  radio-inline">
                                            <asp:RadioButton ID="RadioButton1" GroupName="elegir" AutoPostBack="true" runat="server" />
                                            <label for="inlineRadio1"> Nuevo </label>
                                        </div>
                                        <div class="radio radio-inline">
                                            <asp:RadioButton ID="RadioButton2" GroupName="elegir" AutoPostBack="true" runat="server" />
                                            <label for="inlineRadio2"> Activo </label>
                                        </div>

                                    </div>
                                    </div>

                        </ContentTemplate>
                      </asp:UpdatePanel>
                               

                      <div class="hr-line-dashed"></div>
                      <!--
                               <div class="form-group"><label class="col-sm-2 control-label">Préstamo No.*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextNoPrestamo"  Enabled="false" placeholder="#1001PRS" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                      <div class="hr-line-dashed"></div>
                      -->

                      <div class="form-group"><label class="col-sm-2 control-label">Asesor*</label>

                                    <div class="col-sm-9">
                                        <asp:DropDownList ID="DropDownList1" CssClass="form-control m-b" runat="server"></asp:DropDownList>
                                     
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>


                      <div class="form-group"><label class="col-sm-2 control-label">Monto*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                
                                                <asp:TextBox ID="TextMonto" placeholder="Monto solicitado "  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>


                      <div class="form-group"><label class="col-sm-2 control-label">Plan</label>

                                    <div class="col-sm-9">
                                        <asp:DropDownList ID="DropDownList2" CssClass="form-control m-b" runat="server"></asp:DropDownList>  
                                       

                                    </div>
                                </div>

 <div class="hr-line-dashed"></div>



                            <h3>
                                Garantías
                            </h3>
                            <p>
                                Pertenencias que el cliente deja en calidad de garantía.
                            </p>






                                   <div class="hr-line-dashed"></div>

                                <div class="form-group">

                                    <div class="col-sm-12">
                                        <div class="row">
                                           <div class="col-md-4">
                                               <asp:TextBox ID="TextRef1" placeholder="Descripción"  CssClass="form-control required" runat="server"></asp:TextBox>
                                              
                                           </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef2" placeholder="Modelo"   CssClass="form-control required" runat="server"></asp:TextBox>
                                               

                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="TextRef3" placeholder="Serie"  CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef4"  placeholder="Valor Q" CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                        </div>
                                    </div>
                                </div>

                      <div class="hr-line-dashed"></div>

                                <div class="form-group">

                                    <div class="col-sm-12">
                                       <div class="row">
                                           <div class="col-md-4">
                                               <asp:TextBox ID="TextRef5" placeholder="Descripción" CssClass="form-control required" runat="server"></asp:TextBox>
                                              
                                           </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef6" placeholder="Modelo" CssClass="form-control required" runat="server"></asp:TextBox>
                                               

                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="TextRef7" placeholder="Serie" CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef8" placeholder="Valor Q" CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                        </div>
                                    </div>
                                </div>

                      <div class="hr-line-dashed"></div>

                                <div class="form-group">

                                    <div class="col-sm-12">
                                       <div class="row">
                                           <div class="col-md-4">
                                               <asp:TextBox ID="TextRef9" placeholder="Descripción" CssClass="form-control required" runat="server"></asp:TextBox>
                                              
                                           </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef10" placeholder="Modelo" CssClass="form-control required" runat="server"></asp:TextBox>
                                               

                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="TextRef11" placeholder="Serie" CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextRef12" placeholder="Valor Q" CssClass="form-control required" runat="server"></asp:TextBox>
                                                

                                            </div>
                                        </div>
                                    </div>
                                </div>

                        <div class="hr-line-dashed"></div>
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                          <ContentTemplate>
                              <div class="form-group">
                                    <div class="col-sm-12 text-right">
                                        <button class="btn btn-white" type="submit">Cancelar</button>
                                        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Procesar" OnClick="Button2_Click" />                                        
                                    </div>
                                </div>
                          </ContentTemplate>
                      </asp:UpdatePanel>
                                

                            </div>
                        </div>
                    </div>
                </div>



            </div>
        </div>


    


</asp:Content>
