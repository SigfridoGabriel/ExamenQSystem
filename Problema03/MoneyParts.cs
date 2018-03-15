using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema03
{
    public class MoneyParts
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el texto");
            var input = Console.ReadLine();

            var moneyParts = new MoneyParts();
            var result = moneyParts.Build(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public string Build(string number)
        {
            List<string> resultado = new List<string>();
            List<decimal> divisores = new List<decimal>
            {
                0.05m,
                0.1m,
                0.2m,
                0.5m,
                1.0m,
                2.0m,
                5.0m,
                10.0m,
                20.0m,
                50.0m,
                100.0m,
                200.0m
            };

            foreach (decimal div in divisores)
            {
                var dividendo = Convert.ToDecimal(number);
                var parteDecimal = dividendo - Math.Truncate(dividendo);
                dividendo = dividendo - Math.Round(parteDecimal, 2);
                decimal residuo = dividendo % div;
                if (residuo.Equals(0))
                {
                    List<decimal> cocientes = new List<decimal>();
                    var cociente = dividendo / div;
                    for (int i = 1; i<= cociente; i++)
                    {
                        cocientes.Add(div);
                    }
                    cocientes.Add(parteDecimal);
                    resultado.Add("[" + String.Join(",", cocientes) + "]");
                }
            }

            return "[" + String.Join(",", resultado) + "]";
        }
    }
}
