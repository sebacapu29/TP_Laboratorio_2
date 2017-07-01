using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _nombre;
        private string _apellido;
        private int _dni;

        private ENacionalidad _nacionalidad;

        #region Enumerado

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region Constructor y Sobrecargas

        //Se utilizo las propiedades dentro de los constructores para validar.

        public Persona()
        {
            this._nombre = "Sin Nombre";
            this._apellido = "Sin Apellido";
            this._dni = 0;
            this._nacionalidad = ENacionalidad.Argentino;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de L/E. Valida el dato antes de setearlo.
        /// </summary>
        public string Nombre
        {
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
            get { return this._nombre; }
        }
        /// <summary>
        /// Prop. de L/E. Valida el dato antes de seterlo.
        /// </summary>
        public string Apellido
        {
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
            get { return this._apellido; }
        }
        /// <summary>
        /// Prop. de L/E. Valida el DNI  teniendo en cuenta la nacionalidad antes de setear.
        /// </summary>
        public int DNI
        {
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
            get
            {
                return this._dni;
            }
        }
        /// <summary>
        /// Prop. de L/E. Devuelve o setea  el campo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            set
            {
                this._nacionalidad = value;
            }
            get
            {
                return this._nacionalidad;
            }
        }
        /// <summary>
        /// Prop de S/L. Valida el DNI recibido como string, teniendo en cuenta la nacionalidad.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Verifica si el dato ingresado es un nombre o apellido válido.
        /// </summary>
        /// <param name="dato">Dato a verificar</param>
        /// <returns>Devuelve el dato en caso de ser correcto, sino se lanzara una excepcion</returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsNumber(dato, i))
                    return " ";
            }
            return dato;
        }
        
        /// <summary>
        /// Verifica si el DNI ingresa como string es valido y si se corresponde con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Devuelve el DNI validado en caso de éxito. Sino, lanzará una excepción</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniRetorno = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (int.TryParse(dato, out dniRetorno))
                    {
                        if (dniRetorno < 1 || dniRetorno > 89999999)
                        {
                            throw new NacionalidadInvalidaException("El DNI no es demasiado corto o largo para la nacionalidad");
                        }
                    }
                    else
                        throw new DniIvalidoException("El DNI de nacionalidad Argentino es incorrecto");
                    break;
                case ENacionalidad.Extranjero:
                    if (int.TryParse(dato, out dniRetorno))
                    {
                        if (dniRetorno < 89999999)
                        {
                            throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el numero de dni");
                        }
                    }
                    else
                        throw new DniIvalidoException("El DNI de nacionalidad Extranjero es incorrecto");
                    break;
                default:
                    break;
            }
            return dniRetorno;
        }
        /// <summary>
        /// Verifica si el DNI ingresa como int es valido y si se corresponde con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }
        #endregion

        #region Metodo Sobrescrito

        /// <summary>
        /// Muestra los datos de la persona
        /// </summary>
        /// <returns>String con todos los datos</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this._apellido + "," + this._nombre + "\nNACIONALIDAD: " + this._nacionalidad + "\n";//analizar salto de linea
        }
        #endregion
    }
}
