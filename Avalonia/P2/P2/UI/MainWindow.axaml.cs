using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using P2.Aparatos;
using P2.Core;
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
            
            var btView = this.FindControl<Button>("BtView");
            btView.Click += (_,_) => this.OnView();
            
            var btExit = this.FindControl<Button>("BtExit");
            btExit.Click += (_,_) => this.Close();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnSelect()
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

        private void OnView()
        {
            this.RegistroReparaciones = XmlRegistroReparaciones.RecuperaXml();
            string datos = "";
            foreach (Reparacion repa in RegistroReparaciones)
            {
                datos = datos + "\n" + repa.ToString();
            }
            new MessageBox(datos).ShowDialog(this);
        }

        public RegistroReparaciones RegistroReparaciones { get; set; }
    }
}