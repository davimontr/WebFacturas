<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CierreCajaForm.aspx.cs" Inherits="slnPresentacion.CierreCajaForm" %>

<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Ciere de Caja</h1>
    <asp:Label ID="Label1" runat="server" Text="Buscar fecha"></asp:Label>
    <asp:Calendar ID="CalendarObtenerFecha" runat="server"></asp:Calendar>
    <br />
    <asp:Button ID="btnGenerar" runat="server" Text="Generar" Height="38px" Width="108px" />
    <br />
    <br />
<asp:GridView ID="dgCiereCaja" runat="server" Height="135px" Width="678px"></asp:GridView>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>






