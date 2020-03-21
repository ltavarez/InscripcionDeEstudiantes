using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class InscripcionService
    {
        private static List<string> MateriasSeleccionada = new List<string>();

        private static readonly BaseService baseService = new BaseService();

        private const string InscripcionesDirectory = "Inscripciones";
        private const string InscripcionesFilename = "inscripciones.dat";

        public void InscribirMaterias(List<string> Estudiantes,List<string> Materias,ref List<Inscripcion> Inscripciones)
        {
            if (Estudiantes.Count > 0)
            {
                Console.WriteLine("Listado de estudiantes");

                MateriasSeleccionada = new List<string>();
                baseService.List(Estudiantes);

                Console.Write("Seleccione el estudiante que desea inscribir ");
                int index = Convert.ToInt32(Console.ReadLine());

                string nombreEstudiante = baseService.GetElement(Estudiantes, (index - 1));
                AgregarMateria(Materias);

                if (MateriasSeleccionada.Count <= 0)
                {
                    Console.WriteLine("No inscribio ninguna materia");
                    Console.ReadKey();
                    MenuPrincipal.Menu();
                }
                else
                {
                    Inscripcion inscripcion = new Inscripcion(nombreEstudiante, MateriasSeleccionada);
                    baseService.Add(Inscripciones, inscripcion,InscripcionesDirectory,InscripcionesFilename);
                }
            }
            else
            {
                Console.WriteLine("No existen estudiantes en el sistema ");
                Console.ReadKey();
                MenuPrincipal.Menu();
            }

        }

        private static void AgregarMateria(List<string> Materias)
        {

            if (Materias.Count > 0)
            {
                Console.WriteLine("\n Listado de materias");
                baseService.List(Materias);

                Console.Write("Seleccione la materia que desea inscribir ");
                int indexMateria = Convert.ToInt32(Console.ReadLine());

                string materia = baseService.GetElement(Materias, (indexMateria - 1));

                if (ValidarMateria(materia))
                {
                    MateriasSeleccionada.Add(materia);
                    Console.WriteLine("Desea inscribir otra materia S/N ");
                    string seleccion = Console.ReadLine();

                    if (seleccion == "S")
                    {
                        AgregarMateria(Materias);
                    }
                }
                else
                {
                    Console.WriteLine("Esta materia ya fue seleccionada ");
                    Console.WriteLine("Desea inscribir otra materia S/N ");
                    string seleccion = Console.ReadLine();

                    if (seleccion == "S")
                    {
                        AgregarMateria(Materias);
                    }
                }
            }
            else
            {
                Console.WriteLine("No existen materias en el sistema ");
                Console.ReadKey();
                MenuPrincipal.Menu();
            }

        }

        public static bool ValidarMateria(string materiaAInscribir)
        {

            bool EsValida = true;
            foreach (string materia in MateriasSeleccionada)
            {
                if (materia == materiaAInscribir)
                {
                    EsValida = false;
                }
            }

            return EsValida;
        }

        public  void ListarInscripciones(List<Inscripcion> listado)
        {
            foreach (Inscripcion item in listado)
            {
                Console.WriteLine("\n \n El nombre del estudiante es " + item.NombreEstudiante);
                Console.WriteLine("Tiene las siguientes materias");

                int contador = 1;
                foreach (string materia in item._materias)
                {
                    Console.WriteLine(contador + "- " + materia);
                    contador++;
                }

            }

            Console.ReadKey();
        }
    }
}
