using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON_TOUR_DTO
{
    public class Contrato
    {
        private int idContrato;
        private DateTime fecha;
        private string comentario;
        private bool isActivo;
        private int idCursoFK;
        private int idEjecutivoFK;
        private int idPaqueteTuristicoFK;
        // prueba
        private int estaActivo;

        public int IdContrato
        {
            get
            {
                return idContrato;
            }

            set
            {
                idContrato = value;
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

        public string Comentario
        {
            get
            {
                return comentario;
            }

            set
            {
                comentario = value;
            }
        }

        public bool IsActivo
        {
            get
            {
                return isActivo;
            }

            set
            {
                isActivo = value;
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

        public int IdEjecutivoFK
        {
            get
            {
                return idEjecutivoFK;
            }

            set
            {
                idEjecutivoFK = value;
            }
        }

        public int IdPaqueteTuristicoFK
        {
            get
            {
                return idPaqueteTuristicoFK;
            }

            set
            {
                idPaqueteTuristicoFK = value;
            }
        }

        public int EstaActivo
        {
            get
            {
                return estaActivo;
            }

            set
            {
                estaActivo = value;
            }
        }
    }
}
