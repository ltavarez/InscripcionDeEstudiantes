using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class Inscripcion
    {
        public string NombreEstudiante { get; set; }
        public List<string> _materias { get; set; }

        public Inscripcion(string nombre, List<string> materias)
        {
            NombreEstudiante = nombre;
            _materias = materias;
        }
    }
}
