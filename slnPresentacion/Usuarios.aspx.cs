using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.Session["mensaje"] != null)
            {
                this.ltlMensajeSession.Text = string.Format("<div class=\"alert alert-success\">{0}</div>", Page.Session["mensaje"]);
                Page.Session.Remove("mensaje");
            }
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