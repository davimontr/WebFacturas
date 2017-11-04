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
    <div class="container">
        <div class="row">
            <div class="col">
                <label for="contenido_txtFactura">Factura</label><br />
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
                    <h4>Lineas de Articulos</h4>
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
                    DataKeyNames="Id">
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
            Detalle pago
        </button>
    </p>
    <div class="collapse show" id="collapseExample">
        <div class="card card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <label for="contenido_ddlFormaPago">Forma de pago</label><br />
                        <asp:DropDownList ID="ddlFormaPago" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Forma de pago es obligatorio." ControlToValidate="ddlFormaPago" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <h4>Total:&nbsp;</h4>
                        <asp:TextBox ID="txtTotal" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <label for="contenido_ddlTipoMoneda">Tipo de moneda</label><br />
                        <asp:DropDownList ID="ddlTipoMoneda" runat="server" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Tipo de moneda es obligatorio." ControlToValidate="ddlTipoMoneda" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col">
                        <h4>Tipo cambio:</h4>
                        <asp:TextBox ID="txtCambio" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col">
                        <h4>Pago recibido:</h4>
                        <asp:TextBox ID="txtPagado" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <h4>Pago en Colones:</h4>
                        <asp:TextBox ID="txtConvertido" runat="server"  Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary" Text="Pagar" OnClick="btnSalvar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
