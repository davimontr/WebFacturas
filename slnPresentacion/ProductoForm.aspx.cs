using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class ProductoForm : System.Web.UI.Page
    {
        private IserviciosProveedores proveedores = new AccionesProveedores();
        private IserviciosProductos productos = new AccionesProductos();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();


        private void cargarProveedores()
        {
            try
            {
                this.ddlProveedor.DataSource = this.proveedores.obtenerTodos();
                this.ddlProveedor.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        private void cargarProductoDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Producto producto = this.productos.obtenProductoSegunIdentificador(Identificador);
                this.txtCodigo.Text = producto.Codigo.ToString();
                this.txtProducto.Text = producto.Nombre;
                this.txtCosto.Text = producto.Costo.ToString();
                this.txtUtilidad.Text = producto.Utilidad.ToString();
                this.txtImpuesto.Text = producto.Impuesto.ToString();
                this.txtExistencia.Text = producto.Existencia.ToString();
                this.ddlProveedor.SelectedValue = producto.IdProveedor.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
                this.ddlDepartamento.SelectedValue = producto.Departamento.Id.ToString();
                this.checkboxGravado.Checked = producto.Gravado;
            }
        }

        private void cargarDepartamentos()
        {
            try
            {
                this.ddlDepartamento.DataSource = this.departamentos.obtenerDepartamento();
                this.ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.cargarProveedores();
                this.cargarDepartamentos();
                this.cargarProductoDeUrl();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int impuesto = 0;
            int.TryParse(this.txtImpuesto.Text, out impuesto);
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.productos.incluirProducto(
                        int.Parse(this.txtCodigo.Text),
                        this.txtProducto.Text,
                        int.Parse(this.txtCosto.Text),
                        int.Parse(this.txtUtilidad.Text),
                        impuesto,
                        int.Parse(this.txtExistencia.Text),
                        int.Parse(this.ddlProveedor.SelectedValue),
                        int.Parse(this.ddlDepartamento.SelectedValue),
                        this.checkboxGravado.Checked
                    );
                }
                else
                {
                    this.productos.actualizaProducto(
                        int.Parse(this.txtCodigo.Text),
                        int.Parse(Identificador),
                        this.txtProducto.Text,
                        int.Parse(this.txtCosto.Text),
                        int.Parse(this.txtUtilidad.Text),
                        impuesto,
                        int.Parse(this.txtExistencia.Text),
                        int.Parse(this.ddlProveedor.SelectedValue),
                        int.Parse(this.ddlDepartamento.SelectedValue),
                        this.checkboxGravado.Checked
                    );
                }
                new ControlSesiones(Page).crearAviso("Producto salvado.");
                Response.Redirect("~/Productos.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
    }
}