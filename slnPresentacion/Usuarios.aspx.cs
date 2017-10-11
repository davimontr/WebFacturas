using System;
using slnLogica;
using System.Web.UI;

namespace slnPresentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            try
            {
                this.gvUsuarios.DataSource = this.usuarios.obtenerTodos();
                this.gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvUsuarios_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.usuarios.eliminarUsuario(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Usuario eliminado.');", true);
                this.cargarUsuarios();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void gvUsuarios_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/UsuarioForm.aspx?Id=" + this.gvUsuarios.Rows[e.NewEditIndex].Cells[0].Text);
        }
    }
}