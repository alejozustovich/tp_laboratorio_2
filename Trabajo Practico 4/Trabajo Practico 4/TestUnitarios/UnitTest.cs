using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entidades;
using Excepciones;
using System.IO;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Ingresar un producto con el mismo ID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProductoException))]
        public void ProductoRepetido()
        {
            List<Producto> l1 = new List<Producto>();
            
            Producto p1 = new Producto(1, "Test1", 100, 1, 1);
            Producto p2 = new Producto(1, "Test2", 100, 1, 1);

            l1 += p1;
            l1 += p2;
        }

        /// <summary>
        /// Guardar archivo sin path.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void GuardarArchivoTexto()
        {
            Texto txt = new Texto();

            txt.Guardar(null, "test");
            txt.Guardar(string.Empty, "test");
            txt.Guardar("", "test");
        }
    }
}
