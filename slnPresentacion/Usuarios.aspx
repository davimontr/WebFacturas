<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="slnPresentacion.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Usuarios</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Administraci&oacute;n de usuarios</h4>
        </div>
        <div class="col-4 col-sm-4 placeholder">
            <a class="w3-button w3-large w3-circle w3-xlarge w3-ripple w3-teal" href="UsuarioForm.aspx" style="z-index: 0">+</a>
            <h4>Nuevo</h4>
            <span class="text-muted">Agregar usuario</span>
        </div>
    </section>
    <asp:GridView ID="gvUsuarios" runat="server" 
        EmptyDataText="No Existen Usuarios Registrados" 
        CssClass="table table-striped"
        OnRowDeleting="gvUsuarios_RowDeleting" 
        OnRowEditing="gvUsuarios_RowEditing"
        AutoGenerateColumns="False"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
                <ItemStyle CssClass="d-none" />
                <HeaderStyle CssClass="d-none" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Role.Nombre" HeaderText="Rol" />
            <asp:CommandField EditText="Editar" ShowEditButton="true">
                <ControlStyle CssClass="btn btn-primary active" />
            </asp:CommandField>
            <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                <ControlStyle CssClass="btn btn-danger btn-sm" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
