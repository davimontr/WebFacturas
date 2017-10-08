using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Proveedores : System.Web.UI.Page
    {
        private IserviciosProveedores proveedor = new AccionesProveedores();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
                this.gvProveedores.DataSource = this.proveedor.obtenerTodos();
                this.gvProveedores.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}