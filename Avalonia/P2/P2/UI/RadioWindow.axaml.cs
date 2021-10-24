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
    public class RadioWindow : Window
    {
        public RadioWindow()
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
            List<Radios> lRadios = new List<Radios>();
            RegistroReparaciones lRepa = XmlRegistroReparaciones.RecuperaXml();
            var edSerie = this.FindControl<TextBox>("EdSerie");
            var edModelo = this.FindControl<TextBox>("EdModelo");
            var edCosto = this.FindControl<TextBox>("EdCosto");
            var cbBanda = this.FindControl<ComboBox>("CbBanda");
            var edRepa = this.FindControl<TextBox>("EdRepa");
            
            int serie;
            int costo;
            double repa;

            if (!int.TryParse(edSerie.Text, out serie))
            {
                serie = 0;
            }
            
            if (!int.TryParse(edCosto.Text, out costo))
            {
                costo = 0;
            }
            
            if (!double.TryParse(edRepa.Text, out repa))
            {
                repa = 0;
            }
            
            ComboBoxItem? cbi = (ComboBoxItem)cbBanda.SelectedItem!;
            string? banda = cbi.Content.ToString();
            
            lRadios.Add(new Radios(serie, edModelo.Text, banda!));
            lRepa.Add(Reparacion.Crea(lRadios[0], costo, repa));

            new XmlRegistroReparaciones(lRepa).GuardaXml();
            
            try
            {
                new MessageBox("Reparación insertada").ShowDialog(this);
            }
            catch (NullReferenceException)
            {
                new MessageBox("No se han introducido los datos, \no faltan datos por añadir.").ShowDialog(this);
            }
        }
    }
}