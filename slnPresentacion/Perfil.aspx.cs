using System;
using slnLogica;
using slnDatos;
using System.Web.UI;

namespace slnPresentacion
{
    public partial class Perfil : Page
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
            if(sesion == null)
            {
                return;
            }
            this.txtEmail.Text = sesion.Email;
            this.txtClave.Attributes["value"] = sesion.Clave;
            this.ddlRoles.SelectedValue = sesion.IdRol.ToString();
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
                Page.Session["sesion"] = this.usuarios.obtenUsuarioSegunIdentificador(sesion.Id);
                Response.Redirect("~/Dashboard.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}