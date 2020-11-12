using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        #region Metodos
        /// <summary>
        /// Implementación del Método: guarda datos en un archivo XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si lo pudo guardar, caso contrario lanza excepcion.</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    xml.Serialize(sw, datos);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Implementación del Método: lee datos de un archivo XML.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si los pudo leer, caso contrario lanza excepcion.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                using (TextReader tr = new StreamReader(archivo))
                {
                    datos = (T)xml.Deserialize(tr);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        #endregion
    }
}
