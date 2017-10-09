using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnPresentacion.controles
{
    public partial class MensajeSession : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Session["mensaje"] != null)
            {
                this.ltlMensajeSession.Text = string.Format("<div class=\"alert alert-success\">{0}</div>", Page.Session["mensaje"]);
                Page.Session.Remove("mensaje");
            }
        }
    }
}