using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
            var cbGraba = this.FindControl<ComboBox>("CbGraba");
            
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}