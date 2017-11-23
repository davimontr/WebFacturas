using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class ProveedorForm : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();

        private void cargarProveedorDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Proveedore proveedor = this.proveedores.obtenProveedorSegunIdentificador(Identificador);
                this.txtNombre.Text = proveedor.Nombre;
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.cargarProveedorDeUrl();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.proveedores.incluirProveedor(this.txtNombre.Text);
                }
                else
                {
                    this.proveedores.actualizaProveedor(int.Parse(Identificador), this.txtNombre.Text);
                }
                new ControlSesiones(Page).crearAviso("Proveedor salvado.");
                Response.Redirect("~/Proveedores.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
    }
}