using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;
using slnDatos;
namespace slnPresentacion
{
    public partial class CierreCajaForm : System.Web.UI.Page
    {
        private IserviciosFacturas factura = new AccionesFacturas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                defineFechaPredeterminada();
            }
        }


        private void defineFechaPredeterminada()
        {
            DateTime today = DateTime.Today;
            this.CalendarObtenerFecha.TodaysDate = today;
            this.CalendarObtenerFecha.SelectedDate = this.CalendarObtenerFecha.TodaysDate;

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            this.lblTotal.Text = this.factura.reporteCierre(this.CalendarObtenerFecha.SelectedDate).ToString();

        }
    }
}