using ONTOUR_Conexion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONTOUR_Negocio
{
    public class ApoderadoNegocio
    {
        private ConexionOT c;

        public ConexionOT C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        public void configurarConexion()
        {
            this.c = new ConexionOT();
        }
        /*
        public DataSet seleccionarCuentaUsuario(Usuario usuario)
        {
            this.configurarConexion();
            this.C.OraCmd = new OracleCommand();


            this.C.CadenaSQL = new OracleCommand("SELECT correo, clave FROM Usuario WHERE correo = '" +usuario.Correo+ "' AND clave = " +usuario.Clave+"'");
            this.C.EsSelect = true;
            this.C.conectar();

            return this.C.DbDataSet;
        }

        public bool LoginApoderado()
        {
            bool loginExitoso;

            OracleDataAdapter oda = new OracleDataAdapter();
            oda.Fill(this.C.DbDataSet, "Usuario");
            if (this.C.DbDataSet.Tables[0].Rows.Count > 0)
            {
                return loginExitoso = true;
            }
            else
            {
                return loginExitoso = false;
            }
        }
        */
    }
}
