using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ON_TOUR
{
    public partial class PanelApoderado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["correo"] != null)
            {
                Response.Redirect("index.aspx");
            }
            else {  }
            */
            lblNombreUsuario.Text = "Bienvenid@, " + (String)Session["nombreUsuario"];
            lblTipoUsuario.Text = "Tipo de usuario: " + Session["tipoUsuario"];
        }

       
    }
}