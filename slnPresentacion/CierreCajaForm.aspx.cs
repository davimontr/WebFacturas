using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;
using slnDatos;
namespace slnPresentacion
{
    public partial class CierreCajaForm : System.Web.UI.Page
    {
        private IserviciosFacturas factura = new AccionesFacturas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cldFecha.TodaysDate = DateTime.Today;
                this.cldFecha.SelectedDate = DateTime.Today;
                this.gvCiereCaja.DataBind();
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
            this.gvCiereCaja.DataSource = this.factura.reporteCierre(this.cldFecha.SelectedDate);
            this.gvCiereCaja.DataBind();
        }
       
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            new Exportador().enPDF(this.gvCiereCaja, Response);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            new Exportador().enExcel(this.gvCiereCaja, Response);
        }
    }
}