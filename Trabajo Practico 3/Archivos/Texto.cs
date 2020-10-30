using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        /// <summary>
        /// Implementación del método: escribe datos en un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si pudo escribir los datos, caso contrario lanza excepcion.</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Implementación del método: lee los datos de un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si lo pudo leer, caso contrario lanza excepcion.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using(StreamReader sr = new StreamReader(archivo))
                {
                    datos = string.Empty;
                    datos = sr.ReadToEnd();

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
