using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Proveedores.Core;
using Proveedores.UI;

namespace Proveedores
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var btSelect = this.FindControl<Button>("BtInsert");
            btSelect.Click += (_,_) => this.OnInsert();
            var btView = this.FindControl<Button>("BtView");
            btView.Click += (_,_) => this.OnView();
            this.Closed += (_, _) => this.OnClose();

            this.RegistroProveedores = XmlRegistroProveedores.RecuperaXml();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnInsert()
        {
            List<Proveedor> lProv = new List<Proveedor>();
            List<string> lCods;

            var edCif = this.FindControl<TextBox>("EdCif");
            var edNombre = this.FindControl<TextBox>("EdNombre");
            var edDirFactu = this.FindControl<TextBox>("EdDirFactu");
            var edCodigo = this.FindControl<TextBox>("EdCodigo");
            string[] cods = edCodigo.Text.Split(", ");
            List<string> codPiezas = new List<string>(cods);

            lCods = new List<string>(cods);
            
            this.RegistroProveedores.Add(new Proveedor(edCif.Text, edNombre.Text, edDirFactu.Text, codPiezas));

            new MessageWindow(RegistroProveedores.ToString()).ShowDialog(this);

        }

        private void OnView()
        {
            string datos = "";
            foreach (Proveedor prov in this.RegistroProveedores)
            {
                datos = datos + "\n" + prov.ToString();
            }
            new MessageWindow(datos).ShowDialog(this);
        }

        void OnClose()
        {
            new XmlRegistroProveedores(this.RegistroProveedores).GuardaXml();
        }

        public RegistroProveedores RegistroProveedores
        {
            get;
            set;
        }
    }
}