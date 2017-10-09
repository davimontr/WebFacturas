using System;
using System.Web.UI.WebControls;
using slnLogica;
using System.Web.UI;

namespace slnPresentacion
{
    public partial class Proveedores : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.gvProveedores.DataSource = this.proveedores.obtenerTodos();
                this.gvProveedores.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.proveedores.eliminarProveedor(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Proveedor eliminado.');", true);
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }

        }

        protected void gvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/ProveedorForm.aspx?Id=" + this.gvProveedores.Rows[e.NewEditIndex].Cells[2].Text);
        }
    }
}