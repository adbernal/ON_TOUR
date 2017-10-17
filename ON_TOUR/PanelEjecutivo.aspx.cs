using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ON_TOUR
{
    public partial class PanelEjecutivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((String)Session["rol"] != "Ejecutivo")
            {
                Response.Redirect("index.aspx");
            }

            //if((Int32)Session["tipoUsuario"] != 4)

            lblNombreUsuario.Text = "Bienvenid@, " + (String)Session["nombreUsuario"];
            lblTipoUsuario.Text = "Tipo de usuario: " + Session["tipoUsuario"] + ", " + (String)Session["rol"];
        }
    }
}