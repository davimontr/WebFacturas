using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class FacturaForm : System.Web.UI.Page
    {
        private IserviciosProductos productos = new AccionesProductos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ddlProducto.DataSource = this.productos.obtenerTodos();
                this.ddlProducto.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}