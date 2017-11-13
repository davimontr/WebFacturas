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


        int valor = 0;


        private void cargarDepartamentos()
        {
            try
            {
                var listaDepartamentos = this.departamentos.obtenerDepartamento();
                listaDepartamentos.Insert(0, new slnDatos.Departamento { Id = 0, Nombre = "Todos" });
                this.ddlDepartamento.DataSource = listaDepartamentos;
                this.ddlDepartamento.DataTextField = "Nombre";
                this.ddlDepartamento.DataValueField = "Id";
                // this.ddlDepartamento.SelectedValue = Convert.ToString(valor);
                //this.ddlDepartamento. = TextBox1.Text;

                //Convert.ToInt32( TextBox1.Text) =  ddlDepartamento.SelectedValue;

                //TextBox1.Text = ddlDepartamento.SelectedItem.Text;

         
             
                this.ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
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
                //this.gvReportProducDepa.DataSource = this.departamentos.reportDepartamento();
                //this.gvReportProducDepa.DataBind();


                //var query = this.departamentos.reportDepartamento();
                //gvReportProducDepa.DataSource = query.ToList();

//                GridView1.DataSource = new AccionesDepartamentos().reportDepartamento(Int32.Parse(this.ddlDepartamento.SelectedValue));

                GridView1.DataSource = this.departamentos.reportTodosDepa();


                GridView1.DataBind();
 
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
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
                this.lblMensaje.Text = ex.Message;
            }

        }


        protected void btnPdf_Click(object sender, EventArgs e)
        {
            new Exportador().enPDF(this.GridView1, Response);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('NO se logra exportar a Excel.');", true);
        }



    }
}