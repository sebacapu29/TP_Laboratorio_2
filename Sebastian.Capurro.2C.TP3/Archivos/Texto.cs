using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(archivo))
                {
                    /*
                     * Se utiliza el metodo Split para cortar el texto a fin de guardarlo con espacios en el archivo .txt
                    */
                    string[] partes = datos.Split('\n');
                    foreach (string texto in partes)
                    {
                        file.WriteLine(texto);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd().ToString();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}

