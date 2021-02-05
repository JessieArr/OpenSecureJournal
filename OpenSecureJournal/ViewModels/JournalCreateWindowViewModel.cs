using Avalonia.Controls;
using OpenSecureJournal.Models;
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
    public class JournalCreateWindowViewModel : ViewModelBase
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Window ParentWindow { get; set; }

        public JournalCreateWindowViewModel()
        {
        }

        public async void CreateJournal()
        {
            if(Password == ConfirmPassword)
            {
                var journal = new Journal();

                var dialog = new SaveFileDialog();
                dialog.Filters.Add(new FileDialogFilter()
                {
                    Extensions = new List<string>()
                    {
                        "osj"
                    },
                    Name = "Open Secure Journals"
                });

                var result = await dialog.ShowAsync(new Window());

                if(result != null)
                {
                    await JournalFileService.SaveJournal(result, journal, Password);
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
    }
}
