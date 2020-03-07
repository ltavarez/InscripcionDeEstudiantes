using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    public static class  MenuPrincipal
    {
        public enum OpcionesMenuPrincipal
        {
            MANTENIMIENTO_ESTUDIANTES = 1,
            MANTENIMIENTO_MATERIAS,
            INSCRIBIR,
            LISTAR_INSCRIPCIONES,
            SALIR,

        }

        private static List<string> Estudiantes = new List<string>();
        private static List<string> Materias = new List<string>();

        private static List<Inscripcion> Inscripciones = new List<Inscripcion>();
        private static readonly InscripcionService inscripcionService = new InscripcionService();



        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecciona la opcion deseada: \n 1-Mantenimiento de estudiantes \n 2-Mantenimiento de materias \n 3-Inscribir estudiante \n 4-Listar inscripciones \n 5-Salir ");
            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case (int)OpcionesMenuPrincipal.MANTENIMIENTO_ESTUDIANTES:
                    EstudianteService.MenuEstudiantes(ref Estudiantes);
                  
                    break;
                case (int)OpcionesMenuPrincipal.MANTENIMIENTO_MATERIAS:
                    MateriaService.MenuMaterias(ref Materias);
                    break;
                case (int)OpcionesMenuPrincipal.INSCRIBIR:
                    inscripcionService.InscribirMaterias(Estudiantes,Materias,ref Inscripciones);
                    Menu();
                    break;
                case (int)OpcionesMenuPrincipal.LISTAR_INSCRIPCIONES:
                    inscripcionService.ListarInscripciones(Inscripciones);
                    Menu();
                    break;
                case (int)OpcionesMenuPrincipal.SALIR:
                    Console.WriteLine("Gracias por usar nuestro sistema");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Esta opcion no es valida");
                    Console.ReadKey();
                    Menu();
                    break;
            }

        }

    }
}
