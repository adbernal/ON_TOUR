using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON_TOUR_DTO
{
    public class Deposito
    {
        private int idDeposito;
        private int monto;
        private string fecha;
        private string comentario;
        private string correoFK;
        private byte[] captura;

        public int IdDeposito
        {
            get
            {
                return idDeposito;
            }

            set
            {
                idDeposito = value;
            }
        }

        public int Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public string Fecha
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

        public string CorreoFK
        {
            get
            {
                return correoFK;
            }

            set
            {
                correoFK = value;
            }
        }

        public byte[] Captura
        {
            get
            {
                return captura;
            }

            set
            {
                captura = value;
            }
        }
    }
}
