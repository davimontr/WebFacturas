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


        private IserviciosReportes repFac = new AccionesReportes();


        private IserviciosFacturas fac = new AccionesFacturas();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();





        protected void Page_Load(object sender, EventArgs e)
        {




        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }




    }
}