using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using P2.Aparatos;
using P2.Core;

namespace P2.UI
{
    public class AdaptadorWindow : Window
    {
        public AdaptadorWindow()
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
            List<AdaptadorTDT> lAdap = new List<AdaptadorTDT>();
            RegistroReparaciones lRepa = XmlRegistroReparaciones.RecuperaXml();
            var edSerie = this.FindControl<TextBox>("EdSerie");
            var edModelo = this.FindControl<TextBox>("EdModelo");
            var edCosto = this.FindControl<TextBox>("EdCosto");
            var cbGraba = this.FindControl<ComboBox>("CbGraba");
            var edTGraba = this.FindControl<TextBox>("EdTGraba");
            var edRepa = this.FindControl<TextBox>("EdRepa");
            
            int serie;
            int costo;
            int tGraba;
            double repa;

            if (!int.TryParse(edSerie.Text, out serie))
            {
                serie = 0;
            }
            
            if (!int.TryParse(edCosto.Text, out costo))
            {
                costo = 0;
            }
            
            if (!int.TryParse(edTGraba.Text, out tGraba))
            {
                tGraba = 0;
            }
            
            if (!double.TryParse(edRepa.Text, out repa))
            {
                repa = 0;
            }

            if (cbGraba.SelectedIndex == 1)
            {
                ComboBoxItem? cbi2 = (ComboBoxItem)cbGraba.SelectedItem!;
                string? graba = cbi2.Content.ToString();
                
                lAdap.Add(new AdaptadorTDT(serie, edModelo.Text, graba!, 0));
            }
            else
            {
                ComboBoxItem cbi2 = (ComboBoxItem)cbGraba.SelectedItem!;
                string? graba = cbi2.Content.ToString();
                
                lAdap.Add(new AdaptadorTDT(serie, edModelo.Text, graba!, tGraba));
            }
            
            lRepa.Add(Reparacion.Crea(lAdap[0], costo, repa));
            
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