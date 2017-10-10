using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        private IserviciosClientes clientes = new AccionesClientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Cliente cliente = this.clientes.obtenClienteSegunIdentificador(Identificador);
                this.txtCedula.Text = cliente.Cedula;
                this.txtNombre.Text = cliente.NombreCompleto;
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.clientes.incluirCliente(this.txtCedula.Text, this.txtNombre.Text);
                }
                else
                {
                    this.clientes.actualizaCliente(int.Parse(Identificador), this.txtCedula.Text, this.txtNombre.Text);
                }
                Page.Session.Add("mensaje", "Cliente salvado!");
                Response.Redirect("~/Clientes.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}