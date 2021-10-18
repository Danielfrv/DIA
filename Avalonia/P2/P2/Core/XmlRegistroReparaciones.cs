using P2.Aparatos;
using P2.Reparaciones;

namespace P2.Core
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Collections.Generic;

    public class XmlRegistroReparaciones
    {
        public const string ArchivoXml = "reparaciones.xml";
        private const string EtqReparaciones = "reparaciones";
        private const string EtqReparacion = "reparacion";
        private const string EtqAparato = "aparato";
        private const string EtqPrecio = "precio";
        private const string EtqPrecioMediaHora = "precio_media_hora";
        private const string EtqTReparacion = "t_reparacion";
        private const string EtqPrecioTotal = "precio_total";
        private const string EtqModelo = "modelo";
        private const string EtqSerie = "serie";
        private const string EtqTipoRepa = "tipo_reparacion";

        public XmlRegistroReparaciones(List<Reparacion> lRepa)
        {
            this.lRepa = lRepa;
        }

        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        private void GuardaXml(string ArchivoXml)
        {
            var doc = new XDocument();
            var root = new XElement(EtqReparaciones);

            foreach (Reparacion repa in lRepa)
            {
                try
                {
                    if (repa.Ap.ToString().Split('\n')[1] == "Radio")
                    {
                        Radios r = (Radios) repa.Ap;
                        root.Add(
                            new XElement(EtqReparacion,
                                new XAttribute(EtqTipoRepa, repa.GetType().ToString().Split('.')[2]),
                                new XElement(EtqAparato, repa.Ap.ToString().Split('\n')[1],
                                    new XAttribute(EtqSerie, repa.Ap.N_serie),
                                    new XAttribute(EtqPrecio, repa.Ap.Costo),
                                    new XAttribute(EtqModelo, repa.Ap.Modelo),
                                    new XAttribute("Banda", r.Banda),
                                    new XAttribute(EtqPrecioMediaHora, repa.Precio_media_hora),
                                    new XAttribute(EtqPrecioTotal, repa.Precio * repa.T_reparacion),
                                    new XAttribute(EtqTReparacion, repa.T_reparacion))));
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error" + e.Message);
                }

            }

            doc.Add(root);
            doc.Save(ArchivoXml);
        }

        public static List<Reparacion> RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

        public static List<Reparacion> RecuperaXml(string f)
        {
            var toret = new List<Reparacion>();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null && doc.Root.Name == EtqReparaciones)
                {
                    var reparaciones = doc.Root.Elements(EtqReparacion);

                    foreach (XElement repaXml in reparaciones)
                    {
                        switch (repaXml.Element(EtqAparato)!.Value)
                        {
                            case "Radio":
                                toret.Add(Reparacion.Crea(new Radios(
                                        (int) repaXml.Element(EtqAparato)!.Attribute(EtqSerie)!, 
                                        (string) repaXml.Element(EtqAparato)!.Attribute(EtqModelo)!, 
                                        (int) repaXml.Element(EtqAparato)!.Attribute(EtqPrecio)!, 
                                        (string) repaXml.Element(EtqAparato)!.Attribute("Banda")!), 
                                    (int) repaXml.Element(EtqAparato)!.Attribute(EtqPrecio)!, 
                                    (double) repaXml.Element(EtqAparato)!.Attribute(EtqTReparacion)!));
                                break;
                        }
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

        /*private static List<Reparacion> RecuperaXml(string f)
        {
            var toret = new List<Reparacion>();

            try
            {
                var doc = XDocument.Load(f);
                string rootTag = doc?.Root?.Name.ToString() ?? "";

                if (doc?.Root != null && rootTag == EtqReparacion)
                {
                    var reparacion = doc.Root.Elements(EtqReparacion);

                    foreach (XElement repaXml in reparacion)
                    {
                        string sustPiezas = (string?) repaXml.Element(EtqSustPiezas) ?? "SUST";
                        Aparato aparato = repaXml.Element(EtqAparato);
                        int precio = (int?) repaXml.Element(EtqPrecio) ?? 0;
                        string precioMediaHora = (string?) repaXml.Element(EtqPrecioMediaHora) ?? "PRECIO_MED";
                        double tReparacion = (double?) repaXml.Element(EtqTReparacion) ?? 0.0;
                        toret.Add(Reparacion.Crea(aparato, precio, tReparacion));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return toret;
        }*/

        public List<Reparacion> lRepa { get; }
    }
}