using System;
using System.Web.UI;
using slnLogica;

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
                    if (this.usuarios.iniciarSession(this.txtEmail.Text, this.txtClave.Text))
                    {
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
    }
}