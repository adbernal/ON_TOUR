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
                Response.Redirect("index.aspx");
            }
            else
            {

            }*/
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ConexionOT c1 = new ConexionOT();
            c1.Conectar();

            try
            {
                c1.OraCmd = new OracleCommand("SELECT A.RUT, A.NOMBRE, A.APELLIDOP, A.APELLIDOM, A.IDCURSOFK, A.IDCOLEGIOFK, U.CORREO, U.CLAVE, IDTIPOUSUARIOFK " +
                                                "FROM USUARIO U JOIN APODERADO A ON U.CORREO = A.CORREOFK " +
                                                "WHERE U.CORREO = :correo AND U.CLAVE = :clave", c1.OraConn);
                c1.EsSelect = true;
                c1.OraCmd.Parameters.Add(new OracleParameter(":correo", txtCorreo.Text));
                c1.OraCmd.Parameters.Add(new OracleParameter(":clave", txtClave.Text));

                //c1.OraDA.SelectCommand = c1.OraCmd;
                c1.OraDR = c1.OraCmd.ExecuteReader();
                c1.OraDR.Read();
               
                usuario.Correo = c1.OraDR.GetString(6);
                usuario.Nombre = c1.OraDR.GetString(1);
                usuario.IdTipoUsuario = c1.OraDR.GetInt32(8);
                Session["correo"] = usuario.Correo;
                Session["nombreUsuario"] = usuario.Nombre + " " + usuario.ApellidoP + " " + usuario.ApellidoM;
                Session["tipoUsuario"] = usuario.IdTipoUsuario;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ("Error. Usuario o contraseña incorrecto(s).");
            }

            if (c1.OraDR.HasRows)
            {
                //lblMensaje.Text = "Bienvenid@, " + Session["nombreUsuario"];
                switch (usuario.IdTipoUsuario)
                {
                    case 1:
                        Response.Redirect("PanelApoderado.aspx");
                        break;
                    case 2:
                        Response.Redirect("PanelRepresentante.aspx");
                        break;
                    case 4:
                        Response.Redirect("PanelEjecutivo.aspx");
                        break;
                }
            }

            /*
            OracleCommand cmd2 = new OracleCommand("SELECT nombre FROM apoderado WHERE correoFK = :correo2", conexionOT.Oraconn);
            cmd2.Parameters.Add(new OracleParameter(":correo2", txtCorreo.Text));
            c.Oraconn.Open(); //Importante para que la conexion funcione
            cmd2.CommandType = CommandType.Text;
            OracleDataReader dr = cmd2.ExecuteReader();
            dr.Read();
            lblTexto.Text = dr.GetString(0);
            */

            /*
            string cs = "DATA SOURCE=DESKTOP-LTBT320:1522/xe;USER ID=ONTOUR;PASSWORD=ontour";
            OracleConnection conn = new OracleConnection(cs);

            conn.Open();
            
            DataSet ds = new DataSet();

            OracleCommand cmd = new OracleCommand("SELECT correo, clave FROM usuario WHERE correo = :correo AND clave = :clave", conexionOT.Oraconn);

            OracleCommand cmd2 = new OracleCommand("SELECT nombre, apellidop, apellidom FROM apoderado WHERE correo = :correo");

            OracleDataAdapter oda = new OracleDataAdapter();

            cmd.Parameters.Add(new OracleParameter(":correo", txtCorreo.Text));
            cmd.Parameters.Add(new OracleParameter(":clave", txtClave.Text));

            Usuario usuario = new Usuario();
            usuario.Correo = txtCorreo.Text;
            Session["correo"] = usuario.Correo;

            oda.SelectCommand = cmd;
            oda.Fill(ds, "usuario");
            if(ds.Tables[0].Rows.Count > 0)
            {
                lblMensaje.Text = "Bienvenido " + Session["correo"];
            }
            else
            {
                lblMensaje.Text = "Rip";
            }

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            
            Conexion conn = new Conexion();

            Usuario usuario = new Usuario();
            usuario.Correo = txtCorreo.Text;
            usuario.Clave = txtClave.Text;

            ApoderadoNegocio apoderadoNegocio = new ApoderadoNegocio();

            apoderadoNegocio.configurarConexion();
            apoderadoNegocio.seleccionarCuentaUsuario(usuario);

            apoderadoNegocio.LoginApoderado();
            if(apoderadoNegocio.LoginApoderado())
            {
                lblMensaje.Text = "Login exitoso";
            }
            else
            {
                lblMensaje.Text = "Nope";
            }
            */

            c1.CerrarConexion();
        }
    }
}