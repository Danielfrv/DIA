using System;
using P2._1.Aparatos;

namespace P2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var radio1 = new Radios(123, "m1", 5, "AM");
            Console.WriteLine(radio1.ToString());
            
            var tele1 = new Televisores(123, "m1", 5, 45);
            Console.WriteLine(tele1.ToString());
            
            var dvd1 = new DVD(123, "m1", 5, true, true, 15);
            Console.WriteLine(dvd1.ToString());
            
            var tdt1 = new AdaptadorTDT(123, "m1", 5, true, 15);
            Console.WriteLine(tdt1.ToString());

            var rep1 = Reparacion.Crea(radio1, radio1.Costo, 2);
            Console.WriteLine(rep1.ToString());
        }
    }
}