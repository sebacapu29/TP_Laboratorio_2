using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica si se ingresa un alumno repetido a la universidad.
        /// </summary>
        [TestMethod]
        public void checkAlumnoRepetido()
        {
            try
            {
                Universidad g1 = new Universidad();
                Alumno a1 = new Alumno(1, "Carlos", "Rodriguez", "36998456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                Alumno a2 = new Alumno(2, "Carlos", "Rodriguez", "36998456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                g1 += a1;
                g1 += a2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Verifica que la longitud del DNI con respecto a la nacionalidad sea válido.
        /// </summary>
        [TestMethod]
        public void checkLongitudDni()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Carlos", "Calvo", "899999999", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniIvalidoException));
            }
        }
        /// <summary>
        /// Verifica que el DNI ingresado sea válido.
        /// </summary>
        [TestMethod]
        public void checkNumeroDniIvalidoArg()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Manuel", "Alvarez", "499fsf999", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniIvalidoException));
            }
        }
        /// <summary>
        /// Verifica que el DNI ingresado con respecto a la nacionalidad sea válido
        /// </summary>
        [TestMethod]
        public void checkNumeroDniIvalidoExt()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Hernan", "Pachkevitch", "499999", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        /// <summary>
        /// Verifica que no haya valores nulos
        /// </summary>
        [TestMethod]
        public void checkValoresNulos()
        {
            Profesor i1 = new Profesor(1, "Gaston", "Lopez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Legislacion,i1);
            Assert.IsNotNull(j1.Alumnos);
        }
        /// <summary>
        /// Verifica si hay valores nulos en la instancia dada.
        /// </summary>
        [TestMethod]
        public void checkValoresNulos2()
        {
            Profesor i1 = new Profesor(1, "Gaston", "Lopez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Legislacion, i1);
            j1.Alumnos = null;
            Assert.IsNull(j1.Alumnos);
        }
    }
}
