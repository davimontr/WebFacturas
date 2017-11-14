using System;
using System.Web.UI;
using slnLogica;
using slnDatos;
using slnPresentacion.cr.fi.bccr.indicadoreseconomicos;

namespace WebFacturas
{
    public partial class InicioSession : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Usuario usuario = null;
                    if (this.usuarios.iniciarSession(this.txtEmail.Text, this.txtClave.Text, out usuario))
                    {
                        Page.Session.Add("sesion", usuario);
                        Response.Redirect("~/Dashboard.aspx");
                       
                    }
                    else
                    {
                        this.lblInicioSession.Text = "Correo y/o Clave incorrectas. Intente de nuevo.";
                    }
                }
                catch (Exception ex)
                {
                    this.lblInicioSession.Text = ex.Message;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            wsIndicadoresEconomicos webservice = new wsIndicadoresEconomicos();
            //webservice.ObtenerIndicadoresEconomicos("indicador","fecha_inicio","fecha_final","nombre","sub_niveles");
        }
    }
}