using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using slnLogica;
using slnDatos;


namespace slnPresentacion
{


    public partial class DepartamentoForm : System.Web.UI.Page
    {
        private IServiciosDepartamentos departamento = new AccionesDepartamentos();


        private void cargarDepartamentoXID()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);

            
                slnDatos.Departamento departa = this.departamento.obtenerDepartamentoSegunID(Identificador);


                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarDepartamentoXID();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.departamento.incluirDepartamento(this.txtNombre.Text);
                }
                else
                {
                    this.departamento.actualizaDepartamento(int.Parse(Identificador), this.txtNombre.Text);
                }
                new ControlSesiones(Page).crearAviso("Departamento salvado.");
                Response.Redirect("~/Departamentos.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
    }
}