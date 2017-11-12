<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CierreCajaForm.aspx.cs" Inherits="slnPresentacion.CierreCajaForm" EnableEventValidation="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Cierre de Caja</h1>
    <asp:Calendar ID="cldFecha" runat="server" OnDayRender="cldFecha_DayRender"></asp:Calendar>
    <br />
    <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="btn-secondary" OnClick="btnGenerar_Click" />
    <br />
    <%# gvCiereCaja.Rows.Count != 0 ? "<h4>Detalle</h4>" :""%>
    <asp:GridView ID="gvCiereCaja" runat="server"
        EmptyDataText="No hay detalles registrados a mostrar"
        CssClass="table table-striped"
        AutoGenerateColumns="true">
    </asp:GridView>
    <asp:Label ID="lblMensaje" ForeColor="Red" runat="server"></asp:Label>
    <div class="container-fluid">
       <div class="row">
           <div class="col">
                <asp:Button ID="btnPdf" runat="server" Text="Exportar PDF" CssClass="btn-dark" OnClick="btnPdf_Click"/>
           </div>
           <div class="col">
                <asp:Button ID="btnExcel" runat="server" Text="Exportar Excel" CssClass="btn-dark" OnClick="btnExcel_Click"/>
           </div>
       </div>
   </div>
</asp:Content>
