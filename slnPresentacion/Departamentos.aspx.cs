using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;


namespace slnPresentacion
{
    public partial class Departamento : System.Web.UI.Page
    {
        private IServiciosDepartamentos departamento = new AccionesDepartamentos();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDepartamento();
        }

        private void cargarDepartamento()
        {
            try
            {
                this.gvDepartamentos.DataSource = this.departamento.obtenerDepartamento();
                this.gvDepartamentos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void gvDepartamentos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                int index = int.Parse(e.Keys["Id"].ToString());
                this.departamento.eliminarDepartamento(index);
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('Departamento eliminado.');", true);
                this.cargarDepartamento();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void gvDepartamentos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Response.Redirect("~/DepartamentoForm.aspx?Id=" + this.gvDepartamentos.Rows[e.NewEditIndex].Cells[0].Text);
        }
    }

}
