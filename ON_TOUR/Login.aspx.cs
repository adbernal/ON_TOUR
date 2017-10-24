using ON_TOUR_DTO;
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
        ConexionOT c1 = new ConexionOT();
        ConexionOT c1a = new ConexionOT();
        Usuario usuario = new Usuario();
        Contrato contrato = new Contrato();

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
            try
            {
                c1.Conectar(); // JOIN entre las tablas APODERADO, USUARIO y EJECUTIVO
                c1.OraCmd = new OracleCommand("SELECT NVL(A.NOMBRE, E.NOMBRE), U.CORREO, U.CLAVE, U.IDTIPOUSUARIOFK, A.IDAPODERADO, A.IDCURSOFK " +
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
                usuario.IdCurso = c1.OraDR.GetInt32(5);
                
                Session["nombreUsuario"] = usuario.Nombre;
                Session["correo"] = usuario.Correo;
                Session["tipoUsuario"] = usuario.IdTipoUsuario;
                Session["idApoderado"] = usuario.IdApoderado;
                Session["idCurso"] = usuario.IdCurso;

                try
                {
                    c1a.Conectar();
                    c1a.OraCmd = new OracleCommand("SELECT ISACTIVO FROM CONTRATO WHERE IDCURSOFK = :idCursoFK", c1a.OraConn);
                    c1a.OraCmd.Parameters.Add(new OracleParameter(":idCursoFK", usuario.IdCurso));
                    c1a.OraDR = c1a.OraCmd.ExecuteReader();
                    c1a.OraDR.Read();

                    contrato.IsActivo = Convert.ToBoolean(c1a.OraDR.GetInt32(0));
                    Session["isActivo"] = contrato.IsActivo;
                    //contrato.IsActivo = Convert.ToBoolean(c1a.OraDR.GetInt32(0)); En caso de mantener el valor numerico y no pasarlo a boolean
                    //if(contrato.EstaActivo.Equals(1))
                    c1a.CerrarConexion();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error. No se pudo retornar la información de su contrato.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Credenciales incorrectas. Inténtelo de nuevo.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            if (c1.OraDR.HasRows)
            {
                if(contrato.IsActivo == true)
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
                else
                {
                    lblMensaje.Text = "Su contrato no se encuentra activo. Contáctese con uno de nuestros ejecutivos.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Ud no se encuentra registrado. Registrese para empezar a usar ONTOUR";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            c1.CerrarConexion();
        }
    }
}