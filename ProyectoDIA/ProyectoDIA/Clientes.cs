using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Text;
using System.Xml;

namespace ProyectoDIA
{
    public class Clientes
    {
        public List<string> codigoPieza=new List<string>();
        public Clientes(int cif, string nombre, string direccion, List<string> codigoPieza)
        {
            Cif = cif;
            Nombre = nombre;
            Direccion = direccion;
            this.codigoPieza = codigoPieza;
            
        }
    
        private int Cif
        {
            get;
            set;
        }

        private string Nombre
        {
            get;
            set;
        }

        private string Direccion
        {
            get;
            set;
        }

      

      
        
        
        public override string ToString()
        {
            int i = 0;
            var builder = new StringBuilder();
            builder.Append("Nombre: ").Append(Nombre).Append("Direccion").Append(Direccion).Append("CIF").Append(Cif);
            while (i<codigoPieza.Count)
            {
                builder.Append("Codigo_piezas").Append(codigoPieza);
            }
            return builder.ToString();
        }

      
// El documento.xml no carga al compilar
 
       public void ConvertirXml()
       {
           XElement l=ListarPiezas(codigoPieza);
           var raiz = new XElement("Clientes",
               new XElement("Cliente",
                   new XAttribute("cif", Convert.ToString(Cif)),
                   new XAttribute("nombre", Nombre),
                   new XAttribute("direccion", Direccion),
                   l));

           raiz.Save( "cliente.xml" );
           //Console.WriteLine(raiz);
          
                    
       }
     
      public XElement ListarPiezas(List<string> array)
      {
          XElement toret = new XElement("Piezas");
          var itr = array.GetEnumerator();
          while (itr.MoveNext())
          {
              XElement x = new XElement("Pieza", itr.Current);
              toret.Add(x);
          }

          return toret;
      }
    }
    

   
}