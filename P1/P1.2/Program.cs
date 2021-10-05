using System;

/*Sucesión de Fibonacci*/

namespace P1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBIENVENIDO");
            Console.WriteLine("**********");

            int a, b, auxiliar, limite;

            Console.WriteLine("Introduce el límite del Fibonacci: ");
            limite = int.Parse(Console.ReadLine());
            a = 0;
            b = 1;
            Console.WriteLine(a);
            for (int i = 0; i < limite; i++){
                auxiliar = a;
                a = b;
                b = auxiliar + a;
                Console.WriteLine(a);
            }

        }
    }
}
