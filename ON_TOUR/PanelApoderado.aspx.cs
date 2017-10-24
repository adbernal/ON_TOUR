using ON_TOUR_DTO;
using ONTOUR_Conexion;
using ONTOUR_DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ON_TOUR
{
    public partial class PanelApoderado : System.Web.UI.Page
    {
        ConexionOT c1 = new ConexionOT();
        ConexionOT c1a = new ConexionOT();
        ConexionOT c2 = new ConexionOT();
        ConexionOT c3 = new ConexionOT();
        Usuario usuario = new Usuario();
        Deposito deposito = new Deposito();
        Contrato contrato = new Contrato();

        public void DTOSession()
        {
            usuario.Rol = (String)Session["rol"];
            usuario.Nombre = (String)Session["nombreUsuario"];
            usuario.IdTipoUsuario = (int)Session["tipoUsuario"];
            usuario.IdApoderado = (int)Session["idApoderado"];
            usuario.Correo = (String)Session["correo"];
            usuario.IdCurso = (int)Session["idCurso"];
            contrato.IsActivo = Convert.ToBoolean(Session["isActivo"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DTOSession();

            /*
            c1a.Conectar();
            c1a.OraCmd = new OracleCommand("SELECT ISACTIVO FROM CONTRATO WHERE IDCURSOFK = :idCursoFK", c1a.OraConn);
            c1a.OraCmd.Parameters.Add(new OracleParameter(":idCursoFK", usuario.IdCurso));
            c1a.OraDR = c1a.OraCmd.ExecuteReader();
            c1a.OraDR.Read();
            contrato.IsActivo = Convert.ToBoolean(c1a.OraDR.GetInt32(0));
            c1a.CerrarConexion();
            //contrato.IsActivo = Convert.ToBoolean(c1a.OraDR.GetInt32(0)); En caso de mantener el valor numerico y no pasarlo a boolean
            //if(contrato.EstaActivo.Equals(1))
            */

            if (contrato.IsActivo)
            {
                if (usuario.Rol != "Apoderado")
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblNombreUsuario.Text = "Bienvenid@, " + usuario.Nombre;
                    lblTipoUsuario.Text = "Tipo de usuario: " + usuario.IdTipoUsuario + ", " + usuario.Rol; //+ ", Su id de apoderado: " + (String)Session["idApoderado"];
                    lblIdApoderado.Text = usuario.Correo + ", " + Convert.ToString(usuario.IdApoderado);
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            //Retornar los depositos del apoderado
            try
            {
                c1.Conectar();
                c1.OraCmd = new OracleCommand("SELECT COUNT(*) FROM DEPOSITO WHERE CORREOFK = :correoFK", c1.OraConn);
                c1.OraCmd.Parameters.Add(new OracleParameter(":correoFK", usuario.Correo));
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
                lblMensaje.Text = "Error al retornar datos del deposito.";
            }

            //Gridview con los depositos del apoderado
            try
            {
                c2.Conectar();
                c2.OraCmd = new OracleCommand("SELECT IDDEPOSITO AS CODIGO, CONCAT('$',MONTO) AS MONTO, TO_CHAR(FECHA, 'dd/mm/yy') AS FECHA, COMENTARIO FROM DEPOSITO WHERE CORREOFK = :correoFK", c2.OraConn);
                c2.OraCmd.Parameters.Add(new OracleParameter(":correoFK", usuario.Correo));
                c2.OraDR = c2.OraCmd.ExecuteReader();

                using (c2.OraDR)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(c2.OraDR);
                    gvDepositos.DataSource = dataTable;
                    gvDepositos.DataBind();
                }
                c2.CerrarConexion();
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Error al retornar depositos del apoderado.";
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["correo"] = null;
            Session["nombreUsuario"] = null;
            Session["idApoderado"] = null;
            Session["tipoUsuario"] = null;
            Session["rol"] = null;
            Response.Redirect("index.aspx");
        }

        /*public bool esValido()
        {
            HttpPostedFile postedFile = fupComprobante.PostedFile;
            string extension = Path.GetExtension(postedFile.FileName);

            bool isValidFile = false;

            string[] validFileTypes = { "jpg", "JPG", "png", "PNG", "jpeg", "JPEG" };
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (extension == validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            return isValidFile;
        }*/

        protected void btnNotificarDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                if (fupComprobante.HasFile)
                {
                    HttpPostedFile postedFile = fupComprobante.PostedFile;
                    string fileExtension = Path.GetExtension(postedFile.FileName);
                    string fileName = usuario.IdApoderado + $@"{DateTime.Now.Ticks}" + fileExtension;
                    int fileSize = postedFile.ContentLength;

                    if (fileExtension == ".jpg")
                    {
                        if (fileSize <= 3000000)
                        {
                            fupComprobante.SaveAs(Server.MapPath("~/depositos/") + fileName);

                            deposito.Monto = Convert.ToInt32(txtMontoDeposito.Text);
                            deposito.Fecha = DateTime.Now.ToString("dd/MM/yy");
                            deposito.Comentario = txtComentarioDeposito.Text;

                            c3.Conectar();
                            c3.OraCmd = new OracleCommand("INSERT INTO DEPOSITO (MONTO,FECHA,COMENTARIO,NOMBREIMAGEN,CORREOFK) VALUES " +
                                                            "(:monto, :fecha, :comentario, :nombreImagen, :correoFK)", c3.OraConn);
                            c3.OraCmd.Parameters.Add(":monto", deposito.Monto);
                            c3.OraCmd.Parameters.Add(":fecha", deposito.Fecha);
                            c3.OraCmd.Parameters.Add(":comentario", deposito.Comentario);
                            c3.OraCmd.Parameters.Add(":nombreImagen", fileName);
                            c3.OraCmd.Parameters.Add(":correoFK", usuario.Correo);

                            c3.OraCmd.ExecuteNonQuery();
                            c3.CerrarConexion();

                            lblMensaje.Text = "Se ha enviado su notificacion de deposito";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "El tamaño de la imagen no debe superar los 3 MB.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Solo se permiten formatos de imagen .jpg";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe cargar una imagen del comprobante antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se pudo notificar el deposito";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }  
        }
    }
}