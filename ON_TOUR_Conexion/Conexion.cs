using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ON_TOUR_Conexion
{
    public class Conexion
    {
        private String nombreUsuarioBD;
        private String passUsuarioBD;
        private String cadenaConexion;
        private OracleCommand cadenaSQL;
        private bool esSelect;
        private OracleConnection dbConexion;
        private System.Data.DataSet dbDataSet;
        private OracleDataAdapter dbDataAdapter;

        public string NombreUsuarioBD
        {
            get
            {
                return nombreUsuarioBD;
            }

            set
            {
                nombreUsuarioBD = value;
            }
        }

        public string PassUsuarioBD
        {
            get
            {
                return passUsuarioBD;
            }
            set
            {
                passUsuarioBD = value;
            }
        }

        public string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }

            set
            {
                cadenaConexion = value;
            }
        }

        public OracleCommand CadenaSQL
        {
            get
            {
                return cadenaSQL;
            }

            set
            {
                cadenaSQL = value;
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

        public OracleConnection DbConnection
        {
            get
            {
                return dbConexion;
            }

            set
            {
                dbConexion = value;
            }
        }

        public System.Data.DataSet DbDataSet
        {
            get
            {
                return dbDataSet;
            }
            set
            {
                dbDataSet = value;
            }
        }

        public OracleDataAdapter DbDataAdapter
        {
            get
            {
                return dbDataAdapter;
            }

            set
            {
                dbDataAdapter = value;
            }
        }

        public void abrirConexion()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexion " + ex.Message, "mensaje Sistema");
            }
        }

        public void cerrarConexion()
        {
            try
            {
                this.DbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexion " + ex.Message, "mensaje Sistema");
            }
        }

        public void conectar()
        {
            if (this.NombreUsuarioBD.Length == 0)
            {
                MessageBox.Show("Falta nombre base de datos ", "mensaje Sistema");
                return;
            }

            if (this.PassUsuarioBD.Length == 0)
            {
                MessageBox.Show("Falta clave base de datos ", "mensaje Sistema");
                return;
            }

            if (this.CadenaConexion.Length == 0)
            {
                MessageBox.Show("Falta cadena C ", "mensajeonexion Sistema");
                return;
            }
            if (this.CadenaSQL == null)
            {
                MessageBox.Show("Falta cadena SQL ", "mensaje Sistema");
                return;
            }

            try
            {
                this.DbConnection = new OracleConnection(this.CadenaConexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexion " + ex.Message, "mensaje Sistema");
                return;
            }

            //SE abre la conexion
            this.abrirConexion();

            //Se instancia el DataAdapter

            if (this.EsSelect)
            {
                //SE instancia dataSet

                this.DbDataSet = new System.Data.DataSet();
                try
                {
                    this.DbDataAdapter = new OracleDataAdapter(Convert.ToString(this.CadenaSQL), this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDataSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos " + ex.Message, "mensaje Sistema");
                    return;

                }
            }
            else
            {
                try
                {
                    OracleCommand variableSQL = new OracleCommand(Convert.ToString(this.CadenaSQL), this.DbConnection);
                    variableSQL.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en SQL " + ex.Message, "mensaje Sistema");
                    return;

                }
            }

            this.cerrarConexion();
        }   
    }
}
