<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="GraficoVentas.aspx.cs" Inherits="slnPresentacion.GraficoVentas" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h1>Grafico de Ventas</h1>
    <section class="row text-center placeholders">
        <div class="col-6 col-sm-6 placeholder">
            <h4>Administraci&oacute;n Ventas por Departamento</h4>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"
                        AutoPostBack="true" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
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
    </section>
    <asp:Label ID="lblMensaje" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label>
</asp:Content>
