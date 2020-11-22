using System;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class XML <T> : IArchivos <T>
    {
        /// <summary>
        /// Implementación del Método: guarda datos en un archivo XML.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string path, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                using (StreamWriter sw = new StreamWriter(path))
                {
                    xml.Serialize(sw, datos);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
    }
}
