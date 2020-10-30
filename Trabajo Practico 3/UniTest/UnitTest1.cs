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
        /// Valida que se haya instanciado un atributo Lista de Alumnos
        /// </summary>
        [TestMethod]
        public void InstanciaDeListaAlumno()
        {
            Profesor prof = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, prof);

            Assert.IsNotNull(jornada.Alumnos);
        }

        /// <summary>
        /// Valida que se haya instanciado un atributo Lista de Jornada
        /// </summary>
        [TestMethod]
        public void InstanciaDeListaJornada()
        {
            Profesor prof = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, prof);
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Jornadas);
        }

        /// <summary>
        /// Valida que se haya instanciado un atributo Lista de Profesores
        /// </summary>
        [TestMethod]
        public void InstanciaDeListaProfesores()
        {
            Profesor prof = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, prof);
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }
        #endregion

        #region Excepciones
        /// <summary>
        /// Verifica que se lance la Excpcion al agrregar alumno repetido
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
        /// Verifica que se lance excepcion al ingresar dni con formato invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniFormatoInvalildo()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "12.333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Verifica que se lance excepcion al ingresar dni con longitud invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniLengthInvalildo()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "123456789", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Verifica que se lance excepcion al ingresar dni con caracter invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniCaracterInvalildo()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "123k567", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Verifica que se lance excepcion al ingresar dni que no coincide con nacionalidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a1 = new Alumno(1, "nom", "app", "0", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }
        /// <summary>
        /// Verifica que se lance la excepcion al encontrar una clase si profesor
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
        /// Verifica que se lance la excepcion al intentar guardar un objeto en un directorio no especificado
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
        /// Verifica que se lance la excepcion al intentar leer un archivo cuando no se encuntra el directorio
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
        /// Verifica que nombre y apellido se guardan con el formato esperado
        /// </summary>
        [TestMethod]
        public void NombreFormato()
        {
            Alumno a1 = new Alumno(1, "noM", "aPp", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsTrue(a1.Nombre == "Nom");
            Assert.IsTrue(a1.Apellido == "App");
            Assert.IsFalse(a1.Apellido == "aPp");

        }

        /// <summary>
        /// Verifica que solo se admitan caracteres validos para nombre y apellido
        /// </summary>
        [TestMethod]
        public void NombreCaracterInvalido()
        {
            Alumno a1 = new Alumno(1, "n7m", "a?p", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsTrue(string.IsNullOrEmpty(a1.Nombre) && string.IsNullOrEmpty(a1.Apellido));

        }

        /// <summary>
        /// verifica que dos universitarios no sean iguales por tipos y legajo
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
