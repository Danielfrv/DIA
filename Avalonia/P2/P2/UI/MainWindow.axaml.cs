using System;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using P2.Aparatos;
using P2.Reparaciones;
using P2.UI;

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
            
            var btSelect = this.FindControl<Button>("BtSelect");
            btSelect.Click += (_,_) => this.OnSelect();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void OnSelect()
        {
            var cbAparato = this.FindControl<ComboBox>("CbAparato");

            switch (cbAparato.SelectedIndex)
            {
                case 0:
                    new RadioWindow().ShowDialog(this);
                    break;
                case 1:
                    new TelevisorWindow().ShowDialog(this);
                    break;
                case 2:
                    new DVDWindow().ShowDialog(this);
                    break;
                case 3:
                    new AdaptadorWindow().ShowDialog(this);
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