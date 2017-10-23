using slnPresentacion;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace WebFacturas
{
    public partial class DashboardMaster : System.Web.UI.MasterPage
    {
        private void revisarSesion()
        {
            if (Page.Session["sesion"] == null)
            {
                new SesionMensajes(Page).crearAlerta("Debe iniciar sesion.");
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.revisarSesion();
            this.agregarNavegacion();
        }

        private void agregarNavegacion()
        {
            string ruta = this.contenido.Page.AppRelativeVirtualPath;
            string[] paginas = {
                "~/Dashboard.aspx",
                "~/Clientes.aspx",
                "~/Productos.aspx",
                "~/Proveedores.aspx",
                "~/Departamentos.aspx"
            };
            if(paginas.Contains(ruta))
            {
                this.pnlMenuRapido.Visible = true;
            }
            StringBuilder HTML = new StringBuilder();
            NameValueCollection menu = new NameValueCollection()
            {
                { "/Dashboard.aspx", "Inicio" },
                { "/Usuarios.aspx", "Usuarios" },
                { "/Perfil.aspx", "Perfil" },
                { "https://www.google.com/", "Ayuda" }
            };

            HTML.AppendFormat("<ul class=\"navbar-nav mr-auto\">");
            for (int i = 0; i < menu.Count; i++)
            {
                bool estaActivo = (String.Format("~{0}", menu.GetKey(i)) == ruta);
                HTML.AppendFormat("<li class=\"nav-item{0}\">", (estaActivo ? " active" : ""));
                HTML.AppendFormat("<a class=\"nav-link\" href=\"{0}\">{1}{2}</a>",
                    menu.GetKey(i),
                    menu.Get(i),
                    (estaActivo ? "<span class=\"sr-only\">(current)</span></a>" : "")
               );
                HTML.AppendFormat("</li>");
            }
            HTML.AppendFormat("</ul>");
            this.ltlNavegacion.Text = HTML.ToString();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Page.Session.Remove("sesion");
            new SesionMensajes(Page).crearAviso("Sesion terminada.");
            Response.Redirect("~/Default.aspx");
        }
    }
}