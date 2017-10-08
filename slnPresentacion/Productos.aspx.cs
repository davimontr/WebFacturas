using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Productos : System.Web.UI.Page
    { 
        private IserviciosProductos productos = new AccionesProductos();
   
    
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // this.gvProductos.DataBind();
                this.gvProductos.DataSource = this.productos.obtenerTodos();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}