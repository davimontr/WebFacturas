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
            cargarGrid();
        }
        private void cargarGrid()
        {
            try
            {
                this.dgCiereCaja.DataSource = this.factura.obtenerTodos();
                this.dgCiereCaja.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void defineFechaPredeterminada()
        {
            DateTime today = DateTime.Today;
            this.CalendarObtenerFecha.TodaysDate = today;
            this.CalendarObtenerFecha.SelectedDate = this.CalendarObtenerFecha.TodaysDate;
           
        }
    }
}