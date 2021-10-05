namespace Comentario {
    using System.Collections.Generic;

    public class ListaComentarios {
        
        public ListaComentarios(){
            this.listaComentarios = new List<Comentario>();
        }

        /// <summary>
        /// Inserta un nuevo comentario.
        /// </summary>
        /// <param name="c">Objeto de la clase <see cref="Comentario"/>.</param>
        
        public void Inserta(Comentario c)
        {
            this.listaComentarios.Add(c);
        }
    
        /// <summary>
        /// Número de Comentarios
        /// </summary>
        public int Num
        {
            get
            {
                return this.listaComentarios.Count;
            }
        }
        
        /// <summary>
        /// Obtiene los comentarios como un enumerable
        /// </summary>

        public IEnumerable<Comentario> Todos
        {
            get
            {
                return new List<Comentario>(this.listaComentarios);
            }
        }

        /// <summary>
        /// Devuelve los comentarios como un array
        /// </summary>
        
        public Comentario[] ArrayTodos
        {
            get
            {
                return this.listaComentarios.ToArray();
            }
        }

        private List<Comentario> listaComentarios;

    }
    
}