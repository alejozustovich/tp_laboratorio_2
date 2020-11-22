namespace Entidades
{
    public abstract class Persona
    {
        #region Atributos
        private string nombre;
        private string apellido;
        #endregion

        #region Propiedades
        /// <summary>
        /// Permisos de sólo lectura para el nombre.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
        }

        /// <summary>
        /// Permisos de sólo lectura para el apellido.
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado: asigna los atributos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        protected Persona(string nombre, string apellido) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Hace públicos los atributos de la Persona.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return ("NOMBRE: " + this.ToString());
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga el método ToString() para retornar el nombre y apellido de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this.Apellido + ", " + this.Nombre);
        }
        #endregion
    }
}
