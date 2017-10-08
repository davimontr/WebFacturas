<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="slnPresentacion.Clientes" %>
<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Clientes</h1>
     <section class="row text-center placeholders">
        <div class="col-10 col-sm-10 placeholder">
            <h4>Administraci&oacute;n de clientes</h4>
        </div>
        <div class="col-2 col-sm-2 placeholder">
            <a class="w3-button w3-large w3-circle w3-xlarge w3-ripple w3-teal" style="z-index:0">+</a>
            <h4>Nuevo</h4>
            <span class="text-muted">Agregar cliente</span>
        </div>
    </section>
    <div class="table-responsive">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Header</th>
                    <th>Header</th>
                    <th>Header</th>
                    <th>Header</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1,001</td>
                    <td>Lorem</td>
                    <td>ipsum</td>
                    <td>dolor</td>
                    <td>sit</td>
                </tr>
                <tr>
                    <td>1,002</td>
                    <td>amet</td>
                    <td>consectetur</td>
                    <td>adipiscing</td>
                    <td>elit</td>
                </tr>
                <tr>
                    <td>1,003</td>
                    <td>Integer</td>
                    <td>nec</td>
                    <td>odio</td>
                    <td>Praesent</td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
