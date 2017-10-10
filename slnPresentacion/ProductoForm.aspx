<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ProductoForm.aspx.cs" Inherits="slnPresentacion.ProductoForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Producto</h1>
    <asp:HiddenField ID="hdnIdentificador" runat="server" />
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <label for="contenido_txtProducto">Producto</label><br />
    <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre del producto es obligatorio." ControlToValidate="txtProducto" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <label for="contenido_txtCosto">Costo</label><br />
    <asp:TextBox ID="txtCosto" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El costo del producto es obligatorio." ControlToValidate="txtCosto" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <label for="contenido_txtUtilidad">Utilidad</label><br />
    <asp:TextBox ID="txtUtilidad" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La Utilidad del producto es obligatorio." ControlToValidate="txtUtilidad" ForeColor="Red"></asp:RequiredFieldValidator>
    <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Utilidad es porcentual entero desde 1." ControlToValidate="txtUtilidad" MinimumValue="1"></asp:RangeValidator>--%>
    <br />
    <label for="contenido_txtImpuesto">Impuesto</label><br />
    <asp:TextBox ID="txtImpuesto" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El Impuesto del producto es obligatorio." ControlToValidate="txtImpuesto" ForeColor="Red"></asp:RequiredFieldValidator>
    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Impuesto es porcentual entero desde 1 a 100." ControlToValidate="txtImpuesto" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>--%>
    <br />
    <label for="contenido_txtExistencia">Existencia</label><br />
    <asp:TextBox ID="txtExistencia" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El Existencia del producto es obligatorio." ControlToValidate="txtExistencia" ForeColor="Red"></asp:RequiredFieldValidator>
    <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Existencia es entero desde 0." ControlToValidate="txtExistencia" MinimumValue="0"></asp:RangeValidator>--%>
    <br />
    <label for="contenido_ddlProveedor">Proveedor</label><br />
    <asp:DropDownList ID="ddlProveedor" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El proveedor del producto es obligatorio." ControlToValidate="ddlProveedor" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
