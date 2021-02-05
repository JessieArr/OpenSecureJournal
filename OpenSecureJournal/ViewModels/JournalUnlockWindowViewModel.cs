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
            var journal = await JournalFileService.OpenJournal(JournalPath, Password);
            var vm = new JournalControlViewModel();
            vm.Journal = journal;
            MainContentHelper.MainWindowViewModel.MainContent = new JournalControl()
            {
                DataContext = vm,
            };
            ParentWindow.Close();
        }
    }
}
