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
                this.txtDescuento.Text = factura.Descuento.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        private void cargarClienteProductos()
        {
            try
            {
                this.ddlCliente.DataSource = this.clientes.obtenerTodos();
                this.ddlCliente.DataBind();

                Page.Session["productos"] = this.productos.obtenerTodos();
                this.ddlProducto.DataSource = Page.Session["productos"];
                this.ddlProducto.DataBind();
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
                this.cargarClienteProductos();
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
                    this.cldFecha.SelectedDate,
                    Int32.Parse(this.ddlCliente.SelectedValue),
                    Int32.Parse(this.txtDescuento.Text)
                );
                }
                else
                {
                    this.facturas.actualizaFactura(
                        int.Parse(Identificador),
                        this.txtFactura.Text,
                        this.cldFecha.SelectedDate,
                        Int32.Parse(this.ddlCliente.SelectedValue),
                        Int32.Parse(this.txtDescuento.Text)
                   );
                }
                new SesionMensajes(Page).crearAviso("Factura salvada.");
                Response.Redirect("~/Dashboard.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {

            
            Producto producto = ((List<Producto>)Page.Session["productos"]).Find(p => p.Id == int.Parse(this.ddlProducto.SelectedValue)); ;

            LineaArticulo linea = new LineaArticulo {
                Producto = producto,
                Cantidad = int.Parse(this.txtCantidad.Text),
            };

            List<LineaArticulo> lineas = new List<LineaArticulo>();
            lineas.Add(linea);

            this.gvLineaArticulos.DataSource = lineas;
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