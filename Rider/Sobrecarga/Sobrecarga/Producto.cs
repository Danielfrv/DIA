using System;
using System.Collections.Generic;
using System.Text;

namespace Sobrecarga
{
    public class Producto
    {

        public Producto(int codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.ventas = new List<double>(12);
        }

        public int Codigo
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }
        
        
        /// <summary>
        /// Inserta el valor v en la lista de ventas del producto.
        /// </summary>
        /// <param name="v"></param>
        public void InsertaVenta(double v)
        {
            this.ventas.Add(v);
        }

        public override int GetHashCode()
        {
            int toret = 3 * this.Codigo.GetHashCode()
                        + 7 * this.Nombre.GetHashCode();

            foreach (var x in this.ventas)
            {
                toret += 11 * x.GetHashCode();
            }

            return toret;
        }

        public override bool Equals(object obj)
        {
            bool toret = false;

            if (obj is Producto prod2)
            {
                toret = (this.Codigo == prod2.Codigo
                         && this.Nombre == prod2.Nombre
                         && this.GetNumVentas() == prod2.GetNumVentas());

                if (toret)
                {
                    for (int i = 0; i < this.GetNumVentas(); i++)
                    {
                        if (this.GetVenta(i) != prod2.GetVenta(i))
                        {
                            toret = false;
                            break;
                        }
                    }
                }
            }

            return toret;
        }

        public double GetVenta(int i)
        {
            if (i < 0 || i > this.ventas.Count)
            {
                throw new ArgumentException("Fuera de rango");
            }
            return this.ventas[i];
        }

        public int GetNumVentas()
        {
            return this.ventas.Count;
        }
        
        public double this[int i] => this.GetVenta(i); // Solo usar cuando está el get.

        public static bool operator ==(Producto p1, Producto p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return false;
            }
            return p1.Equals(p2);
        }
        
        public static bool operator !=(Producto p1, Producto p2)
        {
            return false;
        }
        
        public static Producto operator +(Producto p1, double x)
        {
            var toret = new Producto(p1.Codigo, p1.Nombre);
            
            for(int i = 0; i < (int)p1; i++)
            {
                toret.InsertaVenta(p1[i]);
            }
            
            toret.InsertaVenta(x);
            return toret;
        }
        
        /// <summary>
        /// Se sobrecarga el operador (int), es decir, el casteo de enteros.
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static explicit operator int(Producto p1)
        {
            return p1.GetNumVentas();
        }
        
        /// <summary>
        /// Se sobrecarga el operador (bool), es decir, el casteo de bools.
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static explicit operator bool(Producto p1)
        {
            return p1.GetNumVentas() > 0;
        }

        public override string ToString()
        {
            string toret = $"{this.Nombre} ({this.Codigo})";
            var toret_ventas = new StringBuilder();
            //toret += ": " + string.Join(", ", this.ventas);
            
            foreach(double x in this.ventas)
            {
                toret_ventas.AppendLine(x.ToString());
            }

            toret += "\n" + toret_ventas;
            
            return toret;
        }

        private List<double> ventas;
    }
}