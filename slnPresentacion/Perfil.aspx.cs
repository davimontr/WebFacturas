using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class Perfil : System.Web.UI.Page
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