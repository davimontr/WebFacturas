using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnPresentacion
{
    public partial class MenuInterno : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ruta = this.Page.AppRelativeVirtualPath;
            StringBuilder HTML = new StringBuilder();
            NameValueCollection menu = new NameValueCollection()
            {
                { "/Dashboard.aspx", "Facturas" },
                { "/Clientes.aspx", "Clientes" },
                { "/Productos.aspx", "Productos" },
                { "/Proveedores.aspx", "Proveedores" }
            };

            HTML.AppendFormat("<ul class=\"nav nav-pills flex-column\">");
            for (int i = 0; i < menu.Count; i++)
            {
                bool estaActivo = (String.Format("~{0}", menu.GetKey(i)) == ruta);
                HTML.AppendFormat("<li class=\"nav-item\">");
                HTML.AppendFormat("<a class=\"nav-link{0}\" href=\"{1}\">{2}{3}</a>",
                    (estaActivo ? " active" : ""),
                    menu.GetKey(i),
                    menu.Get(i),
                    (estaActivo ? "<span class=\"sr-only\">(current)</span></a>" : "")
               );
                HTML.AppendFormat("</li>");
            }
            HTML.AppendFormat("</ul>");
            this.ltlMenu.Text = HTML.ToString();
        }
    }
}