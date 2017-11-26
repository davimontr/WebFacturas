using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion.Reportes
{
    public partial class ReporteProductoDepartamento : System.Web.UI.Page
    {
        private IserviciosProductos prod = new AccionesProductos();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();

        private void cargarDepartamentos()
        {
            try
            {
                var listaDepartamentos = this.departamentos.obtenerDepartamento();
                listaDepartamentos.Insert(0, new slnDatos.Departamento { Id = 0, Nombre = "Todos" });
                this.ddlDepartamento.DataSource = listaDepartamentos;
                this.ddlDepartamento.DataTextField = "Nombre";
                this.ddlDepartamento.DataValueField = "Id";
                this.ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (!Page.IsPostBack)
            {
                cargarGrid();
                cargarDepartamentos();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void cargarGrid()
        {
            try
            {
                GridView1.DataSource = this.departamentos.reportTodosDepa();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IdDepartamento = int.Parse(this.ddlDepartamento.SelectedValue);
                if (0 == IdDepartamento)
                {
                    cargarGrid();
                }
                else
                {
                    GridView1.DataSource = this.departamentos.reportDepartamento(IdDepartamento);
                }
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            new Exportador().enPDF(this.GridView1, Response);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            new Exportador().enExcel(this.GridView1, Response);
        }        
    }
}