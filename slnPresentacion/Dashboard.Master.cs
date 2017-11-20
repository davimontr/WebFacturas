using slnPresentacion;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace WebFacturas
{
    public partial class DashboardMaster : System.Web.UI.MasterPage
    {
        private ControlSesiones controlSesiones;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.controlSesiones = new ControlSesiones(Page);
            if(!this.controlSesiones.existeSesion())
            {
                this.controlSesiones.crearAlerta("Debe iniciar sesion.");
                Response.Redirect("~/Default.aspx");
            }
            string ruta = this.contenido.Page.AppRelativeVirtualPath;
            if(!this.controlSesiones.tienePermisos(ruta))
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                Response.End();
            }
            this.agregarNavegacion(ruta);
        }

        private void agregarNavegacion(string ruta)
        {   
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
                { "/Perfil.aspx", "Perfil" },
                { "https://www.google.com/", "Ayuda" }
            };

            if(this.controlSesiones.esAdministrador())
            {
                menu.Add("/Usuarios.aspx", "Usuarios");
                menu.Add("/ReportesGenerales.aspx", "Reportes Generales");
            }

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
            new ControlSesiones(Page).crearAviso("Sesion terminada.");
            Response.Redirect("~/Default.aspx");
        }
    }
}