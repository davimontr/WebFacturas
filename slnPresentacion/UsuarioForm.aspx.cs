using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class UsuarioForm : System.Web.UI.Page
    {
        private IServiciosRoles roles = new AccionesRoles();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ddlRoles.DataSource = this.roles.obtenerTodos();
                this.ddlRoles.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}