using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //this.gvUsuarios.DataSource = this.usuarios.obtenerTodos();
                this.gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}