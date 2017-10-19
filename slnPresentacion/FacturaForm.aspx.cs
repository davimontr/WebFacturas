using System;
using slnLogica;
using slnDatos;
using System.Collections.Generic;

namespace slnPresentacion
{
    public partial class FacturaForm : System.Web.UI.Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        private IserviciosProductos productos = new AccionesProductos();
        private IserviciosClientes clientes = new AccionesClientes();
        private IServiciosTipoMoneda tipoMonedas = new AccionesTipoMoneda();
        private IServiciosFormaPago formaPagos = new AccionesFormaPago();
        private IserviciosLineaArticulo lineaArticulos = new AccionesLineaArticulo();

        private void cargarFacturaDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Factura factura = this.facturas.obtenFacturaSegunIdentificador(Identificador);
                this.txtFactura.Text = factura.Factura1.ToString();
                this.cldFecha.SelectedDate = factura.Fecha.Date;
                this.cldFecha.VisibleDate = factura.Fecha.Date;
                this.ddlCliente.SelectedValue = factura.IdCliente.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        private void cargarProductos()
        {
            try
            {
                Page.Session["productos"] = this.productos.obtenerTodos();
                this.ddlProducto.DataSource = Page.Session["productos"];
                this.ddlProducto.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarClientes()
        {
            try
            {
                this.ddlCliente.DataSource = this.clientes.obtenerTodos();
                this.ddlCliente.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarTipoMoneda()
        {
            try
            {
                this.ddlTipoMoneda.DataSource = this.tipoMonedas.obtenerTodos();
                this.ddlTipoMoneda.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarFormaPago()
        {
            try
            {
                this.ddlFormaPago.DataSource = this.formaPagos.obtenerTodos();
                this.ddlFormaPago.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarFacturaDeUrl();
                this.cargarProductos();
                this.cargarClientes();
                this.cargarTipoMoneda();
                this.cargarFormaPago();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e, bool redireccionar = true)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.facturas.incluirFactura(
                        this.txtFactura.Text,
                        this.cldFecha.SelectedDate,
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        int.Parse(this.lblTotal.Text),
                        int.Parse(this.ddlTipoMoneda.SelectedValue)
                    );
                }
                else
                {
                    this.facturas.actualizaFactura(
                        int.Parse(Identificador),
                        this.txtFactura.Text,
                        this.cldFecha.SelectedDate,
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        int.Parse(this.lblTotal.Text),
                        int.Parse(this.ddlTipoMoneda.SelectedValue)
                   );
                }

                if (redireccionar)
                {
                    new SesionMensajes(Page).crearAviso("Factura salvada.");
                    Response.Redirect("~/Dashboard.aspx");
                }
                else if(string.IsNullOrEmpty(this.hdnIdentificador.Value))
                {
                    Factura factura = this.facturas.obtenFacturaSegunFactura(this.txtFactura.Text);
                    this.txtFactura.Enabled = false;
                    this.hdnIdentificador.Value = factura.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

            this.btnSalvar_Click(sender, e, false);

            Producto producto = ((List<Producto>)Page.Session["productos"]).Find(p => p.Id == int.Parse(this.ddlProducto.SelectedValue));
            int IdFactura = int.Parse(this.hdnIdentificador.Value);

            this.lineaArticulos.incluirLineaArticulo(producto, int.Parse(this.txtCantidad.Text), IdFactura);

            this.gvLineaArticulos.DataSource = this.lineaArticulos.obtenerTodosPorIdFactura(IdFactura);
            this.gvLineaArticulos.DataBind();
        }

        protected void gvLineaArticulos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

        }

        protected void gvLineaArticulos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

        }
    }
}