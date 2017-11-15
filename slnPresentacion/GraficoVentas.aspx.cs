using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;
using System.Web.UI.DataVisualization.Charting;

namespace slnPresentacion
{
    public partial class GraficoVentas : System.Web.UI.Page
    {


        private IserviciosReportes repFac = new AccionesReportes();


        private IserviciosFacturas fac = new AccionesFacturas();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();





        protected void Page_Load(object sender, EventArgs e)
        {

            

        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            var resultados = this.departamentos.reporteVentasDepartamentoFecha(DateTime.Parse(this.txtFecha.Text));
            List<string> x = new List<string>(resultados.Count);
            List<decimal> y = new List<decimal>(resultados.Count);
            foreach(var fila in resultados)
            {
                x.Add(fila.GetType().GetProperty("Departamento").GetValue(fila).ToString());
                y.Add(decimal.Parse(fila.GetType().GetProperty("Cantidades").GetValue(fila).ToString()));
            }
            var xs = x.ToArray();
            var ys = y.ToArray();
            this.Chart1.Series[0].Points.DataBindXY(x, y);
            this.Chart1.Series[0].ChartType = SeriesChartType.Pie;
            this.Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            this.Chart1.Legends[0].Enabled = true;
        }
    }
}