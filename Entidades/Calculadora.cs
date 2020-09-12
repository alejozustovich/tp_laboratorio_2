using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador convertido, si no es valido retorna "+"</returns>
        private static string ValidarOperador(char operador)
        {
            if ((operador == '+') || (operador == '-') || (operador == '*') || (operador == '/'))
                return operador.ToString();
            else
                return "+";
        }

        /// <summary>
        /// Valida y realiza la operación entre los 2 números.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operación.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = -1;
            char operadorChar = Convert.ToChar(operador[0]);

            operador = ValidarOperador(operadorChar);

            switch(operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    break;

                default:
                    resultado = 0;
                    break;
            }

            return resultado;
        }
    }
}
