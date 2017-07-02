<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ListaNegra.aspx.cs" Inherits="COPEUI.ListaNegra" %>
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
    
     <div id="snackbar">Cliente excluido de  lista negra </div>
    <div id="snackbar2">Ha ocurrido un error!! :(</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="wrapper wrapper-content  animated fadeInRight">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                <div class="col-sm-7">
                    <div class="ibox">
                        <div class="ibox-content">
                           
                            <h2>Lista negra de clientes</h2>
                            <p>
                                Utiliza el buscador para ubicar a un cliente por su nombre o número de DPI.
                            </p>
                            
                            <div class="input-group">
                                <asp:TextBox ID="TextBox1" placeholder="Buscar cliente " CssClass="input form-control " runat="server"></asp:TextBox>
                                <span class="input-group-btn">
                                       
                                <asp:Button ID="Button1" CssClass="btn btn btn-primary" runat="server" Text="Buscar" ToolTip="Buscar" OnClick="Button1_Click" />
                                </span>
                                
                            </div>
                           
                       
                            <div>

                            </div>
                            <div class="clients-list">
                            <ul class="nav nav-tabs">
                                
                                <li class="active"><a data-toggle="tab" href="#tab-1"><i class="fa fa-user"></i> Clientes</a></li>
                              
                                 <asp:Button ID="Button4"   CssClass="btn btn-success"  runat="server" Text="Imprimir" OnClick="Button4_Click" />
                               
                            
                            </ul>
                                
                            <div class="tab-content">
                                <div id="tab-1" class="tab-pane active">
                                    <div class="full-height-scroll">
                                        <div class="table-responsive">
         
                  <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" datakeynames="Id_persona"  onselectedindexchanging="svCliente_SelectedIndexChanging"  runat="server">
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
      </ContentTemplate>
         </asp:UpdatePanel> 
                <!--Segunda columna-->
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                          <div class="col-sm-5">
                    <div class="ibox ">

                       
                            
                        
                        <div class="ibox-content ">
                 <div class="tab-content ">
                                <div id="contact-1" class="tab-pane active ">
                                   
                                    
                                    
                                    
                                    <div class="row m-b-lg ">
                                        
                                        
                                
                                 <div class="ibox-content no-padding">          
 <div class="ibox-content no-padding" style="background-image:url(http://asgatech.com/AsgaSite/wp-content/themes/skt-parallaxme/images/slider-bg.jpg); background-size:cover; height: 250px">

     
      <div class="widget-head-color-box p-lg   col-sm-12   no-padding ">
     
    
         <div class="col-sm-5">
             <asp:Image ID="Image1" CssClass="img-circle circle-border m-b-md"  ImageUrl="img/a1.jpg"  height="128" width="128" runat="server" />
             </div>
         
         <div class="col-sm-7">
             
             <div class="m-b-md" style="line-height: 0px;">
                            <h2 class="font-bold no-margins">
                                <asp:Label ID="Label1" CssClass="text-white text-right text-xs bloc" runat="server" Text="Nombre Cliente"></asp:Label>
                
                            </h2>
            </div>

              <div class="m-b-md text-right" style="line-height: -20px;">
             
                               
                                 <asp:Button ID="Button2"  CssClass="btn btn-xs btn-info" runat="server" Text="Actualizar " OnClick="Button2_Click" />
                              <asp:Button ID="Button3"  CssClass="btn btn-xs btn-white" runat="server" Text="Quitar de lista negra" OnClick="Button3_Click" />
                               
              </div>
              
           
             </div>
   
      </div>
          
     
        </div>
     
   
    
     
                 </div>       
            
							</div>
 
                                    </div>



                                    <div class="client-detail">
                                    <div class="full-height-scroll">

                                       
                                        <div class="col-lg-8">
                                            <asp:Button ID="Button5"   CssClass="btn btn-success"  runat="server" Text="Imprimir" OnClick="Button5_Click" />
                                             <h4>
                                                 <asp:Label ID="Label2" runat="server" Text="Nombre de cliente"></asp:Label>
                                             </h4>
                                          
                                            
                                            <strong><i class="fa fa-puzzle-piece"></i> DPI:</strong> <asp:Label ID="Label3" runat="server" Text="1234-12345-0901"></asp:Label> 
<p></p>
                                            <p>
                                             <strong><i class="fa fa-map-marker"></i> Dirección:</strong> <asp:Label ID="Label4" runat="server" Text="Dirección cliente"></asp:Label>
                                         </p>
                                            <p>
                                             <strong><i class="fa fa-phone"></i> Tel:</strong> <asp:Label ID="Label5" runat="server" Text="+502 12345678"></asp:Label>
                                            </p>
                                            
                                            
                                             <strong><i class="fa fa-suitcase"></i> Trabaja en:</strong> <asp:Label ID="Label6" runat="server" Text="Lugar de trabajo"></asp:Label>
<p></p>
                                            <p>
                                             <strong><i class="fa fa-map-marker"></i> Dir. Trabajo:</strong> <asp:Label ID="Label7" runat="server" Text="Dirección de trabajo"></asp:Label> 
                                         </p>
                                         
                                            
                                            
                                        </div>
                                        
                                        
                                         <div class="ibox-content profile-content">
                               
                               
                                <h5>
                                    Observaciones
                                </h5>
                                <p>
                                    <asp:Label ID="Label9" runat="server" Text="Observaciones"></asp:Label>
                                </p>
                                        
                            </div>
                                        <strong>Referencias</strong>
                                        <!--Referencias-->
                                        <asp:GridView ID="GridView2" CssClass="table table-bordered" runat="server">

                                        </asp:GridView>
                                         <!--Referencias-->
                                       


                                        <strong>Historial de prestamos</strong>
                                        <div>
                                            <div class="table-responsive">
                                                <asp:GridView  CssClass="table table-bordered" ID="GridView3" runat="server"></asp:GridView>
                                                
                                            </div>
                                            
                                            
                                            
                                           
                                            
                                        </div>
                                    </div>
                                    </div>
                                </div>
                               
                                
                            </div>
                        </div>
                    </div>


                    </ContentTemplate>
                </asp:UpdatePanel>
              
                <!--Fin columna-->
                
                </div>
            </div>
        
</asp:Content>
