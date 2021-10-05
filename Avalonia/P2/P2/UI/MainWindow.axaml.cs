using System;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using P2.Aparatos;
using P2.Reparaciones;

namespace P2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            var btInsert = this.FindControl<Button>("BtInsert");
            btInsert.Click += (_,_) => this.OnInsert();
            
            //var btView = this.FindControl<Button>("BtView");
            //tView.Click += (_,_) => this.OnView();
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void OnInsert()
        {
            var cbAparato = this.FindControl<ComboBox>("CbAparato");
            var edSerie = this.FindControl<TextBox>("EdSerie");
            var edModelo = this.FindControl<TextBox>("EdModelo");
            var edCosto = this.FindControl<TextBox>("EdCosto");
            var edTiempo = this.FindControl<TextBox>("EdTiempo");

            double costo;
            double t_repa;
            int serie;
            bool esComp;
            Aparato Ap;

            if (!Double.TryParse(edTiempo.Text, out t_repa))
            {
                t_repa = 0;
            }

            costo = Convert.ToInt32(edCosto.Text);
            
            serie = Convert.ToInt32(edSerie.Text);
            
            //Necesitamos comprobar en cada caso el tiempo de reparación, para poder establecer de qué tipo se trata.
            //Hacer un método que compruebe qué reparación es, para ser llamado a la hora de crear las reparaciones

            switch (cbAparato.SelectedIndex)
            {
                case 0:
                    esComp = esCompleja(t_repa);
                    if (esComp)
                    {
                        Ap = new Radios(serie, edModelo.Text, costo);
                        new ReparacionCompleja(cbAparato.SelectedItem, costo, t_repa);
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            
        }

        private bool esCompleja(double t_repa)
        {
            if(t_repa > 0)
            {
                if (t_repa <= 1)
                {
                    return true;
                }
                if (t_repa > 1)
                {
                    return false;
                }
            }
            return false;
        }

    }
}