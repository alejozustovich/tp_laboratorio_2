using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region ATRIBUTOS
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        #endregion

        #region ENUMERADOS
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor privado por defecto: instancia la lista de vehículos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor público parametrizado: asigna el espacio disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if(v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if(v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }  
                        break;
                    case ETipo.Automovil:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        } 
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region OPERADORES
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            bool yaEstaEnLaLista = false;

            if(taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        yaEstaEnLaLista = true;
                        break;
                    }
                }

                if(!yaEstaEnLaLista)
                {
                    taller.vehiculos.Add(vehiculo);
                }
            }

            return taller;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(v);
                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
