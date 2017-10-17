using System;
using ONTOUR_Conexion;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using ON_TOUR_DTO;
using ONTOUR_DTO;

namespace ON_TOUR
{
    public partial class SignUp : System.Web.UI.Page
    {
        ConexionOT c1 = new ConexionOT();
        ConexionOT c2 = new ConexionOT();
        ConexionOT c3 = new ConexionOT();
        ConexionOT c3a = new ConexionOT();
        ConexionOT c4 = new ConexionOT();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipoUsuario"] != null)
            {
                lblMensaje.Text = "Ud. ya ha iniciado sesion. Si desea registrarse con otra cuenta. Cierre su sesion e intentelo nuevamente";
                Response.AddHeader("REFRESH", "10;URL=index.aspx");
                lblEstado.Text = "Sera redireccionado en 10 segundos...";
            }

            lblMensaje.Text = string.Empty;

            if (!IsPostBack)
            {
                try
                {
                    c1.Conectar();
                    c1.OraCmd = new OracleCommand("SELECT IDCOLEGIO, NOMBRECOLEGIO FROM COLEGIO", c1.OraConn);
                    using (c1.OraCmd)
                    {
                        c1.OraCmd.CommandType = CommandType.Text;
                        ddlColegio.DataSource = c1.OraCmd.ExecuteReader();
                        ddlColegio.DataTextField = "NOMBRECOLEGIO";
                        ddlColegio.DataValueField = "IDCOLEGIO"; //Setear esta variable como "NOMBRECOLEGIO" si se desea obtener el nombre de colegio como value de este ddl. Ej. ddlColegio.SelectedValue
                        ddlColegio.DataBind();
                        c1.CerrarConexion();
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al retornar datos de colegio. " + ex.Message;
                }
            }  
        }


        protected void ddlColegio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            try
            {
                c2.Conectar();
                //En caso de que se quiera seleccionar el colegio segun su nombre
                /*
                c2.OraCmd = new OracleCommand("SELECT CU.IDCURSO, CONCAT(CONCAT(CU.GRADOCURSO, ' '), CU.LETRACURSO) AS NOMBRECURSO, CU.IDCOLEGIOFK, CO.NOMBRECOLEGIO " +
                                                "FROM CURSO CU JOIN COLEGIO CO ON CU.IDCOLEGIOFK = CO.IDCOLEGIO " +
                                                "WHERE CO.NOMBRECOLEGIO = :nombreColegio", c2.OraConn);

                c2.OraCmd.Parameters.Add(new OracleParameter(":nombreColegio", ddlColegio.SelectedValue));
                */
                c2.OraCmd = new OracleCommand("SELECT IDCURSO, CONCAT(CONCAT(GRADOCURSO, ' '),LETRACURSO) AS NOMBRECURSO, IDCOLEGIOFK FROM CURSO " +
                                                "WHERE IDCOLEGIOFK = :idColegioFK", c2.OraConn);
                c2.OraCmd.Parameters.Add(new OracleParameter("idColegioFK", ddlColegio.SelectedValue));

                using (c2.OraCmd)
                {
                    c2.OraCmd.CommandType = CommandType.Text;
                    ddlCurso.DataSource = c2.OraCmd.ExecuteReader();
                    ddlCurso.DataTextField = "NOMBRECURSO";
                    ddlCurso.DataValueField = "IDCURSO";
                    ddlCurso.DataBind();
                    c2.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al retornar datos de curso. " + ex.Message;
            }
        }

        public string FormulaCorreo()
        {
            usuario.Nombre = txtNombre.Text;
            usuario.ApellidoP = txtApellidoP.Text;
            usuario.ApellidoM = txtApellidoM.Text;
            //correo = Trim(usuario.Nombre) averiguar la formula de acortar string
            string correo = usuario.Nombre.Substring(0, 2) + usuario.ApellidoM.Substring(0, 1) +
                        usuario.ApellidoP.Substring(0, 1) + ddlColegio.SelectedValue + ddlCurso.SelectedValue + "@ontour.cl";
            return correo.ToLower();
        }
        
        public int GenerarClavePin()
        {
            int min = 1000;
            int max = 9000;
            Random random = new Random();
            return random.Next(min, max);
        }

        public void CrearUsuario()
        {
            usuario.Correo = txtCorreo.Text;
            usuario.Rut = txtRut.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.ApellidoP = txtApellidoP.Text;
            usuario.ApellidoM = txtApellidoM.Text;
            usuario.Direccion = txtDireccion.Text;
            usuario.Telefono = txtTelefono.Text;
            usuario.Sexo = rbtM.Checked ? 'M' : 'F';
            usuario.FechaNacimiento = cFechaNacimiento.SelectedDate;
            //
            usuario.IdCurso = int.Parse(ddlCurso.SelectedValue);
            usuario.IdColegio = int.Parse(ddlColegio.SelectedValue);
            //usuario.Correo = FormulaCorreo(); //Activar solo en caso de que se necesite generar correo
            usuario.Clave = Convert.ToString(GenerarClavePin()); //Si la clave sera ingresada manualmente, crear un txtClave.Text
            usuario.IdTipoUsuario = 1;
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            CrearUsuario();
            try
            {
                //Verificar que correo no exista en la tabla usuario
                c3a.Conectar();
                c3a.OraCmd = new OracleCommand("SELECT * FROM USUARIO WHERE CORREO = :correo", c3a.OraConn);
                c3a.OraCmd.Parameters.Add(new OracleParameter(":correo", usuario.Correo));

                c3a.OraDR = c3a.OraCmd.ExecuteReader();
                c3a.OraDR.Read();

                if (c3a.OraDR.HasRows)
                {
                    lblMensaje.Text = "Este correo ya esta registrado. Será redirigido a inicio de sesión en 5 segundos";
                    Response.AddHeader("REFRESH", "5;URL=Login.aspx");
                }
                else
                {
                    //Insert en tabla usuario
                    c3.Conectar();
                    c3.OraCmd = new OracleCommand("INSERT INTO USUARIO (CORREO,CLAVE,IDTIPOUSUARIOFK) " +
                                                    "VALUES (:correo, :clave, :idTipoUsuarioFK)", c3.OraConn);
                    c3.OraCmd.Parameters.Add(new OracleParameter(":correo", usuario.Correo));
                    c3.OraCmd.Parameters.Add(new OracleParameter(":clave", usuario.Clave));
                    c3.OraCmd.Parameters.Add(new OracleParameter(":idTipoUsuarioFK", usuario.IdTipoUsuario));
                    c3.OraCmd.ExecuteNonQuery();
                    c3.CerrarConexion();

                    //Insert en tabla apoderado
                    c4.Conectar();
                    c4.OraCmd = new OracleCommand("INSERT INTO APODERADO (RUT,NOMBRE,APELLIDOP,APELLIDOM," +
                                                    "DIRECCION,TELEFONO,SEXO,FECHANACIMIENTO,IDCOLEGIOFK,IDCURSOFK,CORREOFK) " +
                                                    "VALUES (:rut, :nombre, :apellidoP, :apellidoM, :direccion, :telefono, " +
                                                    ":sexo, TO_CHAR(:fechaNacimiento,'dd/mm/yy'), :idColegioFK, :idCursoFK, :correoFK)", c4.OraConn);
                    c4.OraCmd.Parameters.Add(new OracleParameter(":rut", usuario.Rut));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":nombre", usuario.Nombre));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":apellidoP", usuario.ApellidoP));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":apellidoM", usuario.ApellidoM));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":direccion", usuario.Direccion));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":telefono", usuario.Telefono));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":sexo", usuario.Sexo));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":fechaNacimiento", usuario.FechaNacimiento));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":idColegioFK", usuario.IdColegio));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":idCursoFK", usuario.IdCurso));
                    c4.OraCmd.Parameters.Add(new OracleParameter(":correoFK", usuario.Correo));
                    c4.OraCmd.ExecuteNonQuery();
                    c4.CerrarConexion();

                    lblMensaje.Text = "Se ha registrado correctamente.";
                }
                c3a.CerrarConexion();
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al registrar apoderado. " + ex.Message;
            }
        }

        protected void btnProbar_Click(object sender, EventArgs e)
        {
            CrearUsuario();
            lblEstado.Text = "Sus datos son: " 
                + usuario.Correo + " " 
                + usuario.Clave + " "
                + usuario.Sexo + " "
                + usuario.FechaNacimiento;
        }
    }
}