using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;
using Archivos;

namespace UniTest
{
    [TestClass]
    public class TestUnitario
    {
        #region Colecciones Instanciadas
        /// <summary>
        /// Valida que se instancien las colecciones de la Universidad.
        /// </summary>
        [TestMethod]
        public void InstanciadaCorrectamente()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Jornadas);
            Assert.IsNotNull(uni.Instructores);
        }
        #endregion

        #region Excepciones
        /// <summary>
        /// Valida que se lance la Excepción al intentar agregar un Alumno repetido.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "nom", "app", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(1, "nom", "app", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            uni += a1;
            uni += a2;
        }

        /// <summary>
        /// Valida que se lance la Excepción al ingresar un DNI con formato incorrecto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniFormatoInvalildo()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "12.333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Valida que se lance la Excepción al ingresar un DNI con un caracter incorrecto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniCaracterInvalildo()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "123k567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Valida que se lance la Excepción al ingresar un DNI que no coincide con la Nacionalidad.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "0", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Valida que se lance la Excepción si hay una clase sin profesor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor()
        {
            Universidad u = new Universidad();
            Profesor p = new Profesor(1, "nn", "aa", "12345678", Persona.ENacionalidad.Argentino);

            u += p;
            u += Universidad.EClases.Programacion;
            u += Universidad.EClases.Laboratorio;
            u += Universidad.EClases.Legislacion;
            u += Universidad.EClases.SPD;
        }

        /// <summary>
        /// Valida que se lance la Excepción al intentar guardar en un directorio sin especificar.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void GuardarArchivoTexto()
        {
            Texto texto = new Texto();
            texto.Guardar(null, "asd");
            texto.Guardar("", "asd");
        }

        /// <summary>
        /// Valida que se lance la Excepción al intentar leer de un directorio sin especificar.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void LeerArchivoTexto()
        {
            Texto texto = new Texto();
            texto.Leer("", out string datos);
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida que el Nombre y Apellido se guarden con el formato correcto.
        /// </summary>
        [TestMethod]
        public void NombreFormato()
        {
            Alumno a1 = new Alumno(1, "noM", "aPp", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsFalse(a1.Nombre == "Nom");
            Assert.IsFalse(a1.Apellido == "App");
        }

        /// <summary>
        /// Valida que el Nombre y Apellido admitan únicamente caracteres válidos.
        /// </summary>
        [TestMethod]
        public void NombreCaracterInvalido()
        {
            Alumno a1 = new Alumno(1, "n7m", "a?p", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsFalse(string.IsNullOrEmpty(a1.Nombre) && string.IsNullOrEmpty(a1.Apellido));
        }

        /// <summary>
        /// Valida que 2 Universitarios no sean iguales.
        /// </summary>
        [TestMethod]
        public void UniversitarioIgualdad()
        {
            Universitario a1 = new Alumno(1, "nom", "app", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universitario p1 = new Profesor(2, "nom", "app", "123", Persona.ENacionalidad.Argentino);
            Alumno a2 = new Alumno(1, "nom", "app", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a3 = new Alumno(1, "nom", "app", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsFalse(a1 == p1);
            Assert.IsTrue(a2 == a3);
        }
        #endregion
    }  
}
