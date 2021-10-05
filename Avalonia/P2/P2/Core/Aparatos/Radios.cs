namespace P2.Aparatos
{
    public class Radios : Aparato
    {
        public Radios(int n_serie, string modelo, int costo, string banda) : base(n_serie, modelo, costo)
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
            return "\nRadio: " + "\n" +  base.ToString() + "\nBanda: " + Banda;
        }
    }
}