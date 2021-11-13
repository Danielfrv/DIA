using System.Collections.Generic;
using System.Linq;

namespace Proveedores.Core
{
    public class Proveedor
    {
        public List<string> codigosPiezas = new List<string>();
        public Proveedor(string cif, string nombre, string dirFacturacion, List<string> codigosPiezas)
        {
            this.Cif = cif;
            this.Nombre = nombre;
            this.DirFacturacion = dirFacturacion;
            this.codigosPiezas = codigosPiezas;
        }
        
        public Proveedor(string cif, string nombre, string dirFacturacion)
        {
            this.Cif = cif;
            this.Nombre = nombre;
            this.DirFacturacion = dirFacturacion;
            this.codigosPiezas = new List<string>();
        }

        public void Add(string codigo)
        {
            this.codigosPiezas.Add(codigo);
        }

        public void AddRange(List<string> cods)
        {
            foreach (string c in cods)
            {
                this.codigosPiezas.Add(c);
            }
        }

        public string GetCodigos()
        {
            string toret = "";
            
                foreach (string c in this.codigosPiezas)
                {
                    if (c == this.codigosPiezas.Last())
                    {
                        toret = toret + c;
                    }
                    else
                    {
                        toret = toret + c + "  " ;
                    }
                }

            return toret;
        }

        public string Cif
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string DirFacturacion
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "CIF: " + this.Cif
                + "\nNombre: " + this.Nombre
                + "\nDirección de facturación: " + this.DirFacturacion
                + "\nCódigos de Piezas: "+ GetCodigos();
        }
    }
}