using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace P2.UI
{
    public class DVDWindow : Window
    {
        public DVDWindow()
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