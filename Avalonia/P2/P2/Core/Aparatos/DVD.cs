using System;
using Microsoft.VisualBasic;

namespace P2.Aparatos
{
    public class DVD : Aparato
    {
        public DVD(int n_serie, string modelo, int costo, string blu_ray, string graba, int t_grabacion) : base(n_serie, modelo, costo)
        {
            this.Blu_ray = blu_ray;
            this.Graba = graba;
            this.T_grabacion = t_grabacion;
        }

        public string Blu_ray
        {
            get;
            set;
        }

        public string Graba
        {
            get;
            set;
        }

        public int T_grabacion
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return "\nDVD: " + "\n" +  base.ToString() + "\nBlu-ray: " + Blu_ray.ToString() + "\nGraba: " 
                   + Graba.ToString() + "\nTiempo de grabación: " + T_grabacion;
        }
    }
}