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

    }
}