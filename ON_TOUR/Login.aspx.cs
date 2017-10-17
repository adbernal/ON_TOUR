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
                // 1. JOIN ENTRE TABLAS USUARIO Y APODERADO
                /*
                c1.OraCmd = new OracleCommand("SELECT A.RUT, A.NOMBRE, A.APELLIDOP, A.APELLIDOM, A.IDCURSOFK, A.IDCOLEGIOFK, U.CORREO, U.CLAVE, U.IDTIPOUSUARIOFK " +
                                                "FROM USUARIO U JOIN APODERADO A ON U.CORREO = A.CORREOFK " +
                                                "WHERE U.CORREO = :correo AND U.CLAVE = :clave", c1.OraConn);
                */
                
                // 2. JOIN ENTRE TABLAS USUARIO, APODERADO, EJECUTIVO
                c1.OraCmd = new OracleCommand("SELECT NVL(A.NOMBRE, E.NOMBRE), U.CORREO, U.CLAVE, U.IDTIPOUSUARIOFK " +
                                                "FROM USUARIO U " +
                                                "FULL OUTER JOIN APODERADO A ON U.CORREO = A.CORREOFK " +
                                                "FULL OUTER JOIN EJECUTIVO E ON E.CORREOFK = U.CORREO " +
                                                "WHERE U.CORREO = :correo AND U.CLAVE = :clave", c1.OraConn);
                c1.EsSelect = true;
                c1.OraCmd.Parameters.Add(new OracleParameter(":correo", txtCorreo.Text));
                c1.OraCmd.Parameters.Add(new OracleParameter(":clave", txtClave.Text));

                //c1.OraDA.SelectCommand = c1.OraCmd;
                c1.OraDR = c1.OraCmd.ExecuteReader();
                c1.OraDR.Read();

                // INDICES CORRESPONDIENTES AL JOIN 1
                //usuario.Correo = c1.OraDR.GetString(6);
                //usuario.Nombre = c1.OraDR.GetString(1);
                //usuario.IdTipoUsuario = c1.OraDR.GetInt32(8);
                
                usuario.Correo = c1.OraDR.GetString(1);
                usuario.Nombre = c1.OraDR.GetString(0);
                usuario.IdTipoUsuario = c1.OraDR.GetInt32(3);
                Session["correo"] = usuario.Correo;
                Session["nombreUsuario"] = usuario.Nombre + " " + usuario.ApellidoP + " " + usuario.ApellidoM;
                Session["tipoUsuario"] = usuario.IdTipoUsuario;
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Credenciales incorrectas. Inténtelo de nuevo.";
            }
                
            if (c1.OraDR.HasRows)
            {
                //lblMensaje.Text = "Bienvenid@, " + Session["nombreUsuario"];
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