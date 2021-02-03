using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenSecureJournal.Views
{
    public class JournalPlaceholder : UserControl
    {
        public JournalPlaceholder()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
