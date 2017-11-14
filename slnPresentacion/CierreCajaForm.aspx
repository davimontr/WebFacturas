<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CierreCajaForm.aspx.cs" Inherits="slnPresentacion.CierreCajaForm" EnableEventValidation="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Cierre de Caja</h1>
    <asp:Calendar ID="cldFecha" runat="server" OnDayRender="cldFecha_DayRender"></asp:Calendar>
    <br />
    <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="btn-secondary" OnClick="btnGenerar_Click" />
    <br />
    <asp:GridView ID="gvCiereCaja" runat="server"
        EmptyDataText="No hay detalles registrados a mostrar"
        CssClass="table table-striped"
        AutoGenerateColumns="true">
    </asp:GridView>
    <button class="btn btn-primary" type="button" data-toggle="collapse"
        data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
        Detalle impuestos
    </button>
    <div class="collapse show" id="collapseExample">
        <div class="card card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="gvImpuestos" runat="server"
                            EmptyDataText="No hay detalles de impuestos a mostrar"
                            CssClass="table table-striped"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Impuesto" HeaderText="Impuesto" />
                                <asp:BoundField DataField="Costos" HeaderText="Costos" />
                                <asp:BoundField DataField="Cantidades" HeaderText="Cantidades" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <ItemStyle CssClass="d-none" />
                                    <HeaderStyle CssClass="d-none" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMensaje" ForeColor="Red" runat="server"></asp:Label>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:Button ID="btnPdf" runat="server" Text="Exportar PDF" CssClass="btn-dark" OnClick="btnPdf_Click" />
            </div>
            <div class="col">
                <asp:Button ID="btnExcel" runat="server" Text="Exportar Excel" CssClass="btn-dark" OnClick="btnExcel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
