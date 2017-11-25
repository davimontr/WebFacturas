using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;
using System.Web.UI.DataVisualization.Charting;

namespace slnPresentacion
{
    public partial class GraficoVentas : Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    this.gvFechaFecturas.DataSource = this.facturas.reporteFechaFacturas();
                    this.gvFechaFecturas.DataBind();
                }
                catch (Exception ex)
                {
                    this.lblMensaje.Text = ex.GetBaseException().Message;
                }
            }
        }

        protected void cldFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                e.Cell.Font.Strikeout = true;
            }
        }

        protected void cldFecha_SelectionChanged(object sender, EventArgs e)
        {
            var resultados = this.departamentos.reporteVentasDepartamentoFecha(this.cldFecha.SelectedDate);
            List<string> x = new List<string>(resultados.Count);
            List<decimal> y = new List<decimal>(resultados.Count);
            foreach(var fila in resultados)
            {
                x.Add(fila.GetType().GetProperty("Departamento").GetValue(fila).ToString());
                y.Add(decimal.Parse(fila.GetType().GetProperty("Cantidades").GetValue(fila).ToString()));
            }
            this.Chart1.Series[0].Points.DataBindXY(x, y);
            this.Chart1.Series[0].ChartType = SeriesChartType.Pie;
            this.Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            this.Chart1.Legends[0].Enabled = true;
        }
    }
}