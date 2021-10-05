namespace Comentario {

    /// <summary>
    /// Un comentario sobre un texto.
    /// </summary>
    /// <seealso cref="XComentario"/>
    public abstract class Comentario {
        
        /// <summary>
        /// Crea un nuevo comentario.
        /// </summary>
        /// <param name="pos">La posición dentro del texto</param>
        /// <param name="aut">El texto del comentario</param>
        /// <param name="txt">El autor del comentario</param>
        protected Comentario(int pos, string aut, string txt)
        {
            this.Posicion = pos;
            this.Autor = aut;
            this.Texto = txt;
        }

        public int Posicion
        {
            get;
        }
        
        public string Autor
        {
            get;
        }

        protected string Texto
        {
            get;
            set;
        }

        public virtual string Contenido
        {
            get
            {
                return this.Texto;
            }
        }
    
        /// <summary>
        /// Convierte un objeto <see cref="Comentario"/>
        /// a texto
        /// </summary>
        /// <returns>Un string con toda la información.</returns>
        public override string ToString()
        {
            return string.Format("{0:00}: ({1}) ",
                this.Posicion,
                this.Autor);
        }
    }
}