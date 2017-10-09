using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONTOUR_Conexion
{
    public class ConexionOT
    {
        private OracleConnection oraconn;
        private static string oracs;
        private OracleCommand oracmd;
        private DataSet orads;
        private OracleDataAdapter orada;
        private OracleDataReader oradr;

        private bool esSelect;

        public ConexionOT()
        {
            oracs = "DATA SOURCE=localhost:1522/xe;USER ID=ONTOUR;PASSWORD=ontour";
            oraconn = new OracleConnection(oracs);
            oracmd = new OracleCommand();
            orads = new DataSet();
            orada = new OracleDataAdapter();
            //oradr = new OracleDataReader();
        }

        public OracleConnection OraConn
        {
            get
            {
                return oraconn;
            }

            set
            {
                oraconn = value;
            }
        }

        public string OraCS
        {
            get
            {
                return oracs;
            }

            set
            {
                oracs = value;
            }
        }

        public OracleCommand OraCmd
        {
            get
            {
                return oracmd;
            }

            set
            {
                oracmd = value;
            }
        }

        public DataSet OraDS
        {
           get
           {
               return orads;
           }

           set
           {
               orads = value;
           }
        }

        public OracleDataAdapter OraDA
        {
           get
           {
               return orada;
           }

           set
           {
               orada = value;
           }
        }

        public OracleDataReader OraDR
        {
            get
            {
                return oradr;
            }

            set
            {
                oradr = value;
            }
        }

        public bool EsSelect
        {
            get
            {
                return esSelect;
            }

            set
            {
                esSelect = value;
            }
        }

        public void AbrirConexion()
        {
            try
            {
                this.OraConn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al abrir la conexion" + ex.Message, "Mensaje del sistema");
                return;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                this.OraConn.Close();
                this.OraConn.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexion" + ex.Message, "Mensaje del sistema");
                return;
            }
        }

        public void Conectar()
        {
            if (this.OraCS.Length == 0)
            {
                MessageBox.Show("Falta la cadena de conexion", "Mensaje del Sistema");
                return;
            }
            if (this.OraCmd == null)
            {
                MessageBox.Show("No se ha proporcionado una sentencia SQL a ejecutar", "Mensaje del Sistema");
                return;
            }

            try
            {
                this.OraConn = new OracleConnection(this.OraCS);
                AbrirConexion();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error de conexion" + ex.Message, "Mensaje del sistema");
                return;
            }
            

            /*
            if (this.EsSelect)
            {
                this.OraDS = new DataSet();
                try
                {
                    this.OraDA = new OracleDataAdapter(Convert.ToString(this.OraCmd), this.OraConn);
                    this.OraDA.Fill(this.OraDS);
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos " + ex.Message, "mensaje Sistema");
                    return;
                }
            }
            if (this.EsSelect == false)
            {
                try
                {
                    OracleCommand variableSQL = new OracleCommand(Convert.ToString(this.OraCmd), this.OraConn);
                    variableSQL.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error en SQL " + ex.Message, "Mensaje Sistemaxxx");
                    return;
                }
            }
            */
        }
    }
}
