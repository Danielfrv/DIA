using System;

/*Programa de atinar el número random*/
namespace P1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBIENVENIDO!");
            Console.WriteLine("***********");

            Random rand = new Random();
            string entrada;
            int randInt;
            int numUsr;
            int intentos = 0;

            do{
                randInt = rand.Next(0, 20);
                do{
                    do{
                        Console.WriteLine("Introduce tu selección (0-20): ");
                        entrada = Console.ReadLine().Trim();
                        intentos++;
                    }while (!int.TryParse(entrada, out numUsr));

                    if (numUsr < randInt){
                        Console.WriteLine("Más alto...");
                        Console.WriteLine("Este es tu intento: " + intentos);

                    }else if (numUsr > randInt){
                        Console.WriteLine("Más bajo...");
                        Console.WriteLine("Este es tu intento: " + intentos);
                    }

                }while (numUsr != randInt);

            Console.WriteLine("Acertaste!");
            Console.WriteLine("Tus intentos totales fueron: " + intentos);
            Console.WriteLine("Jugar otra vez (S/N): ");
            entrada = Console.ReadLine().Trim().ToUpper();

            }while ( entrada[ 0 ] == 'S');
        }
    }
}
