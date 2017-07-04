using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }
        /// <summary>
        /// Se encarga de escribir un archivo del dato ingresado por parametro, en el directorio base.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns> En caso de error lanza una excepcion, si puede escribir el archivo devuelve true</returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+this._archivo,true))
                {
                   
                    sw.WriteLine(datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
                
        }
        /// <summary>
        /// Se encarga leer el archivo y luego agregarlo a la lista que se ingresa por parametro
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>En caso de error lanzara una excepcion, sino retorna true.</returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            string datoAux;
            try
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+this._archivo))
                {
                    datoAux = sr.ReadLine();
                    while(datoAux!=null)
                    {
                        datos.Add(datoAux);
                        datoAux = sr.ReadLine();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
