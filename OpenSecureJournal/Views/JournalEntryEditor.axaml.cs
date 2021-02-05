using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenSecureJournal.Views
{
    public class JournalEntryEditor : UserControl
    {
        public JournalEntryEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
