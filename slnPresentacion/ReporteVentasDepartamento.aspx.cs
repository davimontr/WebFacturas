using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class ReporteVentasDepartamento : System.Web.UI.Page
    {

        private IserviciosReportes repFac = new AccionesReportes();


        private IserviciosFacturas fac = new AccionesFacturas();
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
                GridView1.DataSource = this.repFac.reportFacturasDepartamentos();

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

        protected void cldFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
                e.Cell.Font.Strikeout = true;
            }
        }

        protected void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = this.repFac.reportFacturasPorDepartamentos(this.cldFecha.SelectedDate);
            this.GridView1.DataBind();
        }
    }
}