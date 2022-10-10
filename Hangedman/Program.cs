using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Hangedman
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var words = new[]
            {
            "stene",
            "banan",
            "lennart",
            "kalas",
            "katt",
            "hund",
            "rund",
            "torn",
            "klass"
             };
            var genereratOrd = words[new Random().Next(0, words.Length - 1)];
            var validCharacters = new Regex("^[a-z]$");

            int liv = 9;
            var gissningar = new List<string>();
                

            while (liv != 0)
            {
                int gissningarKvar = 0;
                foreach (var character in genereratOrd)
                {
                    var letter = character.ToString();


                    if (gissningar.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                        gissningarKvar++;
                    }
                    
                }
                
                Console.WriteLine(string.Empty);
                if (gissningarKvar == 0)
                {
                    break;
                }

                Console.Write("Gissa ord: ");
                var input = Console.ReadKey().Key.ToString().ToLower();
                Console.WriteLine(string.Empty);
                if (!validCharacters.IsMatch(input))
                {
                    Console.WriteLine($"The letter {input} is invalid. Try again");
                    continue;
                }
                if (gissningar.Contains(input))
                {
                    Console.WriteLine("Du har redan angett denna bokstav!");
                    continue;
                }
                gissningar.Add(input);

                if (!genereratOrd.Contains(input))
                {
                    liv--;

                    if (liv > 0)
                    {
                        Console.WriteLine($"Bokstaven {input} finns inte i ordet. Du har {liv} kvar");
                    }
                }


            }

            if (liv > 0)
            {
                Console.WriteLine($"Grattis! Du vann med {liv} liv kvar!");
            }
            else
            {
                Console.WriteLine($"Du förlorade! ordet var {genereratOrd}");
            }
        }
    }
}