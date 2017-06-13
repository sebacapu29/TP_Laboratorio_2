using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        protected List<Alumno> _alumnos;
        protected Profesor _instructor;
        protected Universidad.EClases _clase;

        #region Constructor y sobrecarga

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Prop de L/E. Devuelve o setea la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        /// <summary>
        /// Prop. de L/E. Devuelve o setea el atributo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        /// <summary>
        /// Prop. de L/E. Devuelve o setea el objeto especificado.
        /// </summary>
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region Sobrecarga De Operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j._clase);
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alumnoDeJornada in j._alumnos)
            {
                if (alumnoDeJornada == a)
                    throw new AlumnoRepetidoException();
            }
            j._alumnos.Add(a);
            return j;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Se encarga de construir todos los datos de la jornada, incluyendo datos de alumnos,profesor y clase.
        /// </summary>
        /// <returns>String correspondiente a la información</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE: {0} POR ", this._clase.ToString());
            sb.Append(this._instructor.ToString());
            sb.AppendLine("ALUMNOS:\n");
            foreach (Alumno a in this._alumnos)
            {
                sb.Append(a.ToString());
            }
            sb.AppendLine("\n<----------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Se encarga de guardar los datos de la jornada en un archivo .txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True si tuvo exito, caso contrario lanzará una excepción</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();
            archivo.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
            return true;
        }
        /// <summary>
        /// Busca el archivo .txt especificado para luego volcarlos en el programa.
        /// </summary>
        /// <returns>String con el contenido del archivo en caso de éxito, sino lanzará una excepción.</returns>
        public static string Leer()
        {
            string jornada = "";
            Texto archivo = new Texto();
            archivo.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out jornada);
            return jornada;

        }
        #endregion

    }
}
