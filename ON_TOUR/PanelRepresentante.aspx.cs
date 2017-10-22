using ONTOUR_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ON_TOUR
{
    public partial class PanelRepresentante : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();

        public void DTOSession()
        {
            usuario.Rol = (String)Session["rol"];
            usuario.Nombre = (String)Session["nombreUsuario"];
            usuario.IdTipoUsuario = (int)Session["tipoUsuario"];
            usuario.IdApoderado = (int)Session["idApoderado"];
            usuario.Correo = (String)Session["correo"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTOSession();

            lblNombreUsuario.Text = "Bienvenid@, " + usuario.Nombre;
            lblTipoUsuario.Text = "Tipo de usuario: " + usuario.IdTipoUsuario + ", " + usuario.Rol;
        }

        
    }
}