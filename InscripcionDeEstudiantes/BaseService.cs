using System;
using System.Collections.Generic;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class BaseService
    {
        public void Add<T>(List<T> listado, T item)
        {
            listado.Add(item);
        }

        public string GetElement<T>(List<T> listado, int index)
        {
            return listado[index].ToString();
        }

        public  void Edit<T>(List<T> listado, int index, T value)
        {
            listado[index] = value;
        }

        public  void Delete<T>(List<T> listado, int? index)
        {
            int indice = index ?? 0;

            listado.RemoveAt(indice);
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
