using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}