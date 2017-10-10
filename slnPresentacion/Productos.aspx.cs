using System;
using slnLogica;
using System.Web.UI;

namespace slnPresentacion
{
    public partial class Productos : System.Web.UI.Page
    { 
        private IserviciosProductos productos = new AccionesProductos();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.gvProductos.DataSource = this.productos.obtenerTodos();
                this.gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvProductos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.productos.eliminarProducto(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Producto eliminado.');", true);
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvProductos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/ProductosForm.aspx?Id=" + this.gvProductos.Rows[e.NewEditIndex].Cells[0].Text);
        }
    }
}