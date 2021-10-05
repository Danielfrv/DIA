namespace Comentario
{
    
    using System;
    using System.Xml.Linq;
    
    public class XComentario
    {

        public XComentario(Comentario c)
        {
            this.Comentario = c;
        }

        public void SaveToXml(string nf)
        {
            XElement raiz = this.ToXElement();
            
            raiz.Save(nf);
        }

        XElement ToXElement()
        {
            
            
            return new XElement("Comentario",
                new XElement("Posicion", this.Comentario.Posicion),
                new XElement("Autor", this.Comentario.Autor),
                new XElement("Texto", this.Comentario.Contenido)
                );
        }

        public Comentario Comentario
        {
            get;
        }

    }
}