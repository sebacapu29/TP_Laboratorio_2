using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructor y Sobrecargas
        static Profesor()
        {
            Profesor._random = new Random();
        }
        private Profesor() : base()
        {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 4));
            this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 4));
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Se encarga de construir la cadena con los datos del profesor
        /// </summary>
        /// <returns>String con los datos</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }
        /// <summary>
        /// Se encarga de construir un string con los datos de las clases que tiene el profesor
        /// </summary>
        /// <returns>String con la informacion solicitada</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                sb.AppendFormat("\n{0}", clase.ToString());
            }
            return "\nCLASES DEL DIA: " + sb.ToString() + "\n";
        }
        /// <summary>
        /// Se encarga de devolver todos los datos del profesor.
        /// </summary>
        /// <returns>String con la informacion del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga De Operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases claseDelProfe in i._clasesDelDia)
            {
                if (claseDelProfe == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
        #endregion

    }
}
