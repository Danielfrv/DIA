namespace P2.Core
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using P2.Aparatos;
    using P2.Reparaciones;

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

        public XmlRegistroReparaciones(RegistroReparaciones RegRepa)
        {
            this.RegRepa = RegRepa;
        }

        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        private void GuardaXml(string ArchivoXml)
        {
            var doc = new XDocument();
            var root = new XElement(EtqReparaciones);

            foreach (Reparacion repa in RegRepa)
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
                    
                    if (repa.Ap.ToString().Split('\n')[1] == "Televisor")
                    {
                        Televisores t = (Televisores) repa.Ap;
                        root.Add(
                            new XElement(EtqReparacion,
                                new XAttribute(EtqTipoRepa, repa.GetType().ToString().Split('.')[2]),
                                new XElement(EtqAparato, repa.Ap.ToString().Split('\n')[1],
                                    new XAttribute(EtqSerie, repa.Ap.N_serie),
                                    new XAttribute(EtqPrecio, repa.Ap.Costo),
                                    new XAttribute(EtqModelo, repa.Ap.Modelo),
                                    new XAttribute("Pulgadas", t.Pulgadas),
                                    new XAttribute(EtqPrecioMediaHora, repa.Precio_media_hora),
                                    new XAttribute(EtqPrecioTotal, repa.Precio * repa.T_reparacion),
                                    new XAttribute(EtqTReparacion, repa.T_reparacion))));
                    }
                    
                    if (repa.Ap.ToString().Split('\n')[1] == "DVD")
                    {
                        DVD d = (DVD) repa.Ap;
                        root.Add(
                            new XElement(EtqReparacion,
                                new XAttribute(EtqTipoRepa, repa.GetType().ToString().Split('.')[2]),
                                new XElement(EtqAparato, repa.Ap.ToString().Split('\n')[1],
                                    new XAttribute(EtqSerie, repa.Ap.N_serie),
                                    new XAttribute(EtqPrecio, repa.Ap.Costo),
                                    new XAttribute(EtqModelo, repa.Ap.Modelo),
                                    new XAttribute("Blu-Ray", d.Blu_ray),
                                    new XAttribute("Graba", d.Graba),
                                    new XAttribute("T_Grabación", d.T_grabacion),
                                    new XAttribute(EtqPrecioMediaHora, repa.Precio_media_hora),
                                    new XAttribute(EtqPrecioTotal, repa.Precio * repa.T_reparacion),
                                    new XAttribute(EtqTReparacion, repa.T_reparacion))));
                    }
                    
                    if (repa.Ap.ToString().Split('\n')[1] == "Adaptador TDT")
                    {
                        AdaptadorTDT a = (AdaptadorTDT) repa.Ap;
                        root.Add(
                            new XElement(EtqReparacion,
                                new XAttribute(EtqTipoRepa, repa.GetType().ToString().Split('.')[2]),
                                new XElement(EtqAparato, repa.Ap.ToString().Split('\n')[1],
                                    new XAttribute(EtqSerie, repa.Ap.N_serie),
                                    new XAttribute(EtqPrecio, repa.Ap.Costo),
                                    new XAttribute(EtqModelo, repa.Ap.Modelo),
                                    new XAttribute("Graba", a.Graba),
                                    new XAttribute("T_Max_Grabación", a.T_max_grabacion),
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

        public static RegistroReparaciones RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }

        public static RegistroReparaciones RecuperaXml(string f)
        {
            var toret = new RegistroReparaciones();

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
                                        (string) repaXml.Element(EtqAparato)!.Attribute("Banda")!), 
                                    (int) repaXml.Element(EtqAparato)!.Attribute(EtqPrecio)!, 
                                    (double) repaXml.Element(EtqAparato)!.Attribute(EtqTReparacion)!));
                                break;
                            case "Televisor":
                                toret.Add(Reparacion.Crea(new Televisores(
                                        (int) repaXml.Element(EtqAparato)!.Attribute(EtqSerie)!, 
                                        (string) repaXml.Element(EtqAparato)!.Attribute(EtqModelo)!,
                                        (int) repaXml.Element(EtqAparato)!.Attribute("Pulgadas")!), 
                                    (int) repaXml.Element(EtqAparato)!.Attribute(EtqPrecio)!, 
                                    (double) repaXml.Element(EtqAparato)!.Attribute(EtqTReparacion)!));
                                break;
                            case "DVD":
                                toret.Add(Reparacion.Crea(new DVD(
                                        (int) repaXml.Element(EtqAparato)!.Attribute(EtqSerie)!, 
                                        (string) repaXml.Element(EtqAparato)!.Attribute(EtqModelo)!,
                                        (string) repaXml.Element(EtqAparato)!.Attribute("Blu-Ray")!,
                                        (string) repaXml.Element(EtqAparato)!.Attribute("Graba")!,
                                        (int) repaXml.Element(EtqAparato)!.Attribute("T_Grabación")!), 
                                    (int) repaXml.Element(EtqAparato)!.Attribute(EtqPrecio)!, 
                                    (double) repaXml.Element(EtqAparato)!.Attribute(EtqTReparacion)!));
                                break;
                            case "Adaptador TDT":
                                toret.Add(Reparacion.Crea(new AdaptadorTDT(
                                        (int) repaXml.Element(EtqAparato)!.Attribute(EtqSerie)!, 
                                        (string) repaXml.Element(EtqAparato)!.Attribute(EtqModelo)!,
                                        (string) repaXml.Element(EtqAparato)!.Attribute("Graba")!,
                                        (int) repaXml.Element(EtqAparato)!.Attribute("T_Max_Grabación")!), 
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

        public RegistroReparaciones RegRepa { get; }
    }
}