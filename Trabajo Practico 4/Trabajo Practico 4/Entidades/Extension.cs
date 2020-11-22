using Entidades;

namespace System.Collections.Generic
{
    /// <summary>
    /// Métodos de extensión.
    /// </summary>
    public static class Extension
    {
        #region Metodos
        /// <summary>
        /// Recibe un listado genérico para poder ser llamado por cualquier entidad y retorna
        /// el siguiente ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listado"></param>
        /// <returns>El próximo ID al último del listado.</returns>
        public static int ProximoID <T> (this List<T> listado)
        {
            int ultimoID = -1;

            if(listado is List<Compra>)
            {
                IList list = listado;

                for (int i = 0; i < list.Count; i++)
                {
                    Compra item = (Compra)list[i];

                    if (item.NroTicket > ultimoID)
                    {
                        ultimoID = item.NroTicket;
                    }
                }
            }
            else
            {
                if(listado is List<Producto>)
                {
                    IList list = listado;

                    for (int i = 0; i < list.Count; i++)
                    {
                        Producto item = (Producto)list[i];

                        if (item.Id > ultimoID)
                        {
                            ultimoID = item.Id;
                        }
                    }
                }
                else
                {
                    if(listado is List<Cliente>)
                    {
                        IList list = listado;

                        for (int i = 0; i < list.Count; i++)
                        {
                            Cliente item = (Cliente)list[i];

                            if (item.Codigo > ultimoID)
                            {
                                ultimoID = item.Codigo;
                            }
                        }
                    }
                }
            }

            return ultimoID + 1;
        }

        /// <summary>
        /// Recibe un listado genérico para poder ser llamado por cualquier Entidad y retorna
        /// el objeto que coincida con el ID recibido.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listado"></param>
        /// <param name="id"></param>
        /// <returns>El objeto que coincida con el ID.</returns>
        public static object BuscarID <T> (this List<T> listado, int id)
        {
            int i;

            if (listado is List<Compra>)
            {
                IList list = listado;

                for (i = 0; i < list.Count; i++)
                {
                    Compra item = (Compra)list[i];

                    if (item.NroTicket == id)
                    {
                        return item;
                    }
                }
            }
            else
            {
                if(listado is List<Cliente>)
                {
                    IList list = listado;

                    for (i = 0; i < list.Count; i++)
                    {
                        Cliente item = (Cliente)list[i];

                        if (item.Codigo == id)
                        {
                            return item;
                        }
                    }
                }
                else
                {
                    if(listado is List<Empleado>)
                    {
                        IList list = listado;

                        for (i = 0; i < list.Count; i++)
                        {
                            Empleado item = (Empleado)list[i];

                            if (item.Legajo == id)
                            {
                                return item;
                            }
                        }
                    }
                    else
                    {
                        if(listado is List<Producto>)
                        {
                            IList list = listado;

                            for (i = 0; i < list.Count; i++)
                            {
                                Producto item = (Producto)list[i];

                                if (item.Id == id)
                                {
                                    return item;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Recibe un listado genérico para poder ser llamado por cualquier Entidad y retorna
        /// el objeto que coincida con la Descripción recibida.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listado"></param>
        /// <param name="desc"></param>
        /// <returns>El objeto que coincida con la Descripción.</returns>
        public static object BuscarDescripcion <T> (this List<T> listado, string desc)
        {
            int i;
            
            if (listado is List<Cliente>)
            {
                IList list = listado;
                
                for (i = 0; i < list.Count; i++)
                {
                    Cliente item = (Cliente)list[i];
                    
                    if (item.ToString() == desc)
                    {
                        return item;
                    }
                }
            }
            else
            {
                if (listado is List<Empleado>)
                {
                    IList list = listado;
                    
                    for (i = 0; i < list.Count; i++)
                    {
                        Empleado item = (Empleado)list[i];
                        
                        if (item.ToString() == desc)
                        {
                            return item;
                        }
                    }
                }
                else
                {
                    if (listado is List<Producto>)
                    {
                        IList list = listado;
                        
                        for (i = 0; i < list.Count; i++)
                        {
                            Producto item = (Producto)list[i];
                            
                            if (item.Descripcion == desc)
                            {
                                return item;
                            }
                        }
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
