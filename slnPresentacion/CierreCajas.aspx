<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CierreCajas.aspx.cs" Inherits="slnPresentacion.CierreCajas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <asp:GridView ID="GridView1" runat="server"
        EmptyDataText="Blah">
    </asp:GridView>
</asp:Content>
