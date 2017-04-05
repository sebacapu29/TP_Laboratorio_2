using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        ///  Atributo de instancia de tipo double y ademas privado
        /// </summary>
        private double numero;

        /// <summary>
        /// Obtiene el valor del objeto numero instanciado.
        /// </summary>
        /// <returns>Un Double</returns>
        public double getNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// Constructor setea el valor inicial en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor asigna valor ingresado por parametro
        /// </summary>
        /// <param name="numero">Double a asignar al objeto</param>
        public Numero(double numero)//no se utiliza
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que setea el valor ingresado por parametro (string)
        /// </summary>
        /// <param name="numero">String a asignar al objeto</param>
 
        public Numero(string numero)
        {
            this.setNumero(numero);
        }
        /// <summary>
        /// Setea el numero ingresado por parametro
        /// </summary>
        /// <param name="numero">String que representa el numero a parsear y asignar</param>
        private void setNumero(string numero)
        {
            this.numero = Numero.validarNumero(numero);
        }
        /// <summary>
        /// Valida si lo que se ingreso es numerico
        /// </summary>
        /// <param name="numeroString">Cadena a validar</param>
        /// <returns>Devuelve el numero ingresado si es correcto, de lo contrario devuelve 0</returns>
        private static double validarNumero(string numeroString)
        {
            double retorno;
            if(!double.TryParse(numeroString, out retorno))
                retorno = 0;
 
            return retorno;
        }
    }
}
