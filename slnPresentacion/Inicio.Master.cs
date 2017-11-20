using slnPresentacion;
using System;

namespace WebFacturas
{
    public partial class Inicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Session["sesion"] != null)
            {
                new ControlSesiones(Page).crearAlerta("Sesion ya esta iniciada.");
                Response.Redirect("~/Dashboard.aspx");
            }
        }
    }
}