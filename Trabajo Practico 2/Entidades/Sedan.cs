﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region ENUMERADOS
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas 
        }
        #endregion

        #region ATRIBUTOS
        ETipo tipo;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Asigno el tipo CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color, ETipo.CuatroPuertas)
        {

        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Sobreescribe el método Mostrar del Vehículo con los atributos del Sedan.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine((string)this);
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("TIPO   : " + this.tipo);
            sb.AppendLine("---------------------");
            sb.AppendLine("");

            return sb.ToString();
        }
        #endregion
    }
}
