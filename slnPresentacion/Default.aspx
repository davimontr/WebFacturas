<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFacturas.InicioSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2 class="form-signin-heading">Iniciar sesion</h2>
    <label for="inputEmail" class="sr-only">Email address</label>
    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email address" autofocus></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El correo electronico es obligatorio." ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
    <label for="inputPassword" class="sr-only">Password</label>
    <asp:TextBox ID="txtClave" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La clave es obligatoria." ControlToValidate="txtClave" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Button ID="btnIniciar" runat="server" Text="Iniciar" class="btn btn-lg btn-primary btn-block" OnClick="btnIniciar_Click" />
    <asp:Label ID="lblInicioSession" runat="server" Text=""></asp:Label>
</asp:Content>
