using ONTOUR_Conexion;
using ONTOUR_DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ON_TOUR
{
    public partial class LoginApoderado : System.Web.UI.Page
    {
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["correo"] != null)
            {
                Response.AddHeader("REFRESH", "5;URL=index.aspx");
                lblEstado.Text = "Sera redireccionado en 5 segundos...";
            }
            else
            {
            }
            */
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ConexionOT c1 = new ConexionOT();
            c1.Conectar();

            try
            { 
                // JOIN entre las tablas APODERADO, USUARIO y EJECUTIVO
                c1.OraCmd = new OracleCommand("SELECT NVL(A.NOMBRE, E.NOMBRE), U.CORREO, U.CLAVE, U.IDTIPOUSUARIOFK, A.IDAPODERADO " +
                                                "FROM USUARIO U " +
                                                "FULL OUTER JOIN APODERADO A ON U.CORREO = A.CORREOFK " +
                                                "FULL OUTER JOIN EJECUTIVO E ON E.CORREOFK = U.CORREO " +
                                                "WHERE U.CORREO = :correo AND U.CLAVE = :clave", c1.OraConn);
                c1.EsSelect = true;
                c1.OraCmd.Parameters.Add(new OracleParameter(":correo", txtCorreo.Text));
                c1.OraCmd.Parameters.Add(new OracleParameter(":clave", txtClave.Text));

                c1.OraDR = c1.OraCmd.ExecuteReader();
                c1.OraDR.Read();
                
                usuario.Nombre = c1.OraDR.GetString(0);
                usuario.Correo = c1.OraDR.GetString(1);
                usuario.IdTipoUsuario = c1.OraDR.GetInt32(3);
                usuario.IdApoderado = c1.OraDR.GetInt32(4);
                
                Session["nombreUsuario"] = usuario.Nombre;
                Session["correo"] = usuario.Correo;
                Session["tipoUsuario"] = usuario.IdTipoUsuario;
                Session["idApoderado"] = usuario.IdApoderado;
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Credenciales incorrectas. Inténtelo de nuevo.";
            }
                
            if (c1.OraDR.HasRows)
            {
                switch (usuario.IdTipoUsuario)
                {
                    case 1:
                        Session["rol"] = "Apoderado";
                        Response.Redirect("PanelApoderado.aspx");
                        break;
                    case 2:
                        Session["rol"] = "Representante";
                        Response.Redirect("PanelRepresentante.aspx");
                        break;
                    case 4:
                        Session["rol"] = "Ejecutivo";
                        Response.Redirect("PanelEjecutivo.aspx");
                        break;
                }
            }

            c1.CerrarConexion();
        }
    }
}