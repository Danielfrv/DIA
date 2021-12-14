using System;

namespace Examen20_21
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var t1 = TernaPitagorica.Crea(3, 4, 5);
            var t2 = TernaPitagorica.Crea(3, 4, 5);
            var t3 = TernaPitagorica.Crea(6, 8, 10);
            //var t4 = TernaPitagorica.Crea(1, 2, 3);
            
            System.Console.WriteLine($"t1.Get(0) == t1[0] == {t1.Get(0)} == {t1[0]}");
            System.Console.WriteLine($"t1.Get(1) == t1[1] == {t1.Get(1)} == {t1[1]}");
            System.Console.WriteLine($"t1.Get(2) == t1[2] == {t1.Get(2)} == {t1[2]}");
            
            System.Console.WriteLine($"t2.Get(0) == t2[0] == {t2.Get(0)} == {t2[0]}");
            System.Console.WriteLine($"t2.Get(1) == t2[1] == {t2.Get(1)} == {t2[1]}");
            System.Console.WriteLine($"t2.Get(2) == t2[2] == {t2.Get(2)} == {t2[2]}");
            
            System.Console.WriteLine($"t3.Get(0) == t3[0] == {t3.Get(0)} == {t3[0]}");
            System.Console.WriteLine($"t3.Get(1) == t3[1] == {t3.Get(1)} == {t3[1]}");
            System.Console.WriteLine($"t3.Get(2) == t3[2] == {t3.Get(2)} == {t3[2]}");
            
            Console.WriteLine($"t1 == t2 = {t1 == t2}");
            Console.WriteLine($"t1 == t3 = {t1 == t3}");
            
            Console.WriteLine($"t1 eq t2 = {t1.Equals(t2)}");
            Console.WriteLine($"t1 eq t3 = {t1.Equals(t3)}");
            
            Console.WriteLine($"t1 HashCode = {t1.GetHashCode()}");
            Console.WriteLine($"t2 HashCode = {t2.GetHashCode()}");
            Console.WriteLine($"t3 HashCode = {t3.GetHashCode()}");
            
            Console.WriteLine(t1);
        }
    }
}