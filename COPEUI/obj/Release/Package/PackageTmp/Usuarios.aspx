<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="COPEUI.Usuarios" %>
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
       <div id="snackbar">Empleado configurado :) </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <div class="wrapper wrapper-content animated fadeIn">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
             
            <ContentTemplate>

         
            <div class="row">
                <div class="col-lg-12">
                    <div class="tabs-container">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#tab-1"> Usuario</a></li>
                            <li class=""><a data-toggle="tab" href="#tab-2">Permisos</a></li>
                           
                        </ul>
                        <div class="tab-content">
                            <!--tab1-->
                        <div id="tab-1" class="tab-pane active">
                        <div class="panel-body">
                <div class="row m-b-lg m-t-lg">
                <div class="col-md-12"> <!--Columna1-->
                    <div id="CrearUsuaio" runat="server"><!--div si no tiene usuario -->
                         <div class="form-group"><label class="col-sm-2 control-label">Usuario*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextUsuario" placeholder="Nombre de usuario" CssClass="form-control required"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                          <div class="form-group"><label class="col-sm-2 control-label">Contraseña*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextContra" placeholder="Contraseña de usuario" CssClass="form-control required"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    
                    <asp:Button ID="Button1"  CssClass="btn btn-primary btn-facebook btn-outline" runat="server" Text="Crear usuario" OnClick="Button1_Click" />
                    

                    </div>
                   
                    <div id="ResetearContra" runat="server">
                        <div class="form-group"><label class="col-sm-2 control-label">Contraseña*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextBox1" placeholder="Contraseña de usuario" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    
                    <asp:Button ID="Button2"  CssClass="btn btn-primary btn-facebook btn-outline" runat="server" Text="Resetear Contraseña" OnClick="Button2_Click" />
                    
                    </div>
                  
                  

                   
                </div><!--Fin columna 1-->
               
   
            </div>
                 
                                    
            </div></div>
                                
                                
                                
                           
                            
                            
                            <div id="tab-2" class="tab-pane">
                                  <div class="panel-body">

                       <!--Rotulo no usuario-->
                        <div id="InformaPermisos" runat="server"  visible="True" class="widget yellow-bg p-lg text-center">
                        <div class="m-b-md">
                            <i class="fa fa-warning fa-4x"></i>
                            <h1 class="m-xs">Al empleado no se le ha creado usuario</h1>
                        </div>
                    </div> <!--Fin Rotulo no usuario-->
                <div  id="Permisos" runat="server" class="row m-b-lg m-t-lg">
                <div class="col-md-6"> <!--Columna1-->

                    <div class="form-group"><label class="col-md-12 control-label">Pagos<br>
                                    

                                    <div class="col-md-12">
                                        
                                        <div><label> <asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="false"/> Registrar pagos</label></div>
                                        
                                        <div><label> <asp:CheckBox ID="CheckBox3" runat="server"  AutoPostBack="false"/> Anular pagos</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox4" runat="server"  AutoPostBack="false"/> Eliminar mora</label></div>
                                        
                                        
                                    </div>
                     </div>
                    <div class="form-group"><label class="col-md-12 control-label">Préstamos<br>
                                    

                                    <div class="col-md-12">
                                        <div><label> <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="false"/> Registrar nueva solicitud</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox6" runat="server" AutoPostBack="false"/> Ver información de préstamo</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox7" runat="server" AutoPostBack="false"/> Cancelar solicitud</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox8" runat="server" AutoPostBack="false"/> Precalificar nueva solicitud</label></div>
                                         <div><label> <asp:CheckBox ID="CheckBox9" runat="server" AutoPostBack="false"/> Aprobar préstamo</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox10" runat="server" AutoPostBack="false" /> Realizar desembolso</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox11" runat="server" AutoPostBack="false"/> Ver información de garantías</label></div>
                                        <!--<div><label> <asp:CheckBox ID="CheckBox12" runat="server" AutoPostBack="false" /> Generar pagaré y reconocimiento de deuda</label></div>-->
                                        
                                        
                                    </div>
                     </div>
                   
                </div><!--Fin columna 1-->
                <div class="col-md-6"><!--Columna 2-->
                    <div class="form-group"><label class="col-md-12 control-label">Préstamos<br>
                                    

                                    <div class="col-md-12">
                                        <div><label> <asp:CheckBox ID="CheckBox13" runat="server" AutoPostBack="false" />Generar cheque</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox14" runat="server" AutoPostBack="false" /> Ver ingresos de papelería</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox15" runat="server" AutoPostBack="false" /> Transferir cartera de clientes</label></div>
                                    </div>
                     </div>
                  
                     <div class="form-group"><label class="col-md-12 control-label">Reportes<br>
                                    

                                    <div class="col-md-12">
                                        <div><label> <asp:CheckBox ID="CheckBox16" runat="server" AutoPostBack="false" /> Balance general</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox17" runat="server"  AutoPostBack="false"/> Morosidad</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox18" runat="server" AutoPostBack="false" /> Cartera vencida</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox19" runat="server" AutoPostBack="false"/> Cartera muerta</label></div>
                                        
                                        
                                    </div>
                     </div>

                    <div class="form-group"><label class="col-md-12 control-label">Usuarios<br>
                                    

                                    <div class="col-md-12">
                                        <div><label> <asp:CheckBox ID="CheckBox20" runat="server"  AutoPostBack="false"/> Crear usuarios</label></div>
                                   
                                        <div><label> <asp:CheckBox ID="CheckBox21" runat="server"  AutoPostBack="false"/>  Resetear contraseñas</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox22" runat="server"  AutoPostBack="false"/> Modificar datos de usuario</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox23" runat="server"  AutoPostBack="false"/> Suspender usuarios</label></div>
                                        <div><label> <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="false" /> Asignar Permisos</label></div>
                                    </div>
                     </div>

                        <asp:Button ID="Button3"  CssClass="btn btn-primary btn-facebook btn-outline" runat="server" Text="Guardar Permisos"  OnClick="Button3_Click" />
                    
                </div><!--fin columna2-->
   
            </div>
                 
                                    
            </div>
                        </div>
                            

                    </div>
                </div>
                
                
                
            </div>
            
            
             </ContentTemplate>
            <Triggers> 
        <asp:ASyncPostBackTrigger ControlID="CheckBox1"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox2"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox3"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox4"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox5"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox6"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox7"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox8"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox9"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox10"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox11"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox12"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox13"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox14"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox15"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox16"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox17"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox18"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox19"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox20"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox21"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox22"  /> 
                <asp:ASyncPostBackTrigger ControlID="CheckBox23"  /> 
        <asp:ASyncPostBackTrigger ControlID="Button3"  /> 
    </Triggers> 
        </asp:UpdatePanel>  
            

            





        </div>
        

      

</asp:Content>
