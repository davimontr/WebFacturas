<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="UsuarioForm.aspx.cs" Inherits="slnPresentacion.UsuarioForm" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Usuario</h1>
    <asp:HiddenField ID="hdnIdentificador" runat="server" />
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <label for="contenido_txtEmail">Correo</label><br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El correo electronico es obligatorio." ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <label for="contenido_txtClave">Clave</label><br />
    <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La clave es obligatoria." ControlToValidate="txtClave" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <label for="contenido_ddRoles">Rol</label><br />
    <asp:DropDownList ID="ddlRoles" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
    <br />
    <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
