using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
       /// <summary>
       /// Realiza la operacion solicitada por el usuario (suma, resta, multiplicacion, division)
       /// </summary>
       /// <param name="numero1"> Objeto de tipo Numero representa el primer numero a calcular</param>
       /// <param name="numero2">Objeto de tipo Numero representa el segundo numero a calcular</param>
       /// <param name="operador">Es el caracter (en formato string) representa la operacion a realizar</param>
       /// <returns>Retorna un valor double como resultado</returns>
  
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            string operadorValido;
            double retorno;
            
            operadorValido = Calculadora.validarOperador(operador);

            switch (operadorValido)
            {
                case "+":
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    retorno = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    retorno = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if(numero2.getNumero()==0)
                    {
                        retorno = 0;
                    }
                    else
                    {
                        retorno = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
                default:
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;
            }
                return retorno;
            }
        /// <summary>
        /// Se encarga de Validar el operador (caracter) ingresado por el usuario
        /// </summary>
        /// <param name="operador">Representa el caracter a validar</param>
        /// <returns>Devuelve un caracter (en formato string) si el caracter es Valido, sino, devuelve el caracter "+"</returns>

        public static string validarOperador(string operador)
        {
            string retorno;
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }
    }
}
