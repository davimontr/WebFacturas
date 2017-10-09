<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="slnPresentacion.ClienteForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Cliente</h1>
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <label for="contenido_txtCedula">Cedula</label><br />
    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La cedula es obligatoria." ControlToValidate="txtCedula" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <label for="contenido_txtNombre">Nombre completo</label><br />
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El nombre completo es obligatorio." ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
