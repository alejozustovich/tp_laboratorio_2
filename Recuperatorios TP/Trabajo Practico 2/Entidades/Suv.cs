using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor parametrizado recibe valores
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescribe el método Mostrar del Vehículo con los atributos de Suv
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            
            return sb.ToString();
        }
        #endregion
    }
}
