using System;
using slnLogica;

namespace WebFacturas
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        protected void Page_Load(object sender, EventArgs e)
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
    }
}