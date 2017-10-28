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
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="El nombre del producto es obligatorio." 
        ControlToValidate="txtProducto" ForeColor="Red"/><br />
    <label for="contenido_txtCosto">Costo</label><br />
    <asp:TextBox ID="txtCosto" runat="server" TextMode="Number"
        ToolTip="El costo debe ser un n&uacute;mero positivo mayor a uno."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="El costo del producto es obligatorio." 
        ControlToValidate="txtCosto" ForeColor="Red"
        Display="Dynamic"/>
    <asp:CompareValidator ID="CompareValidator2" runat="server"
        ControlToValidate="txtCosto" ForeColor="Red"
        ErrorMessage="N&uacute;mero debe ser un entero."
        Operator="DataTypeCheck" Type="Integer"
        Display="Dynamic"/>
    <asp:CompareValidator runat="server"
        ControlToValidate="txtCosto" ForeColor="Red"
        ErrorMessage="Debe ser mayor a uno."
        Operator="GreaterThanEqual"
        ValueToCompare ="1" Type="Integer"
        Display="Dynamic"/><br />
    <label for="contenido_txtUtilidad">Utilidad</label><br />
    <asp:TextBox ID="txtUtilidad" runat="server" TextMode="Number" 
        ToolTip="La utilidad es porcentual y debe ser n&uacute;mero positivo mayor a uno."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="La Utilidad del producto es obligatorio." 
        ControlToValidate="txtUtilidad" ForeColor="Red"
        Display="Dynamic"/>
    <asp:CompareValidator ID="CompareValidator1" runat="server"
        ControlToValidate="txtUtilidad" ForeColor="Red"
        ErrorMessage="N&uacute;mero debe ser un entero."
        Operator="DataTypeCheck" Type="Integer"
        Display="Dynamic"/>
    <asp:CompareValidator runat="server"
        ControlToValidate="txtUtilidad" ForeColor="Red"
        ErrorMessage="Debe ser mayor a uno."
        Operator="GreaterThanEqual"
        ValueToCompare ="1" Type="Integer"
        Display="Dynamic"/><br />
    <label for="contenido_txtImpuesto">Impuesto</label><br />
    <asp:TextBox ID="txtImpuesto" runat="server" TextMode="Number" 
        ToolTip="El impuesto es porcentual y debe ser n&uacute;mero positivo mayor a uno."></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="El Impuesto del producto es obligatorio." 
        ControlToValidate="txtImpuesto" ForeColor="Red"
        Display="Dynamic"/>
    <asp:CompareValidator ID="CompareValidator3" runat="server"
        ControlToValidate="txtImpuesto" ForeColor="Red"
        ErrorMessage="N&uacute;mero debe ser un entero."
        Operator="DataTypeCheck" Type="Integer"
        Display="Dynamic"/>
    <asp:CompareValidator runat="server"
        ControlToValidate="txtImpuesto" ForeColor="Red"
        ErrorMessage="Debe ser mayor a uno."
        Operator="GreaterThanEqual"
        ValueToCompare ="1" Type="Integer"
        Display="Dynamic"/><br />
    <label for="contenido_txtExistencia">Existencia</label><br />
    <asp:TextBox ID="txtExistencia" runat="server" TextMode="Number"
        ToolTip="La existencia debe ser n&uacute;mero positivo mayor a uno."></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ErrorMessage="El Existencia del producto es obligatorio." 
        ControlToValidate="txtExistencia" ForeColor="Red"
        Display="Dynamic"/>
    <asp:CompareValidator ID="CompareValidator4" runat="server"
        ControlToValidate="txtExistencia" ForeColor="Red"
        ErrorMessage="N&uacute;mero debe ser un entero."
        Operator="DataTypeCheck" Type="Integer"
        Display="Dynamic"/>
    <asp:CompareValidator runat="server"
        ControlToValidate="txtExistencia" ForeColor="Red"
        ErrorMessage="Debe ser mayor a uno."
        Operator="GreaterThanEqual"
        ValueToCompare ="1" Type="Integer"
        Display="Dynamic"/><br />
    <label for="contenido_ddlProveedor">Proveedor</label><br />
    <asp:DropDownList ID="ddlProveedor" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ErrorMessage="El proveedor del producto es obligatorio." 
        ControlToValidate="ddlProveedor" ForeColor="Red"/><br />
    <label for ="contenido_ddlDepartamento">Departamento</label><br />
    <asp:DropDownList ID="ddlDepartamento" runat="server" DataValueField="ID" DataTextField="Nombre"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ErrorMessage="El departamento del producto es obligatorio." 
        ControlToValidate="ddlDepartamento" ForeColor="Red"/><br />
    <label for="contenido_checkboxGravado">Gravado</label><br />
    <asp:CheckBox ID="checkboxGravado" runat="server" AutoPostBack="true"/><br />
    <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
