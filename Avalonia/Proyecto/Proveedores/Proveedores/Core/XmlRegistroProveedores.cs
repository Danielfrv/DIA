using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Proveedores.Core
{
    public class XmlRegistroProveedores
    {
        public const string ArchivoXml = "proveedores.xml";
        public const string EtqProveedores = "proveedores";
        public const string EtqProveedor = "proveedor";
        public const string EtqCif = "cif";
        public const string EtqNombre = "nombre";
        public const string EtqDirFactu = "direccion_facturacion";
        public const string EtqCodigos = "codigos_piezas";

        public XmlRegistroProveedores(RegistroProveedores prov)
        {
            this.Prov = prov;
        }

        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        private void GuardaXml(string ArchivoXml)
        {
            var doc = new XDocument();
            var root = new XElement(EtqProveedores);

            foreach (Proveedor pr in Prov)
            {
                try
                {
                    root.Add(
                        new XElement(EtqProveedor,
                            new XAttribute(EtqCif, pr.Cif),
                            new XAttribute(EtqNombre, pr.Nombre),
                            new XAttribute(EtqDirFactu, pr.DirFacturacion),
                            new XAttribute(EtqCodigos, pr.GetCodigos())));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
                
            doc.Add(root);
            doc.Save(ArchivoXml);
        }

        public static RegistroProveedores RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }
        
        public static RegistroProveedores RecuperaXml(string f)
        {
            var toret = new RegistroProveedores();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null && doc.Root.Name == EtqProveedores)
                {
                    var proveedores = doc.Root.Elements(EtqProveedor);
                    foreach (XElement provXml in proveedores)
                    {
                        toret.Add(new Proveedor((string) provXml.Attribute(EtqCif)!,
                            (string) provXml.Attribute(EtqNombre)!,
                            (string) provXml.Attribute(EtqDirFactu)!,
                            provXml.Attribute(EtqCodigos).Value.Split(", ").ToList()));
                    } 
                }
                
            }
            catch (XmlException)
            {
                var error = System.Console.Error;
                System.Console.WriteLine(error);
                toret.Clear();
            }
            catch (IOException)
            {
                var error = System.Console.Error;
                System.Console.WriteLine(error);
                toret.Clear();
            }

            return toret;
        }
        
        public RegistroProveedores Prov
        {
            get;
            set;
        }
        
    }
    
}