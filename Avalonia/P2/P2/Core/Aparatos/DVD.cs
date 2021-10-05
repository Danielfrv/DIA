using System;
using Microsoft.VisualBasic;

namespace P2.Aparatos
{
    public class DVD : Aparato
    {
        public DVD(int n_serie, string modelo, int costo, bool blu_ray, bool graba, int t_grabacion) : base(n_serie, modelo, costo)
        {
            this.Blu_ray = blu_ray;
            this.Graba = graba;
            ComprobarGraba(graba, t_grabacion);
        }

        private void ComprobarGraba(bool graba, int t_grabacion)
        {
            if (graba)
            {
                this.T_grabacion = t_grabacion;
            }
        }

        public bool Blu_ray
        {
            get;
            set;
        }

        public bool Graba
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