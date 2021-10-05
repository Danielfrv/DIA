using System;
using System.Collections.Generic;
using System.Linq;

namespace P1._7
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Punto> puntos = new List<Punto>();
            int num_puntos = 2;
            int x;
            int y;

            for (int i = 1; i < num_puntos + 1; i++){
                Console.WriteLine("\nPunto " + i + "\n");
                Console.Write("Coordenada X: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Coordenada Y: ");
                y = Convert.ToInt32(Console.ReadLine());
                puntos.Add(new Punto(x, y));
            }

            var linea = new Linea(puntos.First(), puntos.Last());

            Console.WriteLine("\nVolcado: \n");
            foreach (Punto punto in puntos){
                Console.WriteLine(punto.ToString());
            }
            // Console.WriteLine(linea.ToString());

            List<Linea> lines = new List<Linea>();
            for(int i = 0; i < puntos.Count; i+=2){
                lines.Add(new Linea(puntos[i], puntos[i+1]));
            }

            foreach (Linea line in lines){
                Console.WriteLine(line.ToString());
            }

            // var punto1 = new Punto(1,2);
            // var punto2 = new Punto(3,4);
            // var linea1 = new Linea(punto1, punto2);
            // Console.WriteLine(linea1.ToString());
        }
    }
}