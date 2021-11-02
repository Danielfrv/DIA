using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Proveedores.UI
{
    public class MessageWindow : Window
    {
        public MessageWindow(string msg)
            : this()
        {
            var tbText = this.FindControl<TextBlock>("TbText");
            tbText.Text = msg;
        }
        public MessageWindow()
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