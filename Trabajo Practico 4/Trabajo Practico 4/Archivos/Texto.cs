using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos <string>
    {
        /// <summary>
        /// Implementación del método: escribe datos en un archivo.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string path, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(datos);

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
