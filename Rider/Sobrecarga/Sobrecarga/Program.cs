using System;

namespace Sobrecarga
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var p1 = new Producto(12, "Tornillo");
      var p2 = new Producto(11, "Tuerca");
      var p3 = new Producto(12, "Tornillo");
      
      p1.InsertaVenta(100);
      p1.InsertaVenta(35);
      
      //p2.InsertaVenta(31);
      //p2.InsertaVenta(42);
      
      p3.InsertaVenta(100);
      p3.InsertaVenta(35);

      p2 += 31;
      p2 += 42;
      
      Console.WriteLine(p1.ToString());
      
      Console.WriteLine(p1 == p2);

      if ((bool)p1)
      {
        Console.WriteLine("P1 Tiene ventas");
      }
      else
      {
        Console.WriteLine("P1 No tiene ventastas");
      }
      
    }
  }
}