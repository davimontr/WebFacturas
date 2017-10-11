using System;
using slnLogica;
using System.Web.UI;

namespace slnPresentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        private IserviciosClientes clientes = new AccionesClientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void cargarClientes()
        {
            try
            {
                this.gvClientes.DataSource = this.clientes.obtenerTodos();
                this.gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.clientes.eliminarCliente(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Cliente eliminado.');", true);
                this.cargarClientes();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvClientes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/ClienteForm.aspx?Id=" + this.gvClientes.Rows[e.NewEditIndex].Cells[0].Text);
        }
    }
}