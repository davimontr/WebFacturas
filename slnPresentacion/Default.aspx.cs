using System;
using System.Web.UI;
using slnLogica;
using slnDatos;
using slnPresentacion.cr.fi.bccr.indicadoreseconomicos;
using System.Data;

namespace WebFacturas
{
    public partial class InicioSession : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();
        private IServiciosTipoMoneda tipoMonedas = new AccionesTipoMoneda();

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
                        wsIndicadoresEconomicos webservice = new wsIndicadoresEconomicos();
                        string fecha = DateTime.Today.ToString("dd/MM/yyyy");
                        DataSet respuesta = webservice.ObtenerIndicadoresEconomicos("317", fecha, fecha, "FacturacionUACA", "N");
                        if (respuesta.Tables[0].Rows.Count > 0)
                        {
                            decimal tipoCambio = decimal.Parse(respuesta.Tables[0].Rows[0].ItemArray[2].ToString());
                            this.tipoMonedas.actualizarTipoCambioMoneda("Dolares", tipoCambio);
                        }
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