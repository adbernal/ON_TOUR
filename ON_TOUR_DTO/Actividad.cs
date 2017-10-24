using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON_TOUR_DTO
{
    public class Actividad
    {
        private int idActividad;
        private string descripcion;
        private int montoRecaudado;
        private DateTime fecha;
        private int idCursoFK;

        public int IdActividad
        {
            get
            {
                return idActividad;
            }

            set
            {
                idActividad = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int MontoRecaudado
        {
            get
            {
                return montoRecaudado;
            }

            set
            {
                montoRecaudado = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int IdCursoFK
        {
            get
            {
                return idCursoFK;
            }

            set
            {
                idCursoFK = value;
            }
        }
    }
}
