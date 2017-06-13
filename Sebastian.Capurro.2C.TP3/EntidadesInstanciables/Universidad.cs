using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        protected List<Alumno> _alumnos;
        protected List<Profesor> _profesores;
        protected List<Jornada> _jornadas;

        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornadas = new List<Jornada>();
        }
        #region Enumerado
        public enum EClases
        {
            Laboratorio, Programacion, Legislacion, SPD
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Porp. L/E. Devuelve o setea la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        /// <summary>
        /// Prop. de L/E. Devuelve o setea la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this._profesores; }
            set { this._profesores = value; }
        }
        /// <summary>
        /// Prop de L/E. Devuelve o setea la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this._jornadas; }
            set { this._jornadas = value; }
        }
        /// <summary>
        /// Prop. de L/E. Accede al objeto especificado a travez de un índice.
        /// </summary>
        /// <param name="i">Índice que se desea insertar</param>
        /// <returns>Una jornada válida en caso de ser un indice válido, caso contrario lanzará una excepción.</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._jornadas.Count)
                    return this._jornadas[i];
                else
                    throw new Exception("Indexador inválido");
            }
            set
            {
                if (i > 0 && i < this._jornadas.Count)
                    this._jornadas[i] = value;
                else
                    throw new Exception("Indexador inválido");
            }
        }
        #endregion

        #region Sobrecarga De Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool valRetorno = false;
            foreach (Alumno alumnoDeUniversidad in g._alumnos)
            {
                if (alumnoDeUniversidad == a)
                {
                    valRetorno = true;
                    break;
                }
            }
            return valRetorno;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g == a));
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g._profesores.Add(i);

            return g;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool valRetorno = false;
            foreach (Profesor profesorDeUniversidad in g._profesores)
            {
                if (profesorDeUniversidad == i)
                {
                    valRetorno = true;
                    break;
                }
            }
            return valRetorno;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g == i));
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g._profesores)
            {
                if (instructor == clase)
                    return instructor;
            }
            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor instructor in g._profesores)
            {
                if (instructor != clase)
                    return instructor;
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno a in g._alumnos)
            {
                if (a == clase)
                {
                    jornada += a;
                }
            }
            g._jornadas.Add(jornada);

            return g;
        }
        #endregion

        /// <summary>
        /// Se encarga de construir una cadena con todos los datos de la universidad, jornadas,profesores,alumnos.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>String con toda la informacion a la universidad</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in gim.Jornadas)
            {
                sb.Append(j.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        ///  Se encarga de procesar y devolver los datos asociados a la universidad, jornadas,profesores,alumnos.
        /// </summary>
        /// <returns>String con toda la informacion a la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Se encarga de serializar todos los datos de la universidad en un archivo .xml.
        /// </summary>
        /// <param name="g"></param>
        /// <returns>True en caso de éxito, sino lanzará una excepción.</returns>
        public static bool Guardar(Universidad g)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", g);
        }
        /// <summary>
        /// Se encarga de buscar el archivo xml necesario para transformarlo en un objeto y poder volcarlo al programa.
        /// </summary>
        /// <returns>un obj Universidad en caso de éxito, sinó se lanzará una excepción.</returns>
        public static Universidad Leer()
        {
            Universidad g;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out g);
            return g;
        }
    }
}
