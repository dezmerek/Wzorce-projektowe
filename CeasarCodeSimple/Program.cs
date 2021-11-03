using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace CeasarCodeSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            // litery małe, duże, cyfry
            var alphabets = new[] {
                'a', 'A', 'ą', 'Ą', 'b', 'B', 'c', 'C', 'ć', 'Ć', 'd', 'D', 'e', 'E', 'ę', 'Ę', 'f', 'F', 'g', 'G', 'h',
                'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'ł', 'Ł', 'm', 'M', 'n', 'N', 'ń', 'Ń', 'o', 'O', 'ó', 'Ó',
                'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 'ś', 'Ś', 't', 'T', 'u', 'U', 'w', 'W', 'v', 'V', 'x', 'X', 'y',
                'Y', 'z', 'Z', 'ź', 'Ź', 'ż', 'Ż', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            Decode(alphabets);
        }

        public static void Code(char[] alphabets)
        {
            while (true)
            {
                Console.WriteLine("Podaj przesunięcie: ");
                var shift = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj teks do zaszyfrowania: ");
                var text = Console.ReadLine().ToCharArray();
                var code = new char[text.Length];
                var alphabetList = alphabets.ToList();
                for (int i = 0; i < text.Length; i++)
                {
                    var positionOfLetter = alphabetList.IndexOf(text[i]);
                    var newIndex = positionOfLetter + shift;
                    code[i] = alphabets[newIndex % alphabets.Length];
                }

                foreach (var c in code)
                {
                    Console.Write(c);
                }

                Console.WriteLine();
            }
        }

        public static void Decode(char[] alphabets)
        {
            var alphabetList = alphabets.ToList();
            while (true)
            {
                Console.WriteLine("Podaj zaszyfrowany tekst: ");
                var input = Console.ReadLine();
                var code = input.ToCharArray();
                var decode = new List<char[]>();
                for (int i = 0; i < alphabets.Length; i++)
                {
                    var chars = new char[code.Length];
                    var shift = i;
                    for (int j = 0; j < code.Length; j++)
                    {
                        var positionOfLetter = alphabetList.IndexOf(code[j]);
                        var newIndex = positionOfLetter + shift;
                        chars[j] = alphabets[newIndex % alphabets.Length];
                    }

                    decode.Add(chars);
                }

                Console.WriteLine("Możliwe rozwiązania:");
                foreach (var decodeText in decode)
                {
                    foreach (var c in decodeText)
                    {
                        Console.Write(c);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Prawdopodobne rozwiązanie: ");
                var words = File.ReadAllLines("C:/Users/kasia/Documents/UniversitySecondYear/UniversitySecondYear/Windows1250/Resources/english-dictionary.txt");

                var goodWords = new List<string>();
                foreach (var d in decode)
                {
                    var word = String.Join("", d);
                    if (words.Contains(word))
                    {
                        goodWords.Add(word);
                    }
                }
                if (goodWords.Count > 0)
                {
                    foreach (var goodWord in goodWords)
                    {
                        Console.WriteLine(goodWord);
                    }
                }
            }
        }
    }
}

// DBW = cat