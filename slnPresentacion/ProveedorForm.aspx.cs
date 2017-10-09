using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class ProveedorForm : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.proveedores.incluirProveedor(this.txtNombre.Text);
                Page.Session.Add("mensaje", "Proveedor salvado!");
                Response.Redirect("~/Proveedores.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}