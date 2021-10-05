namespace Comentario
{
    public class ComentarioTexto: Comentario
    {
        public ComentarioTexto(int pos, string txt, string aut): base(pos, aut, txt)
        {
            
        }

        public string Texto
        {
            get
            {
                return base.Texto;
            }

            set
            {
                base.Texto = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\"{this.Texto}\"";
        }
    }
}