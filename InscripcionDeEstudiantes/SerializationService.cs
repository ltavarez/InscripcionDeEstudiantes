using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace InscripcionDeEstudiantes
{
    class SerializationService
    {

        public void Serialize(object obj,string directory,string filename)
        {
                CreateDirectory(directory);
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(directory +"/"+ filename,FileMode.Create,FileAccess.Write); 
                 
                formatter.Serialize(stream,obj);
                stream.Close();
        }

        public object Deserialize(string directory, string filename)
        {
            CreateDirectory(directory);

            object retorno = null;

            if (File.Exists(directory + "/" + filename))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(directory + "/" + filename, FileMode.Open, FileAccess.Read);

                retorno = formatter.Deserialize(stream);
                stream.Close();
            }

            return retorno;
        }



        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

        }

    }
}
