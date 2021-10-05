using System;

namespace P1._7{
    class Punto{

        public static Punto Centro = new Punto(0,0);

        public Punto(int x, int y){
            this.X = x;
            this.Y = y;
        }

        public static String DevuelveCentro(){
            return Centro.ToString();
        }

        public int X { get; }
        public int Y { get; }
        
        public override string ToString(){

            return string.Format("({0}, {1})", this.X, this.Y);

        }

    }
}