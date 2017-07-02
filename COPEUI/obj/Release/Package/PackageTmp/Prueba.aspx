<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="COPEUI.Prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="form-group" id="data_1">
                                <label class="font-noraml">Simple data input format</label>
                                <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span><input type="text"  runat="server" class="form-control" value="03/04/2014">
                                </div>
    </div>
    
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

    <!-->
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    <asp:GridView ID="GridView3" runat="server"></asp:GridView>
    <asp:GridView ID="GridView4" runat="server"></asp:GridView>
     <asp:GridView ID="GridView5" runat="server"></asp:GridView>
        <-->
         
</asp:Content>

