using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class EstudianteService
    {

        private static BaseService baseService = new BaseService();

        public static void MenuEstudiantes(ref List<string> Estudiantes)
        {
            Console.Clear();
            Console.WriteLine("Mantenimiento de estudiantes");
            Console.WriteLine("Selecciona la opcion deseada: \n 1-agregar un estudiante \n 2-editar un estudiante \n 3-eliminar un estudiante \n 4-Listar estudiantes \n 5-Volver atras");
            int menuEstudiantes = Convert.ToInt32(Console.ReadLine());

            switch (menuEstudiantes)
            {
                case 1:
                    FormularioDeAgregarEstudiante(ref Estudiantes);
                    break;
                case 2:
                    FormularioDeEditarEstudiante(ref Estudiantes);
                    break;
                case 3:
                    FormularioDeEliminarEstudiante(ref Estudiantes);
                    break;
                case 4:
                    baseService.List(Estudiantes, true);
                    MenuEstudiantes(ref Estudiantes);
                    break;
                case 5:
                    MenuPrincipal.Menu();
                    break;
            }

        }

        private static void FormularioDeAgregarEstudiante(ref List<string> Estudiantes)
        {
            Console.WriteLine("Introduzca el nombre del estudiante");
            string nombre = Console.ReadLine();

            baseService.Add(Estudiantes, nombre);

            MenuEstudiantes(ref Estudiantes);
        }

        private static void FormularioDeEditarEstudiante(ref List<string> Estudiantes)
        {
            try
            {

                Console.WriteLine("Listado de estudiantes");

                baseService.List(Estudiantes);

                Console.Write("Seleccione el estudiante que desea editar ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduzca nuevo valor del nombre del estudiante");
                string nombre = Console.ReadLine();

                baseService.Edit(Estudiantes, (index - 1), nombre);

                MenuEstudiantes(ref Estudiantes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error " + ex.Message);
                Console.ReadKey();
                MenuEstudiantes(ref Estudiantes);
            }
        }

        private static void FormularioDeEliminarEstudiante(ref List<string> Estudiantes)
        {

            Console.WriteLine("Listado de estudiantes");

            baseService.List(Estudiantes);

            Console.Write("Seleccione el estudiante que desea eliminar ");


            int index = Convert.ToInt32(Console.ReadLine());

            baseService.Delete(Estudiantes, (index - 1));

            MenuEstudiantes(ref Estudiantes);



        }
    }
}
