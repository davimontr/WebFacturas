using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        private IserviciosClientes clientes = new AccionesClientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.gvClientes.DataSource = this.clientes.obtenerTodos();
                this.gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}