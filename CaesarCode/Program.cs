using System;
using System.Text;

namespace CaesarCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wprowadzź przesunięcie: ");
            var inputShift = Console.ReadLine();
            var shift = Convert.ToInt32(inputShift);
            Console.WriteLine("Wprowadź tekst do zaszyfrowania: ");
            var input = Console.ReadLine();
            var chars = new int[256];
            Encoding dstEncodingFormat = Encoding.GetEncoding("US-ASCII",
                new EncoderExceptionFallback(),
                new DecoderReplacementFallback());
            byte[] convertedChars = dstEncodingFormat.GetBytes(input);

            var codes = new int[input.Length];
            for (int i = 0; i < convertedChars.Length; i++)
            {
                var newIndex = shift % chars.Length;
                var valueFromConvertedChars = convertedChars[i] + newIndex;
                codes[i] = valueFromConvertedChars;
            }

            foreach (var t in codes)
            {
                Console.Write(Convert.ToChar(t));
            }
        }
    }
}
