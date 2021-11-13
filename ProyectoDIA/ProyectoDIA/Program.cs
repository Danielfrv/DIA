using System;
using System.Collections.Generic;

namespace ProyectoDIA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> piezas = new List<string>();
            piezas.Add("Coche");
            piezas.Add("bbb");
            piezas.Add("tre");
            piezas.Add("Tren");
            
            Clientes c = new Clientes(4564, "Luis", "A Coruña", piezas);
            c.ConvertirXml();
        }
    }
}
