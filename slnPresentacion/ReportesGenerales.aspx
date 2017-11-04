<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ReportesGenerales.aspx.cs" Inherits="slnPresentacion.ReportesGenerales" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Reportes Generales</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Visualización de Reportes</h4>
        </div>
    </section>
    <div class="container">
        <div class="row">
            <div class="col-sm text-center">
                <a href="/ReporteProductoDepartamento.aspx" class="badge badge-pill badge-info" style="font-size: medium;">Productos por Departamento</a>
            </div>
            <div class="col-sm text-center">
                 <a href="/CierreCajaForm.aspx" class="badge badge-pill badge-info" style="font-size: medium;">Cierre cajas</a>
            </div>
            <div class="col-sm text-center">
               <a href="#" class="badge badge-pill badge-info" style="font-size: medium;">Reporte...</a>
            </div>
        </div>
    </div>
</asp:Content>
