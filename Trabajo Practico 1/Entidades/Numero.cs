using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        double numero;

        /// <summary>
        /// Constructor sin parámetros: inicializa en 0 el atributo número.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con parámetro double: asigna el valor al atributo número.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero):this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con parámetro string: llama a la propiedad SetNumero.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero):this()
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Propiedad: asinga el valor previamente validado al atributo número.
        /// </summary>
        private string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        /// <summary>
        /// Valida que el valor ingresado sea numérico.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El número convertido, caso contrario retorna 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numeroValidado = 0;

            if (double.TryParse(strNumero, out numeroValidado))
                numeroValidado = double.Parse(strNumero);

            return numeroValidado;
        }

        /// <summary>
        /// Realiza la conversión de un número Decimal a Binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El número en formato binario, caso contrario un mensaje de alerta.</returns>
        public static string DecimalBinario(string numero)
        {
            int numeroInt = 0;
            string numeroBinario = string.Empty;

            if ((int.TryParse(numero, out numeroInt)))
            {
                if (numeroInt < 0)
                    numeroBinario = "Valor inválido";
                else
                {
                    if (numeroInt == 0)
                        numeroBinario = "0";
                    else
                    {
                        while (numeroInt > 0)
                        {
                            numeroBinario = (numeroInt % 2) + numeroBinario;
                            numeroInt = (numeroInt / 2);
                        }
                    }
                }
            }
            else
                numeroBinario = "Valor inválido";
            
            return numeroBinario;
        }

        /// <summary>
        /// Recibe un double y llama al método DecimalBinario para realizar la conversión.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>El número en formato binario, caso contrario un mensaje de alerta.</returns>
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = numero.ToString();

            numeroBinario = DecimalBinario(numero);

            return numeroBinario;
        }

        /// <summary>
        /// Valida que la cadena recibida sea en formato binario.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>True si es binaria, False si no lo es.</returns>
        private static bool EsBinario(string binario)
        {
            bool validacion = true;

            char[] arrayBinario = binario.ToCharArray();

            for (int i = 0; i < arrayBinario.Length; i++)
            {
                if ((arrayBinario[i] != '0') && (arrayBinario[i] != '1'))
                {
                    validacion = false;
                    break;
                }             
            }

            return validacion;
        }

        /// <summary>
        /// Realiza la conversión de un número Binario a Decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>El número decimal en formato string, caso contrario un mensaje de alerta.</returns>
        public static string BinarioDecimal(string binario)
        {
            string numeroDecimalString = string.Empty;

            if (EsBinario(binario))
            {
                int numeroDecimal = 0;
                char[] arrayBinario = binario.ToCharArray();

                Array.Reverse(arrayBinario);

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if(arrayBinario[i] == '1')
                    {
                        if (i == 0)
                            numeroDecimal += 1;
                        else
                            numeroDecimal += (int)Math.Pow(2, i);
                    }
                }

                numeroDecimalString = numeroDecimal.ToString();
            }
            else
                numeroDecimalString = "Valor inválido";

            return numeroDecimalString;
        }

        /// <summary>
        /// Sobrecarga el operador - : realiza la resta entre los atributos número de ambos objetos.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado de la operación.</returns>
        public static double operator - (Numero n1, Numero n2)
        {
            return (n1.numero) - (n2.numero);
        }

        /// <summary>
        /// Sobrecarga el operador + : realiza la suma entre los atributos número de ambos objetos.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado de la operación.</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            return (n1.numero) + (n2.numero);
        }

        /// <summary>
        /// Sobrecarga el operador / : realiza la división entre los atributos número de ambos objetos.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado de la operación, caso contrario el valor mínimo del tipo double.</returns>
        public static double operator / (Numero n1, Numero n2)
        {
            if(n2.numero == 0)
                return double.MinValue;
            else
                return (n1.numero) / (n2.numero);
        }

        /// <summary>
        /// Sobrecarga el operador * : realiza la multiplicación entre los atributos número de ambos objetos.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado de la operación.</returns>
        public static double operator * (Numero n1, Numero n2)
        {
            return (n1.numero) * (n2.numero);
        }
    }
}
