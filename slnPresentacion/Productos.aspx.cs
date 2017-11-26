using System;
using slnLogica;
using System.Web.UI;
using System.Collections.Generic;
using slnDatos;

namespace slnPresentacion
{
    public partial class Productos : System.Web.UI.Page
    { 
        private IserviciosProductos productos = new AccionesProductos();
        private IserviciosLineaArticulo lineas = new AccionesLineaArticulo();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarProductos();
        }

        private void cargarProductos()
        {
            try
            {
                List<object> productos = new List<object>();
                foreach(Producto producto in this.productos.obtenerTodos())
                {
                    productos.Add(new {
                        Id = producto.Id,
                        Codigo = producto.Codigo,
                        Nombre = producto.Nombre,
                        Costo = producto.Costo,
                        Utilidad = producto.Utilidad,
                        Impuesto = producto.Impuesto,
                        Existencia = producto.Existencia,
                        Proveedor = producto.Proveedore.Nombre,
                        Departamento = producto.Departamento.Nombre,
                        Gravado = producto.Gravado,
                        Precio = this.lineas.calcularPrecio(producto, 1)
                    });
                }
                this.gvProductos.DataSource = productos;
                this.gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void gvProductos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.productos.eliminarProducto(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Producto eliminado.');", true);
                this.cargarProductos();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void gvProductos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/ProductoForm.aspx?Id=" + this.gvProductos.Rows[e.NewEditIndex].Cells[0].Text);
        }
    }
}