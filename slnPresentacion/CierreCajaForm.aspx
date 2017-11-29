<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="CierreCajaForm.aspx.cs" Inherits="slnPresentacion.CierreCajaForm" EnableEventValidation="false" %>

<asp:Content ID="Content3" ContentPlaceHolderID="contenido" runat="server">
    <h1>Cierre de Caja</h1>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:Calendar ID="cldFecha" runat="server" OnDayRender="cldFecha_DayRender"></asp:Calendar>
            </div>
            <div class="col">
                <asp:Chart ID="Chart1" runat="server">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Items" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </div>
    <br />
    <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="btn-secondary" OnClick="btnGenerar_Click" />
    <br />
    <asp:GridView ID="gvCiereCaja" runat="server"
        Caption="Cierre cajas"
        EmptyDataText="No hay detalles registrados a mostrar"
        CssClass="table table-striped"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Ventas" HeaderText="Ventas" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Gravados" HeaderText="Gravados" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Excentos" HeaderText="Excentos" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Colones" HeaderText="Colones" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Dolares" HeaderText="Dolares" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Euros" HeaderText="Euros" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Convertidos" HeaderText="Convertidos" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Pagado" HeaderText="Pagado" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Credito" HeaderText="Credito" DataFormatString="{0:n}" />
            <asp:BoundField DataField="Diferencia" HeaderText="Diferencia" DataFormatString="{0:n}" />
        </Columns>
    </asp:GridView>
    <button class="btn btn-primary" type="button" data-toggle="collapse"
        data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
        Detalle impuestos</button>
    <div class="collapse show" id="collapseExample">
        <div class="card card-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="gvImpuestos" runat="server"
                            Caption="Detalle impuestos"
                            EmptyDataText="No hay detalles de impuestos a mostrar"
                            CssClass="table table-striped"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Impuesto" HeaderText="Impuesto" />
                                <asp:BoundField DataField="Costos" HeaderText="Costos" DataFormatString="{0:n}" />
                                <asp:BoundField DataField="Cantidades" HeaderText="Cantidades" />
                                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:n}" />
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
