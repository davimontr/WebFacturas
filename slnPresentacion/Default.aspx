<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFacturas.InicioSession" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h2 class="form-signin-heading">Facturaci&oacute;n</h2>
    <br />
    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Correo"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El correo electronico es obligatorio." ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtClave" runat="server" class="form-control" placeholder="Clave" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La clave es obligatoria." ControlToValidate="txtClave" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Button ID="btnIniciar" runat="server" Text="Iniciar" class="btn btn-lg btn-primary btn-block" OnClick="btnIniciar_Click" />
    <asp:Label ID="lblInicioSession" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Content>
