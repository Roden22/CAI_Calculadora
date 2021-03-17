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
            string valorLeido;
            decimal valorA, valorB;
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
                switch (simboloOperacion)
                {
                    case "+":
                        Console.WriteLine($"Suma: {valorA} + {valorB} = {Calc.Sumar(valorA,valorB)}");
                        break;
                    case "-":
                        Console.WriteLine($"Resta: {valorA} - {valorB} = {Calc.Restar(valorA,valorB)}");
                        break;
                    case "*":
                        Console.WriteLine($"Multiplicación: {valorA} * {valorB} = {Calc.Multiplicar(valorA, valorB)}");
                        break;
                    case "/":
                        Console.WriteLine($"División: {valorA} / {valorB} = {Calc.Dividir(valorA, valorB)}");
                        break;
                    default:
                        Console.WriteLine("Error: símbolo de operación inválido.");
                        break;
                }
                
            } while (simboloOperacion.ToLower() != "s");

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
