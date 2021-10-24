namespace P2.Aparatos
{
    public class Radios : Aparato
    {
        public const int costo = 5;
        public Radios(int n_serie, string modelo, string banda) : base(n_serie, modelo, costo)
        {
            this.Banda = banda;
        }

        public string Banda
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "\nRadio" + "\n" +  base.ToString() + "\nBanda: " + Banda;
        }
    }
}