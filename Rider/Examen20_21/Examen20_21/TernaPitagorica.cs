using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Examen20_21
{
    public class TernaPitagorica
    {
        TernaPitagorica(int a, int b)
        {
            int c = (int) Math.Sqrt((a * a) + (b * b));
            
            this.terminos = new int[3];
            this.terminos[0] = a;
            this.terminos[1] = b;
            this.terminos[2] = c;
        }

        public int Get(int i)
        {
            if (i < 0 || i > this.terminos.Length)
            {
                throw new ArgumentException($"i debe estar entre 0 y 3: {i}");
            }
            
            return this.terminos[i];
        }

        public int this[int i] => this.Get(i);

        public override int GetHashCode()
        {
            return this.terminos[0]
                   + (7 * this.terminos[1])
                   + (11 * this.terminos[2]);
        }

        public override bool Equals(object otro)
        {
            bool toret = false;
            
            if (otro is TernaPitagorica otraTerna)
            {
                toret = (this.terminos[0] == otraTerna[0] 
                         && this.terminos[1] == otraTerna[1]
                         && this.terminos[2] == otraTerna[2]);
            }

            return toret;
        }

        public static bool operator ==(TernaPitagorica t1, TernaPitagorica t2)
        {
            bool toret = false;
            
            if (!(t1 is null))
            {
                toret = t1.Equals(t2);   
            }

            return toret;
        }
        
        public static bool operator !=(TernaPitagorica t1, TernaPitagorica t2)
        {
            bool toret = false;
            
            if (!(t1 is null))
            {
                toret = !(t1.Equals(t2));   
            }
            // return !(t1 == t2);

            return toret;
        }
        
        /*public override string ToString()
        {
            var toret = new StringBuilder();
            var lista = new List<int>(this.terminos);
            
            lista.ForEach(x => {
                toret.Append(x);
                toret.Append(" ");
            });
            return toret.ToString();
            
        }*/
        
        //Con Select
        public override string ToString()
        {
            var toret = new StringBuilder();
            var lista = new List<int>(this.terminos);
            
            var lista2 = 
                lista.Select(x => x.ToString());

            foreach (var s in lista2)
            {
                toret.Append(s);
                toret.Append(' ');
            }

            return toret.ToString();
        }

        private int[] terminos;
        public static TernaPitagorica Crea(int a, int b, int c)
        {
            TernaPitagorica toret;
            
            Debug.Assert(a > 0, "a < 1");
            Debug.Assert(b > 0, "b < 1");
            Debug.Assert(c > 0, "c < 1");
            
            Debug.Assert((a * a) + (b * b) == (c * c), "No es una Terna Pitagórica");
            
            toret = new TernaPitagorica(a, b);
            
            Debug.Assert((toret[0] * toret[0]) + (toret[1] * toret[1]) == (toret[2] * toret[2]), "No es una Terna Pitagórica");

            return toret;
        }
        
    }
}