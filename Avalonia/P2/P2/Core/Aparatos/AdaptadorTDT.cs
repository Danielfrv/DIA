namespace P2.Aparatos
{
    public class AdaptadorTDT : Aparato
    {
        public const int costo = 5;
        public AdaptadorTDT(int n_serie, string modelo, string graba, int t_max_grabacion) : base(n_serie, modelo, costo)
        {
            this.Graba = graba;
            comprobarGraba(graba, t_max_grabacion);
        }

        private void comprobarGraba(string graba, int t_max_grabacion)
        {
            if (graba == "Si")
            {
                this.T_max_grabacion = t_max_grabacion;
            }
        }
        
        public string Graba
        {
            get;
            set;
        }

        public int T_max_grabacion
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return "\nAdaptador TDT" + "\n" + base.ToString() + "\nGraba: " + Graba.ToString()
                   + "\nTiempo máximo de grabación: " + T_max_grabacion;
        }
    }
}