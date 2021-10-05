using System;

namespace Comentario
{
    public class ComentarioImagen : Comentario
    {
        public ComentarioImagen(int pos, string aut, string url) : base(pos, aut, url)
        {
            
        }

        public string URL
        {
            get
            {
                return base.Texto;
            }
            set
            {
                if (!value.StartsWith("http://"))
                {
                    throw new ArgumentException("No es URL");
                }
                base.Texto = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Comprueba la URL: " + this.URL;
        }
    }
}