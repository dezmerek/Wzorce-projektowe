using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace Hash
{
    class Program
    {
        public static char object1 { get; set; }
        public static char object2 { get; set; }
        static void Main(string[] args)
        {
            var alphabets = new[] {
                'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h',
                'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O',
                'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'w', 'W', 'v', 'V', 'x', 'X', 'y',
                'Y', 'z', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            var currentChar = ' ';
            var currentChar2 = ' ';
            var currentChar3 = ' ';
            Stopwatch stopwatch = Stopwatch.StartNew();
            var lines = new List<string>();
            for (int i = 0; i < alphabets.Length; i++)
            {
                currentChar = alphabets[i];
                for (int j = 0; j < alphabets.Length; j++)
                {
                    currentChar2 = alphabets[j];
                    for (int k = 0; k < alphabets.Length; k++)
                    {
                        currentChar3 = alphabets[k];
                        for (int l = 0; l < alphabets.Length; l++)
                        {
                            lines.Add($"{(currentChar, currentChar2, currentChar3, alphabets[l]).GetHashCode()}");
                        }
                    }
                    //object1 = currentChar;
                    //object2 = alphabets[j];
                    //lines.Add($"{(object1, object2).GetHashCode()}");

                    //Console.WriteLine($"{object1}{object2}");
                    //Console.WriteLine((object1, object2).GetHashCode());
                }
            }
            SaveInFile(lines);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        public async static void SaveInFile(List<string> lines)
        {
            await File.WriteAllLinesAsync("C:/Users/Kasia/Documents/UniversitySecondYear/UniversitySecondYear/Hash/text.txt", lines);
        }
    }
}
// ile czasu trwa wygenerowanie wszystkich wyników hashowania dla wszystkich łańcóchów złożonych z dużę, małe litery, cyfry - par
// do pliku a wypisanie na ekran?
// heron
//00:00:00.1156557
// 80 ms
// 5,67s