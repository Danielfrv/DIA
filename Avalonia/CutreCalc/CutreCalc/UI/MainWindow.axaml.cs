using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CutreCalc.Core;

namespace CutreCalc.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var btCalc = this.FindControl<Button>("BtCalc");
            btCalc.Click += (_,_) => this.OnCalc();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void OnCalc()
        {
            var edOp1 = this.FindControl<TextBox>("EdOp1");
            var edOp2 = this.FindControl<TextBox>("EdOp2");
            var edRes = this.FindControl<TextBox>("EdRes");
            var cbOpr = this.FindControl<ComboBox>("CbOpr"); 
            double op1;
            double op2;
            double resultado = 0;

            //op1 = Convert.ToDouble(edOp1.Text);
            if (!double.TryParse(edOp1.Text, out op1))
            {
                op1 = 0;
            } //Mejor forma que la de arriba.
            
            if (!double.TryParse(edOp2.Text, out op2))
            {
                op2 = 0;
            }

            switch (cbOpr.SelectedIndex)
            {
                case 0:
                    resultado = Calculadora.Suma(op1, op2);
                    break;
                case 1:
                    resultado = Calculadora.Resta(op1, op2);
                    break;
                case 2:
                    resultado = Calculadora.Producto(op1, op2);
                    break;
                case 3:
                    resultado = Calculadora.Division(op1, op2);
                    break;
                default:
                    new MessageBox("Operación Desconocida").ShowDialog(this);
                    break;
            }

            edRes.Text = resultado.ToString();
        }
    }
}