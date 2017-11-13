using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class ReporteFacturas : System.Web.UI.Page
    {



        private IserviciosReportes repFac = new AccionesReportes();

        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

               cargarGrid();

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
                GridView1.DataSource = this.repFac.reportTodasFactu();


                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }


        protected void Filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                string IdFactura = this.txtFiltro.Text;
                if (0 == int.Parse(IdFactura))
                {
                    cargarGrid();
                }
                else
                {
                    GridView1.DataSource = this.repFac.reportFacturas(IdFactura);
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