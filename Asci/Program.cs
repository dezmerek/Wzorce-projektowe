using System;
using System.Text;

namespace Asci
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var chars = new int[256];
            Encoding dstEncodingFormat = Encoding.GetEncoding("US-ASCII",
                new EncoderExceptionFallback(),
                new DecoderReplacementFallback());
            byte[] convertedChars = dstEncodingFormat.GetBytes(input);

            foreach (var sign in convertedChars)
            {
                chars[sign] += 1;
            }

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != 0)
                {
                    Console.WriteLine($"{Convert.ToChar(i)}: {chars[i]}");
                }
            }

            //szyfr cezara
        }
    }
}
