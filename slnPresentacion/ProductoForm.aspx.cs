using System;
using slnLogica;

namespace slnPresentacion
{
    public partial class ProductoForm : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();
        private IserviciosProductos productos = new AccionesProductos();

        protected void Page_Load(object sender, EventArgs e)
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.productos.incluirProducto(
                    this.txtProducto.Text, 
                    Int32.Parse(this.txtCosto.Text), 
                    Int32.Parse(this.txtUtilidad.Text), 
                    Int32.Parse(this.txtImpuesto.Text), 
                    Int32.Parse(this.txtExistencia.Text),
                    Int32.Parse(this.ddlProveedor.SelectedValue)
                );
                Page.Session.Add("mensaje", "Producto salvado!");
                Response.Redirect("~/Productos.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}