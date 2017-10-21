<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="DepartamentoForm.aspx.cs" Inherits="slnPresentacion.DepartamentoForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Departamentos</h1>
    <asp:HiddenField ID="hdnIdentificador" runat="server" />
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <label for="contenido_txtNombre">Nombre del departamento</label><br />
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El nombre del departamento es obligatorio." ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnSalvar" runat="server"  class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>

