using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenSecureJournal.Views
{
    public class JournalUnlockWindow : Window
    {
        public JournalUnlockWindow()
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
