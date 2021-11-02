using System.Collections.Generic;

namespace Proveedores.Core
{
    public class Proveedor
    {
        public Proveedor(string cif, string nombre, string dirFacturacion)
        {
            this.Cif = cif;
            this.Nombre = nombre;
            this.DirFacturacion = dirFacturacion;
            this.Codigos = new List<string>();
        }

        public void Add(string codigo)
        {
            this.Codigos.Add(codigo);
        }

        public void AddRange(List<string> cods)
        {
            foreach (string c in cods)
            {
                this.Codigos.Add(c);
            }
        }

        public string GetCodigos()
        {
            string toret = "";

            foreach (string c in this.Codigos)
            {
                toret = toret + c + " ; ";
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

        public List<string> Codigos
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