﻿using System;
using slnLogica;
using slnDatos;

namespace slnPresentacion
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        private IserviciosClientes clientes = new AccionesClientes();

        private void cargarClientePorUrl()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Identificador = int.Parse(Request.QueryString["Id"]);
                Cliente cliente = this.clientes.obtenClienteSegunIdentificador(Identificador);
                this.txtCedula.Text = cliente.Cedula;
                this.txtNombre.Text = cliente.NombreCompleto;
                this.hdnIdentificador.Value = Identificador.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarClientePorUrl();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string Identificador = this.hdnIdentificador.Value;
                if (String.IsNullOrEmpty(Identificador))
                {
                    this.clientes.incluirCliente(this.txtCedula.Text, this.txtNombre.Text);
                }
                else
                {
                    this.clientes.actualizaCliente(int.Parse(Identificador), this.txtCedula.Text, this.txtNombre.Text);
                }
                new ControlSesiones(Page).crearAviso("Cliente salvado.");
                Response.Redirect("~/Clientes.aspx");
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.GetBaseException().Message;
            }
        }
    }
}