<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ReporteProductoDepartamento.aspx.cs" Inherits="slnPresentacion.Reportes.ReporteProductoDepartamento" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menuInterno" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
</asp:Content>--%>


<%@ Register Src="~/controles/MenuInterno.ascx" TagName="MenuInterno" TagPrefix="ucMenu" %>
<asp:Content ID="Content3" ContentPlaceHolderID="menuInterno" runat="server">
    <ucMenu:MenuInterno ID="MenuInterno" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Reporte por Departamentos</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Administraci&oacute;n de Reporte por Departamentos</h4>
        </div>
        <div class="col-4 col-sm-4 placeholder">
                <%-- href="DepartamentoForm.aspx" --%>
            <h4>Filtro</h4>
            <span class="text-muted">Filtrar</span>
        </div>
    </section>
        EmptyDataText="No Existen Departamentos Registrados" 
        CssClass="table table-striped" 
        OnRowDeleting="gvReportProductosDepartamentos_RowDeleting" 
        OnRowEditing="gvReportProductosDepartamentos_RowEditing"
        AutoGenerateColumns="False"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id">
                <ItemStyle CssClass="d-none" />
                <HeaderStyle CssClass="d-none" />
            </asp:BoundField>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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


