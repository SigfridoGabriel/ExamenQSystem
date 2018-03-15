using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema01
{
    class ChangeString
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el texto");
            var input = Console.ReadLine();

            var changeString = new ChangeString();
            var result = changeString.Build(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public string Build(string letters)
        {
            char[] characters = letters.ToCharArray();
            var index = string.Empty;
            var newIndex = string.Empty;
            foreach (var chars in characters)
            {
                if (char.IsLetter(chars))
                {
                    var flag = char.IsLower(chars) == true ? true : false;
                    var currentIndex = (int)(char.ToUpper(chars));
                    if (currentIndex.Equals(145))
                    {
                        currentIndex = 79;
                    }
                    else if (currentIndex.Equals(78))
                    {
                        currentIndex = 145;
                    }
                    else if (currentIndex.Equals(90))
                    {
                        currentIndex = 65;
                    }
                    else
                    {
                        currentIndex += 1;
                    }
                    newIndex += flag == true ? ((Char)(currentIndex)).ToString().ToLower() :
                        ((Char)(currentIndex)).ToString().ToUpper();
                }
                else
                {
                    newIndex += chars;
                }
            }
            return newIndex;
        }
    }
}
