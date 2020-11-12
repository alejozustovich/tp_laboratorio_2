using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Las motos son chicas. Sobreescribe el tamaño del Vehiculo.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescribe el método Mostrar del Vehículo con los atributos del Ciclomotor
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            
            return sb.ToString();
        }
        #endregion
    }
}
