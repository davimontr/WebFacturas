﻿using System;
using slnLogica;
using slnDatos;
using System.Collections.Generic;

namespace slnPresentacion
{
    public partial class FacturaForm : System.Web.UI.Page
    {
        private IserviciosFacturas facturas = new AccionesFacturas();
        private IserviciosProductos productos = new AccionesProductos();
        private IserviciosClientes clientes = new AccionesClientes();
        private IServiciosTipoMoneda tipoMonedas = new AccionesTipoMoneda();
        private IServiciosFormaPago formaPagos = new AccionesFormaPago();
        private IserviciosLineaArticulo lineaArticulos = new AccionesLineaArticulo();
        private bool redireccionar = true;

        private void cargarFacturaDeUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Factura factura = this.facturas.obtenFacturaSegunIdentificador(Identificador);
                this.txtFactura.Text = factura.Numero.ToString();
                this.txtFactura.Enabled = false;
                this.cldFecha.SelectedDate = factura.Fecha.Date;
                this.cldFecha.VisibleDate = factura.Fecha.Date;
                this.ddlCliente.SelectedValue = factura.IdCliente.ToString();
                this.ddlFormaPago.SelectedValue = factura.IdFormaPago.ToString();
                this.txtTotal.Text = factura.Total.ToString();
                this.ddlTipoMoneda.SelectedValue = factura.IdTipoMoneda.ToString();
                this.hdnIdentificador.Value = Identificador.ToString();
                this.cargarLineaArticulos(Identificador);
            }
        }

        private void cargarLineaArticulos(int IdFactura)
        {
            try
            {
                this.gvLineaArticulos.DataSource = this.lineaArticulos.obtenerTodosPorIdFactura(IdFactura);
                this.gvLineaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarProductos()
        {
            try
            {
                this.ddlProducto.DataSource = this.productos.obtenerTodos();
                this.ddlProducto.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarClientes()
        {
            try
            {
                this.ddlCliente.DataSource = this.clientes.obtenerTodos();
                this.ddlCliente.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarTipoMoneda()
        {
            try
            {
                this.ddlTipoMoneda.DataSource = this.tipoMonedas.obtenerTodos();
                this.ddlTipoMoneda.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void cargarFormaPago()
        {
            try
            {
                this.ddlFormaPago.DataSource = this.formaPagos.obtenerTodos();
                this.ddlFormaPago.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        private void defineFechaPredeterminada()
        {
            DateTime today = DateTime.Today;
            this.cldFecha.TodaysDate = today;
            this.cldFecha.SelectedDate = this.cldFecha.TodaysDate;
        }

        private void invocarSalvarFactura(object sender, EventArgs e)
        {
            this.redireccionar = false;
            this.btnSalvar_Click(sender, e);
            this.redireccionar = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.defineFechaPredeterminada();
                this.cargarFacturaDeUrl();
                this.cargarClientes();
                this.cargarProductos();
                this.cargarTipoMoneda();
                this.cargarFormaPago();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.facturas.incluirFactura(
                        this.txtFactura.Text,
                        this.cldFecha.SelectedDate,
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        int.Parse(this.ddlTipoMoneda.SelectedValue)
                    );
                }
                else
                {
                    this.facturas.actualizaFactura(
                        int.Parse(Identificador),
                        this.txtFactura.Text,
                        this.cldFecha.SelectedDate,
                        int.Parse(this.ddlCliente.SelectedValue),
                        int.Parse(this.ddlFormaPago.SelectedValue),
                        int.Parse(this.ddlTipoMoneda.SelectedValue)
                   );
                }

                if (this.redireccionar)
                {
                    new SesionMensajes(Page).crearAviso("Factura salvada.");
                    Response.Redirect("~/Dashboard.aspx");
                }
                else if(string.IsNullOrEmpty(this.hdnIdentificador.Value))
                {
                    Factura factura = this.facturas.obtenFacturaSegunNumero(this.txtFactura.Text);
                    this.txtFactura.Enabled = false;
                    this.hdnIdentificador.Value = factura.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            this.invocarSalvarFactura(sender, e);

            int IdFactura = int.Parse(this.hdnIdentificador.Value);
            Producto producto = this.productos.obtenProductoSegunIdentificador(int.Parse(this.ddlProducto.SelectedValue));
            
            this.lineaArticulos.incluirLineaArticulo(producto, int.Parse(this.txtCantidad.Text), IdFactura);

            this.invocarSalvarFactura(sender, e);
            this.cargarLineaArticulos(IdFactura);
            Factura factura = this.facturas.obtenFacturaSegunIdentificador(IdFactura);
            this.txtTotal.Text = factura.Total.ToString();
        }

        protected void gvLineaArticulos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            { 
                this.lineaArticulos.eliminarLineaArticulo((int)e.Keys["Id"]);
                this.cargarLineaArticulos(int.Parse(e.Values["IdFactura"].ToString()));
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
            }
        }
    }
}