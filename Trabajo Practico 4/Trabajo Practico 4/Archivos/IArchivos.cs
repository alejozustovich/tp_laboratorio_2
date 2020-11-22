namespace Archivos
{
    public interface IArchivos <T>
    {
        /// <summary>
        /// Firma del método a implementar para guardar datos en un archivo. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string path, T datos);
    }
}
