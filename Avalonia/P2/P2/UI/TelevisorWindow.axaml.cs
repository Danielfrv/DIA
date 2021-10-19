using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using P2.Aparatos;
using P2.Core;

namespace P2.UI
{
    public class TelevisorWindow : Window
    {
        public TelevisorWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            var btInsert = this.FindControl<Button>("BtInsert");
                        btInsert.Click += (_, _) => this.OnInsert();
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        private void OnInsert()
        {
            List<Televisores> lTele = new List<Televisores>();
            List<Reparacion> lRepa = new List<Reparacion>();
            var edSerie = this.FindControl<TextBox>("EdSerie");
            var edModelo = this.FindControl<TextBox>("EdModelo");
            var edCosto = this.FindControl<TextBox>("EdCosto");
            var edPulgadas = this.FindControl<TextBox>("EdPulgadas");
            var edRepa = this.FindControl<TextBox>("EdRepa");
            
            int serie;
            int costo;
            int pulgadas;
            double repa;

            if (!int.TryParse(edSerie.Text, out serie))
            {
                serie = 0;
            }
            
            if (!int.TryParse(edCosto.Text, out costo))
            {
                costo = 0;
            }
            
            if (!int.TryParse(edPulgadas.Text, out pulgadas))
            {
                pulgadas = 0;
            }
            
            if (!double.TryParse(edRepa.Text, out repa))
            {
                repa = 0;
            }
            
            lTele.Add(new Televisores(serie, edModelo.Text, costo, pulgadas));
            lRepa.Add(Reparacion.Crea(lTele[0], costo, repa));
            
            new XmlRegistroReparaciones(lRepa).GuardaXml();

            try
            {
                new MessageBox(lRepa[0].ToString()).ShowDialog(this);
            }
            catch (NullReferenceException)
            {
                new MessageBox("No se han introducido los datos, \no faltan datos por añadir.").ShowDialog(this);
            }

        }
    }
}