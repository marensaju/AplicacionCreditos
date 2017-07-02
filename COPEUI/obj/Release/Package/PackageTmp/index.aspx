<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="COPEUI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta charset="utf-8"/>
   <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title>Creditriunfo</title>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet"/>

    <link href="css/animate.css" rel="stylesheet"/>
    <link href="css/toast.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet"/>
    <script type="text/javascript" >
        function myFunction() {
            var x = document.getElementById("snackbar")
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
    </script>
</head>
<body class="gray-bg">
    <div id="snackbar">Datos Incorrectos</div>

    <div class="loginColumns animated fadeInDown">
        <div class="row">

            <div class="col-md-6">
                <h2 class="font-bold">¡Bienvenido!</h2>

                <p>
                    Al ingresar al sistema usted acepta las condiciones y póliticas de privacidad que la empresa ha estipulado para el uso y manejo de información.
                </p>

                <p>
                   Cabe recordar que todas las acciones que usted realice dentro del sistema quedan registradas en una bitácora de uso gerencial.
                </p>

                <p>
                    Su usuario y contraseña le conectarán directamente a la base de datos de la agencia designada.
                </p>

                <p>
                    <small>El sistema registra las direcciones IP para garantizar que el ingreso se realice desde la sucursal deignada.</small>
                </p>

            </div>
            <div class="col-md-6">
                <div class="ibox-content">
                    

                    <!--jaja-->
    <form id="form1" runat="server" class="m-t" role="form">
    
     <div class="form-group">
    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Usuario" required=""></asp:TextBox>
    
     </div>
     <div class="form-group">
     <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="Contraseña" required=""></asp:TextBox>
     </div>
     <asp:Button ID="Button1" runat="server" Text="Ingresar" class="btn btn-primary block full-width m-b" OnClick="Button1_Click1" />
    </form>
                    <!--jaja-->
                    
  <p class="m-t">
                        <small>Nuestra Web App utiliza tecnología de Google & Twitter &copy; 2017</small>
                    </p>
                </div>
            </div>
        </div>
        <hr/>
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Label" Enabled="False" Visible="False"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label" Enabled="False" Visible="False"></asp:Label>
            <div class="col-md-6">
                Creditriunfo
            </div>
            <div class="col-md-6 text-right">
               <small>© 2017</small>
            </div>
        </div>
    </div>
    
    
</body>
</html>
