using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class Perfil : System.Web.UI.Page
    {
        private IServiciosRoles roles = new AccionesRoles();
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        private void cargarRoles()
        {
            try
            {
                this.ddlRoles.DataSource = this.roles.obtenerTodos();
                this.ddlRoles.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarUsuarioSesion()
        {
            Usuario sesion = (Usuario)Page.Session["sesion"];
            this.txtEmail.Text = sesion.Email;
            this.txtClave.Attributes["value"] = sesion.Clave;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.cargarRoles();
                this.cargarUsuarioSesion();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try {
                Usuario sesion = (Usuario)Page.Session["sesion"];
                this.usuarios.actualizaUsuario(sesion.Id, this.txtEmail.Text, this.txtClave.Text, int.Parse(this.ddlRoles.SelectedValue));
                new SesionMensajes(Page).crearAviso("Perfil salvado.");
                Response.Redirect("~/Dasboard.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}