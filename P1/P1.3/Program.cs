using System;

namespace P1._3
{
    class Program
    {
        static void Main(string[] args)
        {   
            string palabra;
            int lenPalabra;
            bool esPalindroma = true;

            Console.WriteLine("Introduce una palabra: ");
            palabra = Console.ReadLine().ToLower();
            palabra = palabra.Replace(" ", "").Replace("?", "").Replace("¿", "").Replace(",","");

            lenPalabra = palabra.Length;

            for (int i = 0; i < lenPalabra; i++)
            {
                if (palabra[i] != palabra[(lenPalabra - 1) - i]){
                    esPalindroma = false; 
                    break;
                }
            }
            if (esPalindroma)
            {
                Console.WriteLine("T");
            }
            else
            {
                Console.WriteLine("F");
            }
        }
    }
}
