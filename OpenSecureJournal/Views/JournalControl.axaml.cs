using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenSecureJournal.Views
{
    public class JournalControl : UserControl
    {
        public JournalControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
