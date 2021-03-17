using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculadora.Biblioteca
{
    public class Calc
    {

        public static bool CalcularExpresion(string expresion, out decimal resultado)
        {
            string regex = @"^\s*(?<valA>-?\d+\.?\d*)\s*(?<op>[\+\*-/])\s*(?<valB>-?\d+\.?\d*)\s*$";
            decimal valorA, valorB;

            Match match = System.Text.RegularExpressions.Regex.Match(expresion, regex);

            if (!match.Success)
            {
                resultado = 0;
                return false;
            }
            else
            {
                if( !ValidarDecimal(match.Groups["valA"].Value, out valorA) ||
                    !ValidarDecimal(match.Groups["valB"].Value, out valorB))
                {
                    resultado = 0;
                    return false;
                }
                return Calcular(valorA, valorB, match.Groups["op"].Value, out resultado);
            }
        }
        public static bool Calcular(decimal valorA, decimal valorB, string op, out decimal resultado)
        {
            switch (op)
            {
                case "+":
                    resultado = Calc.Sumar(valorA, valorB);
                    break;
                case "-":
                    resultado = Calc.Restar(valorA, valorB);
                    break;
                case "*":
                    resultado = Calc.Multiplicar(valorA, valorB);
                    break;
                case "/":
                    resultado = Calc.Dividir(valorA, valorB);
                    break;
                default:
                    resultado = 0;
                    return false;
            }
            return true;
        }
        public static bool ValidarDecimal(string s, out decimal numero)
        {
            return decimal.TryParse(s, out numero);
        }
        public static decimal Sumar(decimal a, decimal b)
        {
            return a + b;
        }
        public static decimal Restar(decimal a, decimal b)
        {
            return a - b;
        }
        public static decimal Multiplicar(decimal a, decimal b)
        {
            return a * b;
        }
        public static decimal Dividir(decimal a, decimal b)
        {
            if (b == 0) return 0;
            return a / b;
        }
    }
}
