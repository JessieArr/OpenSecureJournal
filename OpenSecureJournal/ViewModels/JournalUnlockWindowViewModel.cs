using Avalonia.Controls;
using OpenSecureJournal.Services;
using OpenSecureJournal.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSecureJournal.ViewModels
{
    public class JournalUnlockWindowViewModel : ViewModelBase
    {
        public string JournalPath { get; set; }
        public string Password { get; set; }
        public Window ParentWindow { get; set; }

        public JournalUnlockWindowViewModel()
        {
        }

        public async void UnlockJournal()
        {
            var fileContents = await File.ReadAllTextAsync(JournalPath);
            var decryptedContents = AESThenHMAC.SimpleDecryptWithPassword(fileContents, Password);
            MainContentHelper.MainWindowViewModel.MainContent = new JournalControl()
            {
                DataContext = new JournalControlViewModel()
            };
            ParentWindow.Close();
        }
    }
}
