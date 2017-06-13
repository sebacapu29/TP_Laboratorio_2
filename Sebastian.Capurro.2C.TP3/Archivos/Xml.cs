using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo)) 
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(T));
                    serializar.Serialize(sw,datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo)) 
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(T));
                     datos = (T)serializar.Deserialize(sr);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
