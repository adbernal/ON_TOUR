using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON_TOUR_DTO
{
    public class Curso
    {
        private int idCurso;
        private string gradoCurso;
        private char letraCurso;
        private int cantidadAlumnos;
        private int idColegioFK;

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

        public string GradoCurso
        {
            get
            {
                return gradoCurso;
            }

            set
            {
                gradoCurso = value;
            }
        }

        public char LetraCurso
        {
            get
            {
                return letraCurso;
            }

            set
            {
                letraCurso = value;
            }
        }

        public int CantidadAlumnos
        {
            get
            {
                return cantidadAlumnos;
            }

            set
            {
                cantidadAlumnos = value;
            }
        }

        public int IdColegioFK
        {
            get
            {
                return idColegioFK;
            }

            set
            {
                idColegioFK = value;
            }
        }

        public string NombreCurso(string grado, string letra)
        {
            string nombreCurso = GradoCurso + " " + LetraCurso;
            return nombreCurso; 
        }

    }
}
