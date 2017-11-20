using System;
using slnLogica;
using slnDatos;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Globalization;

namespace slnPresentacion
{
    public partial class FacturaForm : Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        private IserviciosProductos productos = new AccionesProductos();
        private IserviciosClientes clientes = new AccionesClientes();
        private IServiciosTipoMoneda tipoMonedas = new AccionesTipoMoneda();
        private IServiciosFormaPago formaPagos = new AccionesFormaPago();
        private IserviciosLineaArticulo lineaArticulos = new AccionesLineaArticulo();
        private bool redireccionar = true;

        private void cargarFacturaDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Factura factura = this.facturas.obtenFacturaSegunIdentificador(Identificador);
                this.txtFactura.Text = factura.Numero.ToString();
                this.txtFactura.Enabled = false;
                this.txtFecha.Text = factura.Fecha.Date.ToString("yyyy-MM-dd");
                this.ddlCliente.SelectedValue = factura.IdCliente.ToString();
                this.ddlCliente.Enabled = false;
                this.ddlFormaPago.SelectedValue = factura.IdFormaPago.ToString();
                this.ddlFormaPago.Enabled = false;
                this.lblTotal.Text = factura.Total.ToString();
                this.ddlTipoMoneda.SelectedValue = factura.IdTipoMoneda.ToString();
                this.ddlTipoMoneda.Enabled = false;
                if (1 != factura.IdTipoMoneda)
                {
                    this.pnlConvertido.Visible = true;
                    decimal convertido = decimal.Parse(factura.Convertido.ToString());
                    this.lblConvertido.Text = convertido.ToString("n");
                }
                this.hdnIdentificador.Value = Identificador.ToString();
                this.lblPagado.Text = factura.Pagado.ToString("n");
                this.txtPagado.Visible = false;
                this.cargarLineaArticulos(Identificador);
                this.pnlLineaAgregar.Visible = false;
                int columnas = this.gvLineaArticulos.Columns.Count;
                this.gvLineaArticulos.Columns[--columnas].Visible = false;
                this.btnSalvar.Visible = false;
            }
            else
            {
                this.cargarProductos();
            }
        }

        private void cargarLineaArticulos(int IdFactura)
        {
            try
            {
                this.gvLineaArticulos.DataSource = this.lineaArticulos.obtenerTodosPorIdFactura(IdFactura);
                this.gvLineaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarProductos()
        {
            try
            {
                this.ddlProducto.DataSource = this.productos.obtenerTodos();
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

        private void defineFechaPredeterminada()
        {
            this.txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void invocarSalvarFactura(object sender, EventArgs e)
        {
            this.redireccionar = false;
            this.btnSalvar_Click(sender, e);
            this.redireccionar = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.defineFechaPredeterminada();
                this.cargarClientes();
                this.cargarTipoMoneda();
                this.cargarFormaPago();
                this.cargarFacturaDeUrl();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.gvLineaArticulos.Rows.Count == 0 && "btnAgregarArticulo" != ((Button)sender).ID)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Alerta",
                    "alert('Debe agregar al menos UNA linea de articulo.');",
                    true
                );
                return;
            }

            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.facturas.incluirFactura(
                        this.txtFactura.Text,
                        DateTime.Parse(this.txtFecha.Text),
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        int.Parse(this.ddlTipoMoneda.SelectedValue)
                    );
                }
                else
                {
                    decimal? convertido = null;
                    decimal transformado;
                    if (decimal.TryParse(this.lblConvertido.Text, out transformado))
                    {
                        convertido = transformado;
                    }

                    decimal pagado = 0;
                    int tipoMoneda = int.Parse(this.ddlTipoMoneda.SelectedValue);
                    if (this.redireccionar && !decimal.TryParse(this.txtPagado.Text, out pagado))
                    {
                        throw new ArgumentException("El pago debe ser definido.");
                    }

                    this.facturas.actualizaFactura(
                        int.Parse(Identificador),
                        this.txtFactura.Text,
                        DateTime.Parse(this.txtFecha.Text),
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        tipoMoneda,
                        pagado,
                        convertido
                   );

                    decimal total = decimal.Parse(this.lblTotal.Text);
                    if (this.redireccionar && 1 != tipoMoneda && total > decimal.Parse(this.lblConvertido.Text))
                    {
                        throw new ArgumentException("El pago debe ser mayor o igual al total.");
                    }
                    else if (this.redireccionar && 1 == tipoMoneda && total > pagado)
                    {
                        throw new ArgumentException("El pago debe ser mayor o igual al total.");
                    }

                }

                if (this.redireccionar)
                {
                    new ControlSesiones(Page).crearAviso("Factura salvada.");
                    Response.Redirect("~/Dashboard.aspx");
                }
                else if (string.IsNullOrEmpty(this.hdnIdentificador.Value))
                {
                    Factura factura = this.facturas.obtenFacturaSegunNumero(this.txtFactura.Text);
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
            if (string.IsNullOrEmpty(this.txtCantidad.Text))
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "Alerta",
                    "alert('Debe agregar una cantidad minima de un articulo.');",
                    true
                );
                return;
            }
            this.invocarSalvarFactura(sender, e);

            int IdFactura = int.Parse(this.hdnIdentificador.Value);
            Producto producto = this.productos.obtenProductoSegunIdentificador(int.Parse(this.ddlProducto.SelectedValue));

            this.lineaArticulos.incluirLineaArticulo(producto, int.Parse(this.txtCantidad.Text), IdFactura);
            this.cargarLineaArticulos(IdFactura);
        }

        protected void gvLineaArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                this.lineaArticulos.eliminarLineaArticulo((int)e.Keys["Id"]);
                this.cargarLineaArticulos(int.Parse(e.Values["IdFactura"].ToString()));
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void ddlFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("Contado" == this.ddlFormaPago.SelectedItem.Text)
            {
                this.pnlPago.Visible = true;
                this.ddlTipoMoneda.Enabled = true;
            }
            else
            {
                this.ddlTipoMoneda.SelectedValue = "1";
                this.ddlTipoMoneda.Enabled = false;
                this.txtPagado.Text = string.Empty;
                this.pnlPago.Visible = false;
                this.ddlTipoMoneda_SelectedIndexChanged(sender, e);
            }
        }

        protected void ddlTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrar = false;
            if ("Colones" != this.ddlTipoMoneda.SelectedItem.Text)
            {
                mostrar = true;
                decimal cambio = this.tipoMonedas.
                    obtenerTipoCambioDeMonedaPorId(int.Parse(this.ddlTipoMoneda.SelectedValue));
                this.lblCambio.Text = cambio.ToString("n");
                this.txtPagado_TextChanged(sender, e);
            }
            this.pnlCambio.Visible = mostrar;
            this.pnlConvertido.Visible = mostrar;
        }

        protected void txtPagado_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPagado.Text) || string.IsNullOrEmpty(this.lblCambio.Text))
            {
                return;
            }
            decimal pagado = Convert.ToDecimal(this.txtPagado.Text, CultureInfo.InvariantCulture);
            decimal cambio = Convert.ToDecimal(this.lblCambio.Text, CultureInfo.CurrentCulture);
            this.lblConvertido.Text = (cambio * pagado).ToString("n");
        }

        protected void gvLineaArticulos_DataBound(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (GridViewRow linea in this.gvLineaArticulos.Rows)
            {
                total += decimal.Parse(linea.Cells[5].Text);
            }
            this.facturas.actualizaTotalFactura(int.Parse(this.hdnIdentificador.Value), total);
            this.lblTotal.Text = total.ToString("n");
        }
    }
}