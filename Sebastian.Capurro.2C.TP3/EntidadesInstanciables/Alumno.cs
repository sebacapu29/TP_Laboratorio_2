using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Enumerado

        public enum EEstadoCuenta
        {
            AlDia, Becado, Deudor
        }
        #endregion

        #region Constructor y sobrecargas
        public Alumno():base()
        {
            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :base(id,nombre,apellido,dni,nacionalidad)//chequear
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos Sobrescritos

        /// <summary>
        /// Muestra la clase que toma el alumno(atributo)
        /// </summary>
        /// <returns>String con la informacion correspondiente</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: "+ this._claseQueToma.ToString();
        }
        /// <summary>
        /// Muestra el detalle del Alumno
        /// </summary>
        /// <returns>String correspondiente a la informacion</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos()+"\nESTADO DE CUENTA: "+this._estadoCuenta.ToString()+"\nTOMA CLASE DE: " + this._claseQueToma.ToString()+"\n\n";
        }
        /// <summary>
        /// Muestra todos los datos del Alumno
        /// </summary>
        /// <returns>String correspondiente a la informacion</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga De Operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma!=clase);
        }
        #endregion
    }
}
