using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class BaseService
    {

        private static readonly SerializationService serializationService = new SerializationService();
        public void Add<T>(List<T> listado, T item,string directory,string filename)
        {
            listado.Add(item);
            serializationService.Serialize(listado, directory, filename);
        }

        public string GetElement<T>(List<T> listado, int index)
        {
            return listado[index].ToString();
        }

        public  void Edit<T>(List<T> listado, int index, T value, string directory, string filename)
        {
            listado[index] = value;
            serializationService.Serialize(listado, directory, filename);
        }

        public  void Delete<T>(List<T> listado, int? index, string directory, string filename)
        {
            int indice = index ?? 0;

            listado.RemoveAt(indice);
            serializationService.Serialize(listado, directory, filename);
        }
        public  void List<T>(List<T> listado, bool IsWait = false)
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
    }
}
