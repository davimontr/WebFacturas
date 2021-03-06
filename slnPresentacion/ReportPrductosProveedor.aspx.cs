﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using slnLogica;

namespace slnPresentacion
{
    public partial class ReportPrductosProveedor : System.Web.UI.Page
    {

        private IserviciosProveedores provee = new AccionesProveedores();
        private IServiciosDepartamentos departamentos = new AccionesDepartamentos();
        
        //metodo para cargar los proveedores
        private void cargarProveedores()
        {
            try
            {
                var listaProveedores = this.provee.obtenerTodos();
                listaProveedores.Insert(0, new slnDatos.Proveedore { Id = 0, Nombre = "Todos" });
                this.ddlPRoveedor.DataSource = listaProveedores;
                this.ddlPRoveedor.DataTextField = "Nombre";
                this.ddlPRoveedor.DataValueField = "Id";

                this.ddlPRoveedor.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
        
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {

                cargarGrid();
                cargarProveedores();

            }

        }
        
        //metodo que carga todos los proveedores en el datagridview8
        private void cargarGrid()
        {
            try
            {
                GridView1.DataSource = this.provee.reportTodosProvee();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }

        protected void ddlPRoveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IdProvee = int.Parse(this.ddlPRoveedor.SelectedValue);
                if (0 == IdProvee)
                {
                    cargarGrid();
                }
                else
                {
                    GridView1.DataSource = this.provee.reportProveedores(IdProvee);
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