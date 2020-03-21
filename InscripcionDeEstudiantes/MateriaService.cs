using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class MateriaService
    {

        private static BaseService baseService = new BaseService();

        private const string MateriasDirectory = "Materias";
        private const string MateriasFilename = "materias.dat";
        public static void MenuMaterias(ref List<string> Materias)
        {

            Console.Clear();
            Console.WriteLine("Mantenimiento de materias");
            Console.WriteLine("Selecciona la opcion deseada: \n 1-agregar una materia \n 2-editar una materia \n 3-eliminar una materia \n 4-Listar materias \n 5-Volver atras");
            int menuMaterias = Convert.ToInt32(Console.ReadLine());

            switch (menuMaterias)
            {
                case 1:
                    FormularioDeAgregarMaterias(ref Materias);
                    break;
                case 2:
                    FormularioDeEditarMaterias(ref Materias);
                    break;
                case 3:
                    FormularioDeEliminarMaterias(ref Materias);
                    break;
                case 4:
                    baseService.List(Materias, true);
                    MenuMaterias(ref Materias);
                    break;
                case 5:
                    MenuPrincipal.Menu();
                    break;
            }

        }

        private static void FormularioDeAgregarMaterias(ref List<string> Materias)
        {
            Console.WriteLine("Introduzca el nombre de la materia");
            string nombre = Console.ReadLine();

            baseService.Add(Materias, nombre,MateriasDirectory,MateriasFilename);

            MenuMaterias(ref Materias);
        }

        private static void FormularioDeEditarMaterias(ref List<string> Materias)
        {
            Console.WriteLine("Listado de materias");

            baseService.List(Materias);

            Console.Write("Seleccione la materia que desea editar ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduzca nuevo valor del nombre de la materia");
            string nombre = Console.ReadLine();

            baseService.Edit(Materias, (index - 1), nombre,MateriasDirectory,MateriasFilename);

            MenuMaterias(ref Materias);
        }

        private static void FormularioDeEliminarMaterias(ref List<string> Materias)
        {

            Console.WriteLine("Listado de materias");

            baseService.List(Materias);

            Console.Write("Seleccione la materia que desea eliminar ");


            int index = Convert.ToInt32(Console.ReadLine());

            baseService.Delete(Materias, (index - 1),MateriasDirectory,MateriasFilename);

            MenuMaterias(ref Materias);
        }
    }
}
