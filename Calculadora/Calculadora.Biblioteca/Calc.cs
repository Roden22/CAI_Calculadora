using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Biblioteca
{
    public class Calc
    {

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
            return a / b;
        }
    }
}
