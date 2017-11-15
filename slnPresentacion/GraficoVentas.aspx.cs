using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class GraficoVentas : System.Web.UI.Page
    {


        private IserviciosReportes grafiVentas = new AccionesReportes();


        private IserviciosFacturas fac = new AccionesFacturas();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();





        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                cargarChar();

            }


        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        private void cargarChar()
        {
            try
            {
                Chart1.DataSource = this.grafiVentas.graficoVentasDepartamentos();
                Chart1.DataBind();

            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }





    }
}