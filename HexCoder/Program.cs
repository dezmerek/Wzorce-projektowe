using System;
using System.Collections.Generic;
using System.Numerics;

namespace HexCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 55;
            var e = 27;
            var l = new List<int> { 1, 5, 99, 345 };
            foreach (var number in l)
            {
                BigInteger power = Power(number, e);
                BigInteger rest = power % n;
                Console.WriteLine(rest);
            }
        }

        static BigInteger Power(int num, int e)
        {
            BigInteger myNum = (BigInteger)num;
            var licznik = 1;
            while (licznik != e)
            {
                myNum = myNum * myNum;
                licznik++;
            }

            return myNum;
        }
    }
}

// program do szyfrowania
// wczytuje tekst wypisuje każ☺dą litere zakodowaną jako liczba hex ale pomiędzy są spacje
// parametry: 3 liczby całkowite
// wypisuej czwartą liczbę całkowitą
// 