using ONTOUR_Conexion;
using Oracle.ManagedDataAccess.Client;
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
        ConexionOT c1 = new ConexionOT();

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
            lblTipoUsuario.Text = "Tipo de usuario: " + Session["tipoUsuario"] + ", " + (String)Session["rol"];

            //Retornar los depositos del apoderado
            try
            {
                c1.Conectar();
                c1.OraCmd = new OracleCommand("SELECT COUNT(*) FROM DEPOSITO WHERE CORREOFK = :correoFK", c1.OraConn);
                c1.OraCmd.Parameters.Add(new OracleParameter(":correoFK", Session["correo"]));
                c1.OraDR = c1.OraCmd.ExecuteReader();
                c1.OraDR.Read();
                int cantidadDepositos = c1.OraDR.GetInt32(0);

                if (cantidadDepositos == 0)
                {
                    lblCantidadDepositos.Text = "Sin depositos hasta la fecha";
                }
                else
                {
                    lblCantidadDepositos.Text = Convert.ToString(cantidadDepositos);
                }
                c1.CerrarConexion();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al retornar datos del deposito";
            }
        }
    }
}