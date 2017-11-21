using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class UsuarioForm : System.Web.UI.Page
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

        private void cargarUsuarioDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Usuario usuario = this.usuarios.obtenUsuarioSegunIdentificador(Identificador);
                this.txtEmail.Text = usuario.Email;
                this.txtClave.Attributes["value"] = usuario.Clave;
                this.ddlRoles.SelectedValue = usuario.IdRol.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarRoles();
                this.cargarUsuarioDeUrl();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.usuarios.incluirUsuario(this.txtEmail.Text, this.txtClave.Text, Int32.Parse(this.ddlRoles.SelectedValue));
                }
                else
                {
                    this.usuarios.actualizaUsuario(int.Parse(Identificador), this.txtEmail.Text, this.txtClave.Text, int.Parse(this.ddlRoles.SelectedValue));
                }
                new ControlSesiones(Page).crearAviso("Usuario salvado.");
                Response.Redirect("~/Usuarios.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}