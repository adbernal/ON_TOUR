using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON_TOUR_DTO
{
    public class Colegio
    {
        private int idColegio;
        private string nombreColegio;
        private string direccion;
        private string correo;
        private string telefono;

        public Colegio()
        {

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

        public string NombreColegio
        {
            get
            {
                return nombreColegio;
            }

            set
            {
                nombreColegio = value;
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
    }
}
