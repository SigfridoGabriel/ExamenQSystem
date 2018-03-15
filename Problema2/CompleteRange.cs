using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema2
{
    class CompleteRange
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el texto");
            var input = Console.ReadLine();

            var completeRange = new CompleteRange();
            var result = completeRange.Build(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public string Build(string numbers)
        {
            List<int> intDigits = new List<int>();
            List<int> oDigits = new List<int>();
            List<string> strDigits = numbers.Replace("[", "").Replace("]", "")
                .Split(',').ToList<string>();

            foreach (var digit in strDigits)
            {
                intDigits.Add(Convert.ToInt32(digit));
            }

            intDigits.Sort();

            var max = intDigits.Max();

            for (int i = 1; i <= max; i++)
            {
                oDigits.Add(i);
            }

            return "[" + String.Join(",", oDigits) + "]";
        }
    }
}
