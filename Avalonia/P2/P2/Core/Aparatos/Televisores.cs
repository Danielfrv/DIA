namespace P2.Aparatos
{
    public class Televisores : Aparato
    {
        public const int costo = 10;
        public Televisores(int n_serie, string modelo, int pulgadas) : base(n_serie, modelo, costo)
        {
            this.Pulgadas = pulgadas;
        }

        public int Pulgadas
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "\nTelevisor" + "\n" + base.ToString() + "\nPulgadas: " + Pulgadas;
        }
    }
}