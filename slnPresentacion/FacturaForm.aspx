<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="FacturaForm.aspx.cs" Inherits="slnPresentacion.FacturaForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Factura</h1>
    <asp:HiddenField ID="hdnIdentificador" runat="server" />
    <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
        </div>
    </section>
    <div class="container-fluid">
        <div class="row">
            <div class="col text-center">
                <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <label for="contenido_txtFactura">N&uacute;mero de factura</label><br />
                <asp:TextBox ID="txtFactura" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La factura es obligatoria." ControlToValidate="txtFactura" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                <label for="contenido_ddlCliente">Cliente</label><br />
                <asp:DropDownList ID="ddlCliente" runat="server" DataValueField="Id" DataTextField="NombreCompleto"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Cliente es obligatorio." ControlToValidate="ddlCliente" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                <label for="contenido_txtFecha">Fecha</label><br />
                <asp:TextBox ID="txtFecha" runat="server" Enabled="false" TextMode="Date"></asp:TextBox>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div>
                    <h4>L&iacute;nea de Articulos</h4>
                </div>
            </div>
            <asp:Panel ID="pnlLineaAgregar" runat="server" CssClass="col-sm-12 col-md-12">
                <div class="row">
                    <div class="col-sm-4 col-md-4">
                        <label for="contenido_ddlProducto">Producto</label><br />
                        <asp:DropDownList ID="ddlProducto" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
                    </div>
                    <div class="col-sm-4 col-md-4">
                        <label for="contenido_txtCantidad">Cantidad</label><br />
                        <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number"
                            ToolTip="La cantidad debe ser un n&uacute;mero entero positivo mayor a uno."></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="txtCantidad" ForeColor="Red"
                            ErrorMessage="Debe ser un n&uacute;mero entero."
                            Operator="DataTypeCheck" Type="Integer"
                            Display="Dynamic" />
                        <asp:CompareValidator runat="server"
                            ControlToValidate="txtCantidad" ForeColor="Red"
                            ErrorMessage="Debe ser mayor a uno."
                            Operator="GreaterThanEqual"
                            ValueToCompare="1" Type="Integer"
                            Display="Dynamic" />
                    </div>
                    <div class="col-sm-4 col-md-4">
                        <asp:Button ID="btnAgregarArticulo" runat="server" CssClass="btn btn-secondary" Text="Agregar" OnClick="btnAgregarArticulo_Click" />
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-12 col-md-12">
                <asp:GridView ID="gvLineaArticulos" runat="server"
                    EmptyDataText="No Existen Lineas de articulos en la factura"
                    CssClass="table table-striped"
                    OnRowDeleting="gvLineaArticulos_RowDeleting"
                    AutoGenerateColumns="False"
                    DataKeyNames="Id" OnDataBound="gvLineaArticulos_DataBound">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdProducto" HeaderText="IdProducto">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="IdFactura" HeaderText="IdFactura">
                            <ItemStyle CssClass="d-none" />
                            <HeaderStyle CssClass="d-none" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                            <ControlStyle CssClass="btn btn-danger btn-sm" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />
    <p>
        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
            Detalle pago</button>
    </p>
    <div class="collapse show" id="collapseExample">
        <div class="card card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <label for="contenido_ddlFormaPago">Forma de pago</label><br />
                        <asp:DropDownList AutoPostBack="true" ID="ddlFormaPago" runat="server" DataValueField="Id" DataTextField="Nombre" OnSelectedIndexChanged="ddlFormaPago_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Forma de pago es obligatorio." ControlToValidate="ddlFormaPago" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <h6>Total:&nbsp;</h6>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <label for="contenido_ddlTipoMoneda">Tipo de moneda</label><br />
                        <asp:DropDownList AutoPostBack="true" ID="ddlTipoMoneda" runat="server" DataValueField="Id" DataTextField="Nombre" OnSelectedIndexChanged="ddlTipoMoneda_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Tipo de moneda es obligatorio." ControlToValidate="ddlTipoMoneda" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Panel ID="pnlCambio" runat="server" CssClass="col" Visible="false">
                        <h6>Tipo cambio:</h6>
                        <asp:Label ID="lblCambio" runat="server"></asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="pnlPago" runat="server" CssClass="col">
                        <h6>Pago recibido:</h6>
                        <asp:Label ID="lblPagado" runat="server"></asp:Label>
                        <asp:TextBox AutoPostBack="true" ID="txtPagado" runat="server"  TextMode="Number"
                            ToolTip="El pago debe ser un n&uacute;mero positivo mayor a uno. (Puede incluir decimales utilizando la coma. Ej: 1,00)" OnTextChanged="txtPagado_TextChanged"></asp:TextBox>
                        <asp:CompareValidator runat="server"
                            ControlToValidate="txtPagado" ForeColor="Red"
                            ErrorMessage="Debe ser mayor a uno."
                            Operator="GreaterThanEqual"
                            ValueToCompare="1"
                            Display="Dynamic" />
                    </asp:Panel>
                    <asp:Panel ID="pnlConvertido" runat="server" CssClass="col" Visible="false">
                        <h6>Pago en Colones:</h6>
                        <asp:Label ID="lblConvertido" runat="server"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col">
                    </div>
                    <div class="col">
                    </div>
                    <div class="col align-self-end text-center">
                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-primary" Text="Pagar" OnClick="btnSalvar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
