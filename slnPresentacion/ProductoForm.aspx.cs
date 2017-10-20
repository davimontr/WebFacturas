using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class ProductoForm : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();
        private IserviciosProductos productos = new AccionesProductos();

        private void cargarProveedores()
        {
            try
            {
                this.ddlProveedor.DataSource = this.proveedores.obtenerTodos();
                this.ddlProveedor.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarProductoDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Producto producto = this.productos.obtenProductoSegunIdentificador(Identificador);
                this.txtProducto.Text = producto.Nombre;
                this.txtCosto.Text = producto.Costo.ToString();
                this.txtUtilidad.Text = producto.Utilidad.ToString();
                this.txtImpuesto.Text = producto.Impuesto.ToString();
                this.txtExistencia.Text = producto.Existencia.ToString();
                this.ddlProveedor.SelectedValue = producto.IdProveedor.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.cargarProductoDeUrl();
                this.cargarProveedores();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.productos.incluirProducto(
                        this.txtProducto.Text,
                        Int32.Parse(this.txtCosto.Text),
                        Int32.Parse(this.txtUtilidad.Text),
                        Int32.Parse(this.txtImpuesto.Text),
                        Int32.Parse(this.txtExistencia.Text),
                        Int32.Parse(this.ddlProveedor.SelectedValue)
                    );
                }
                else
                {
                    this.productos.actualizaProducto(
                        int.Parse(Identificador),
                        this.txtProducto.Text,
                        Int32.Parse(this.txtCosto.Text),
                        Int32.Parse(this.txtUtilidad.Text),
                        Int32.Parse(this.txtImpuesto.Text),
                        Int32.Parse(this.txtExistencia.Text),
                        Int32.Parse(this.ddlProveedor.SelectedValue)
                    );
                }
                new SesionMensajes(Page).crearAviso("Producto salvado.");
                Response.Redirect("~/Productos.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}