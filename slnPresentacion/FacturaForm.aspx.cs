using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class FacturaForm : System.Web.UI.Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        private IserviciosProductos productos = new AccionesProductos();
        private IserviciosClientes clientes = new AccionesClientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Factura factura = this.facturas.obtenFacturaSegunIdentificador(Identificador);
                this.txtFactura.Text = factura.Factura1.ToString();
                this.txtFecha.Text = factura.Fecha.ToShortDateString();
                this.ddlCliente.SelectedValue = factura.IdCliente.ToString();
                this.txtDescuento.Text = factura.Descuento.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
            }
            try
            {
                this.ddlCliente.DataSource = this.clientes.obtenerTodos();
                this.ddlCliente.DataBind();

                this.ddlProducto.DataSource = this.productos.obtenerTodos();
                this.ddlProducto.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.facturas.incluirFactura(
                    this.txtFactura.Text,
                    DateTime.Parse(this.txtFecha.Text),
                    Int32.Parse(this.ddlCliente.SelectedValue),
                    Int32.Parse(this.txtDescuento.Text)
                );
                }
                else
                {
                    this.facturas.actualizaFactura(
                        int.Parse(Identificador),
                        this.txtFactura.Text,
                        DateTime.Parse(this.txtFecha.Text),
                        Int32.Parse(this.ddlCliente.SelectedValue),
                        Int32.Parse(this.txtDescuento.Text)
                   );
                }    
                Page.Session.Add("mensaje", "Factura salvada!");
                Response.Redirect("~/Dashboard.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

        }

        protected void gvLineaArticulos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

        }

        protected void gvLineaArticulos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

        }
    }
}