using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekser
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new Lekser();
            var textToParse = "() 1 23 +";

            if (l.analizuj(textToParse))
            {
                Console.WriteLine("Rozpoznano wyrazenie");
                foreach (var t in l.Token)
                {
                    Console.WriteLine("<{0},{1}>", t.Name, t.Argument);
                }
            }
            else
            {
                var index = 0;
                Console.WriteLine("Błąd leksera");
                Console.WriteLine("Nieznany token: {1}, na pozycji {0}",
                    index = l.Token.Count > 0 ? l.Token.Last().Index + 1 : 0,
                    textToParse.Substring(index, textToParse.Length - index > 10 ? 10 : textToParse.Length - index)
                );
            }

            Console.WriteLine("Test");
            Console.WriteLine("Test");
            Console.WriteLine("Test");

            Console.ReadLine();
        }
    }
}
