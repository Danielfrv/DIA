using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace P2.UI
{
    public partial class MessageBox : Window
    {
        public MessageBox(string msg)
            : this()
        {
            var tbText = this.FindControl<TextBlock>("TbText");
            tbText.Text = msg;
        }
        public MessageBox()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var btOk = this.FindControl<Button>("BtOk");
            btOk.Click += (_,_) => this.Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
    }
}