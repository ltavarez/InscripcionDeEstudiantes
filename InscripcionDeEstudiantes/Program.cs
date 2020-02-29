using System;
using System.Collections.Generic;

namespace InscripcionDeEstudiantes
{
    class Program
    {

        public enum OpcionesMenuPrincipal
        {
            MANTENIMIENTO_ESTUDIANTES = 1,
            MANTENIMIENTO_MATERIAS,
            INSCRIBIR,
            LISTAR_INSCRIPCIONES,
            SALIR,

        }
        private struct Inscripcion
        {
            public string NombreEstudiante { get; set; }
            public List<string> _materias { get; set; }

            public Inscripcion(string nombre ,List<string> materias)
            {
                NombreEstudiante = nombre;
                _materias = materias;
            }

        }

        private static List<string> Estudiantes = new List<string>();

        private static List<string> Materias = new List<string>();

        private static List<Inscripcion> Inscripciones = new List<Inscripcion>();
        

        private static List<string> MateriasSeleccionada = new List<string>();
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecciona la opcion deseada: \n 1-Mantenimiento de estudiantes \n 2-Mantenimiento de materias \n 3-Inscribir estudiante \n 4-Listar inscripciones \n 5-Salir ");
            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case (int)OpcionesMenuPrincipal.MANTENIMIENTO_ESTUDIANTES:
                    MenuEstudiantes();
                    break;
                case (int)OpcionesMenuPrincipal.MANTENIMIENTO_MATERIAS:
                    MenuMaterias();
                    break;
                case (int)OpcionesMenuPrincipal.INSCRIBIR:
                    InscribirMaterias();
                    Menu();
                    break;
                case (int)OpcionesMenuPrincipal.LISTAR_INSCRIPCIONES:
                    ListarInscripciones(Inscripciones);
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

        private static void InscribirMaterias()
        {
            if (Estudiantes.Count > 0)
            {
                Console.WriteLine("Listado de estudiantes");

                MateriasSeleccionada = new List<string>();
                List(Estudiantes);

                Console.Write("Seleccione el estudiante que desea inscribir ");
                int index = Convert.ToInt32(Console.ReadLine());

                string nombreEstudiante = GetElement(Estudiantes, (index - 1));
                AgregarMateria();

                if (MateriasSeleccionada.Count <= 0)
                {
                    Console.WriteLine("No inscribio ninguna materia");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    Inscripcion inscripcion = new Inscripcion(nombreEstudiante, MateriasSeleccionada);
                    Add(Inscripciones, inscripcion);
                }
            }
            else
            {
                Console.WriteLine("No existen estudiantes en el sistema ");
                Console.ReadKey();
                Menu();
            }

        }

        private static void AgregarMateria()
        {

            if (Materias.Count > 0)
            {
                Console.WriteLine("\n Listado de materias");
                List(Materias);

                Console.Write("Seleccione la materia que desea inscribir ");
                int indexMateria = Convert.ToInt32(Console.ReadLine());

                string materia = GetElement(Materias, (indexMateria - 1));

                if (ValidarMateria(materia))
                {
                    MateriasSeleccionada.Add(materia);
                    Console.WriteLine("Desea inscribir otra materia S/N ");
                    string seleccion = Console.ReadLine();

                    if (seleccion == "S")
                    {
                        AgregarMateria();
                    }
                }
                else
                {
                    Console.WriteLine("Esta materia ya fue seleccionada ");
                    Console.WriteLine("Desea inscribir otra materia S/N ");
                    string seleccion = Console.ReadLine();

                    if (seleccion == "S")
                    {
                        AgregarMateria();
                    }
                }
            }
            else
            {
                Console.WriteLine("No existen materias en el sistema ");
                Console.ReadKey();
                Menu();
            }

        }

        private static bool ValidarMateria(string materiaAInscribir)
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

        private static void MenuEstudiantes()
        {
            Console.Clear();
            Console.WriteLine("Mantenimiento de estudiantes");
            Console.WriteLine("Selecciona la opcion deseada: \n 1-agregar un estudiante \n 2-editar un estudiante \n 3-eliminar un estudiante \n 4-Listar estudiantes \n 5-Volver atras");
            int menuEstudiantes = Convert.ToInt32(Console.ReadLine());

            switch (menuEstudiantes)
            {
                case 1:
                    FormularioDeAgregarEstudiante();
                    break;
                case 2:
                    FormularioDeEditarEstudiante();
                    break;
                case 3:
                    FormularioDeEliminarEstudiante();
                    break;
                case 4:
                    List(Estudiantes, true);
                    MenuEstudiantes();
                    break;
                case 5:
                    Menu();
                    break;
            }

        }

        private static void FormularioDeAgregarEstudiante()
        {
            Console.WriteLine("Introduzca el nombre del estudiante");
            string nombre = Console.ReadLine();

            Add(Estudiantes, nombre);

            MenuEstudiantes();
        }

        private static void FormularioDeEditarEstudiante()
        {
            try
            {

                Console.WriteLine("Listado de estudiantes");

                List(Estudiantes);

                Console.Write("Seleccione el estudiante que desea editar ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduzca nuevo valor del nombre del estudiante");
                string nombre = Console.ReadLine();

                Edit(Estudiantes, (index - 1), nombre);

                MenuEstudiantes();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error " + ex.Message);
                Console.ReadKey();
                MenuEstudiantes();
            }
        }

        private static void FormularioDeEliminarEstudiante()
        {
            
                Console.WriteLine("Listado de estudiantes");

                List(Estudiantes);

                Console.Write("Seleccione el estudiante que desea eliminar ");


                int index = Convert.ToInt32(Console.ReadLine());

                Delete(Estudiantes, (index - 1));

                MenuEstudiantes();
            
          
            
        }

        private static void MenuMaterias()
        {

            Console.Clear();
            Console.WriteLine("Mantenimiento de materias");
            Console.WriteLine("Selecciona la opcion deseada: \n 1-agregar una materia \n 2-editar una materia \n 3-eliminar una materia \n 4-Listar materias \n 5-Volver atras");
            int menuMaterias = Convert.ToInt32(Console.ReadLine());

            switch (menuMaterias)
            {
                case 1:
                    FormularioDeAgregarMaterias();
                    break;
                case 2:
                    FormularioDeEditarMaterias();
                    break;
                case 3:
                    FormularioDeEliminarMaterias();
                    break;
                case 4:
                    List(Materias, true);
                    MenuMaterias();
                    break;
                case 5:
                    Menu();
                    break;
            }

        }

        private static void FormularioDeAgregarMaterias()
        {
            Console.WriteLine("Introduzca el nombre de la materia");
            string nombre = Console.ReadLine();

            Add(Materias, nombre);

            MenuMaterias();
        }

        private static void FormularioDeEditarMaterias()
        {
            Console.WriteLine("Listado de materias");

            List(Materias);

            Console.Write("Seleccione la materia que desea editar ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduzca nuevo valor del nombre de la materia");
            string nombre = Console.ReadLine();

            Edit(Materias, (index - 1), nombre);

            MenuMaterias();
        }

        private static void FormularioDeEliminarMaterias()
        {

            Console.WriteLine("Listado de materias");

            List(Materias);

            Console.Write("Seleccione la materia que desea eliminar ");


            int index = Convert.ToInt32(Console.ReadLine());

            Delete(Materias, (index - 1));

            MenuMaterias();
        }

        private static void Add<T>(List<T> listado, T item)
        {
            listado.Add(item);
        }

        private static string GetElement<T>(List<T> listado, int index)
        {
            return listado[index].ToString();
        }

        private static void Edit<T>(List<T> listado, int index, T value)
        {
            listado[index] = value;
        }

        private static void Delete<T>(List<T> listado, int? index)
        {
            int indice = index ?? 0;

            listado.RemoveAt(indice);
        }
        private static void List<T>(List<T> listado, bool IsWait = false)
        {
            int contador = 1;
            foreach (T item in listado)
            {
                Console.WriteLine(contador + "- " + item);
                contador++;
            }

            if (IsWait)
            {
                Console.ReadKey();
            }
        }

        private static void ListarInscripciones(List<Inscripcion> listado)
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
