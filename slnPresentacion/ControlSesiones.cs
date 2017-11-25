using System.Web.UI;
using System.Collections.Specialized;
using slnDatos;
using System.Linq;

namespace slnPresentacion
{
    public class ControlSesiones
    {
        private Page pagina;

        public ControlSesiones(Page pagina)
        {
            this.pagina = pagina;
        }

        public void crearAviso(string texto)
        {
            NameValueCollection mensaje = new NameValueCollection()
                {
                    { "tipo", "alert-success" },
                    { "texto", texto}
                };
            this.pagina.Session.Add("mensaje", mensaje);
        }

        public void crearAlerta(string texto)
        {
            NameValueCollection mensaje = new NameValueCollection()
                {
                    { "tipo", "alert-warning" },
                    { "texto",  texto}
                };
            this.pagina.Session.Add("mensaje", mensaje);
        }

        public bool existeSesion()
        {
            return (this.pagina.Session["sesion"] != null);
        }

        public bool esAdministrador()
        {
            if (this.pagina.Session["sesion"] != null)
            {
                Usuario usuario = (Usuario)this.pagina.Session["sesion"];
                return (usuario.Role.Nombre.Equals("Administrador"));
            }
            return false;
        }

        public bool tienePermisos(string ruta)
        {
            string[] paginas = {
                "~/Usuarios.aspx",
                "~/UsuarioForm.aspx",
                "~/ReportesGenerales.aspx",
                "~/ReporteProductoDepartamento.aspx",
                "~/CierreCajaForm.aspx",
                "~/ReportPrductosProveedor.aspx",
                "~/ReporteVentasDepartamento.aspx",
                "~/GraficoVentas.aspx"
            };
            if (paginas.Contains(ruta) && !this.esAdministrador())
            {
                return false;
            }
            return true;
        }
    }
}