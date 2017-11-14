using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class CierreCajaForm : System.Web.UI.Page
    {
        private IserviciosFacturas factura = new AccionesFacturas();
        private IserviciosLineaArticulo lineas = new AccionesLineaArticulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cldFecha.TodaysDate = DateTime.Today;
                this.cldFecha.SelectedDate = DateTime.Today;
                this.gvCiereCaja.DataBind();
                this.gvImpuestos.DataBind();
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

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fecha = this.cldFecha.SelectedDate;
            this.gvCiereCaja.DataSource = this.factura.reporteCierre(fecha);
            this.gvCiereCaja.DataBind();
            this.gvImpuestos.DataSource = this.lineas.reporteImpuestoPorFecha(fecha);
            this.gvImpuestos.DataBind();
        }
       
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            List<GridView> cuadriculas = new List<GridView>();
            cuadriculas.Add(this.gvCiereCaja);
            cuadriculas.Add(this.gvImpuestos);
            new Exportador().cuadriculasEnPDF(cuadriculas, Response);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            new Exportador().enExcel(this.gvCiereCaja, Response);
        }
    }
}