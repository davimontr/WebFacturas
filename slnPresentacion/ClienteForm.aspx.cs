using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        private IserviciosClientes clientes = new AccionesClientes();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.clientes.incluirCliente();
                Page.Session.Add("mensaje", "Cliente salvado!");
                Response.Redirect("~/Clientes.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}