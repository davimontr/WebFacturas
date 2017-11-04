using System;
using slnLogica;
using System.Web.UI;
using slnPresentacion;

namespace WebFacturas
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarFacturas();
        }

        private void cargarFacturas()
        {
            try
            {
                this.gvFacturas.DataSource = this.facturas.obtenerTodos();
                this.gvFacturas.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvFacturas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.facturas.eliminarFactura(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Factura eliminada.');", true);
                this.cargarFacturas();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvFacturas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/FacturaForm.aspx?Id=" + this.gvFacturas.Rows[e.NewEditIndex].Cells[0].Text);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            new Exportador().enPDF(this.gvFacturas, Response);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('NO se logra exportar a Excel.');", true);
        }
    }
}