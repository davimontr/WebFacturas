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
                this.ddlDepartamento.DataSource = this.departamentos.obtenerDepartamento();
                this.ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cargarDepartamentos();


        }


        private void cargarGrid()
        {
            try
            {
                this.gvProductos.DataSource = this.prod.obtenerTodos();
                this.gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }






    }
}