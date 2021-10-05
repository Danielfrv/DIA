using System;

namespace P2
{
    public abstract class Aparato
    {
        protected Aparato(int n_serie, string modelo, int costo)
        {
            this.N_serie = n_serie;
            this.Modelo = modelo;
            this.Costo = costo;
        }

        public int N_serie
        {
            get;
            set;
        }

        public string Modelo
        {
            get;
            set;
        }

        public int Costo
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("N. Serie: {0}" +
                                 "\nModelo: {1}" +
                                 "\nCosto por hora: {2} euros",
                                 N_serie, Modelo, Costo);
        }
    }
}