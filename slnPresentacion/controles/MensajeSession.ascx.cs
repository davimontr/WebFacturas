using System;
using System.Collections.Specialized;
using System.Web.UI;

namespace slnPresentacion.controles
{
    public partial class MensajeSession : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Session["mensaje"] != null)
            {
                NameValueCollection mensaje = (NameValueCollection)Page.Session["mensaje"];
                this.ltlMensajeSession.Text = string.Format("<div class=\"alert {0}\">{1}</div>", mensaje["tipo"], mensaje["texto"]);
                Page.Session.Remove("mensaje");
            }
        }
    }
}