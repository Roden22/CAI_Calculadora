using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora.Biblioteca;

namespace Calculadora.Interfaz
{
    class Program
    {
        static void Main()
        {
            string modo;

            do
            {
                Console.Write("Ingresar modo de operación: E para expresión o S para valores separados: ");
                modo = Console.ReadLine();
                switch (modo.ToUpper())
                {
                    case "E":
                        EjecutarModoExpresion();
                        break;
                    case "S":
                        EjecutarModoSeparado();
                        break;
                    default:
                        Console.WriteLine("Modo inválido.");
                        break;
                }
            } while (modo.ToUpper() != "E" && modo.ToUpper() != "S");
            

        }

        static void EjecutarModoExpresion()
        {
            string expresion;
            decimal resultado;

            do
            {
                Console.Write("Ingresar expresión (ej: 1+1) o S para salir: ");
                expresion = Console.ReadLine();
                if (expresion.ToUpper() == "S") return;

                if(Calc.CalcularExpresion(expresion, out resultado))
                {
                    Console.WriteLine("Resultado: {0}", resultado);
                }
                else
                {
                    Console.WriteLine("Error: operación inválida.");
                }

            } while (expresion.ToUpper() != "S");
        }
        static void EjecutarModoSeparado()
        {
            string valorLeido;
            decimal valorA, valorB, resultado;
            string simboloOperacion = "";

            do
            {
                Console.Write("Ingresar primer número o S para salir: ");
                valorLeido = Console.ReadLine();
                if (valorLeido.ToLower() == "s") break;
                if (!ValidarNumero(valorLeido, out valorA)) continue;

                Console.Write("Ingresar segundo número: ");
                valorLeido = Console.ReadLine();
                if (!ValidarNumero(valorLeido, out valorB)) continue;


                Console.Write("Ingresar símbolo de la operación (+ - * /) o S para salir: ");
                simboloOperacion = Console.ReadLine();

                if (simboloOperacion.ToUpper() == "S") break;

                if(Calc.Calcular(valorA, valorB, simboloOperacion, out resultado))
                {
                    //ImprimirResultado(valorA, valorB, simboloOperacion, resultado);
                    Console.WriteLine("Resultado: {0}", resultado);
                }
                else
                {
                    Console.WriteLine("Error: operación inválida");
                }
                

            } while (simboloOperacion.ToUpper() != "S");
        }
        public static void ImprimirResultado(decimal valorA, decimal valorB, string operacion, decimal resultado)
        {
            switch (operacion)
            {
                case "+":
                    Console.WriteLine($"Suma: {valorA} + {valorB} = {resultado}");
                    break;
                case "-":
                    Console.WriteLine($"Resta: {valorA} - {valorB} = {resultado}");
                    break;
                case "*":
                    Console.WriteLine($"Multiplicación: {valorA} * {valorB} = {resultado}");
                    break;
                case "/":
                    Console.WriteLine($"División: {valorA} / {valorB} = {resultado}");
                    break;
                default:
                    Console.WriteLine("Error: símbolo de operación inválido.");
                    break;
            }
        }
        static bool ValidarNumero(string str, out decimal num)
        {
            bool fueValidacionExitosa = Calc.ValidarDecimal(str, out num);
            if (!fueValidacionExitosa)
            {
                Console.WriteLine("Error: valor inválido.");
            }

            return fueValidacionExitosa;
        }

    }
}
