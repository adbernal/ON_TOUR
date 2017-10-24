using ON_TOUR_DTO;
using ONTOUR_Conexion;
using ONTOUR_DTO;
using Oracle.ManagedDataAccess.Client;
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
        ConexionOT c1 = new ConexionOT();
        Usuario usuario = new Usuario();
        Actividad actividad = new Actividad();

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

            if(usuario.Rol != "Representante")
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                lblNombreUsuario.Text = "Bienvenid@, " + usuario.Nombre;
                lblTipoUsuario.Text = "Tipo de usuario: " + usuario.IdTipoUsuario + ", " + usuario.Rol + ", Su curso es: " + Session["idCurso"];
            }            
        }

        public void CrearObjActividad()
        {
            actividad.IdActividad = 0;
            actividad.Descripcion = txtDescripcion.Text;
            actividad.MontoRecaudado = Convert.ToInt32(txtMontoRecaudado.Text);
            actividad.Fecha = cFechaActividad.SelectedDate;
            actividad.IdCursoFK = (int)Session["idCurso"];
        }

        protected void btnCrearActividad_Click(object sender, EventArgs e)
        {
            try
            {
                CrearObjActividad();

                c1.Conectar();
                c1.OraCmd = new OracleCommand("INSERT INTO ACTIVIDAD (DESCRIPCION,MONTORECAUDADO,FECHA,IDCURSOFK) " +
                                                "VALUES (:descripcion,:montoRecaudado,TO_CHAR(:fecha,'dd/mm/yy'),:idCursoFK)", c1.OraConn);
                c1.OraCmd.Parameters.Add(new OracleParameter(":descripcion", actividad.Descripcion));
                c1.OraCmd.Parameters.Add(new OracleParameter(":montoRecaudado", actividad.MontoRecaudado));
                c1.OraCmd.Parameters.Add(new OracleParameter(":fecha", actividad.Fecha));
                c1.OraCmd.Parameters.Add(new OracleParameter(":idCursoFK", actividad.IdCursoFK));
                c1.OraCmd.ExecuteNonQuery();
                c1.CerrarConexion();

                lblMensaje.Text = "Se ha creado la actividad correctamente";
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al registrar la actividad" + ex;
            }
        }
    }
}