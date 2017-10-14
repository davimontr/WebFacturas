using System.Web.UI;
using System.Collections.Specialized;

namespace slnPresentacion
{
    public class SesionMensajes
    {
        private Page pagina;

        public SesionMensajes(Page pagina)
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
    }
}