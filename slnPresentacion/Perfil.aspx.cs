using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Perfil : System.Web.UI.Page
    {
        private IServiciosRoles roles = new AccionesRoles();
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}