using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONTOUR_DTO
{
    public class Usuario
    {
        //Tabla apoderado
        private int idApoderado;
        private string rut;
        private string nombre;
        private string apellidoP;
        private string apellidoM;
        private string direccion;
        private string telefono;
        private char sexo;
        private DateTime fechaNacimiento;
        private int idCurso;
        private int idColegio;
        //Tabla usuario
        private string correo;
        private string clave;
        private int idTipoUsuario;
        //Otros
        private string rol;

        public int IdApoderado
        {
            get
            {
                return idApoderado;
            }

            set
            {
                idApoderado = value;
            }
        }

        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string ApellidoP
        {
            get
            {
                return apellidoP;
            }

            set
            {
                apellidoP = value;
            }
        }

        public string ApellidoM
        {
            get
            {
                return apellidoM;
            }

            set
            {
                apellidoM = value;
            }
        }

        public int IdCurso
        {
            get
            {
                return idCurso;
            }

            set
            {
                idCurso = value;
            }
        }

        public int IdColegio
        {
            get
            {
                return idColegio;
            }

            set
            {
                idColegio = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

        public int IdTipoUsuario
        {
            get
            {
                return idTipoUsuario;
            }

            set
            {
                idTipoUsuario = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public char Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }
    }
}
