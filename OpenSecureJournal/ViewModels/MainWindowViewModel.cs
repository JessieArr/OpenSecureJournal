using Avalonia.Controls;
using OpenSecureJournal.Services;
using OpenSecureJournal.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenSecureJournal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object mainContent;
        public object MainContent
        {
            get => mainContent;
            set => this.RaiseAndSetIfChanged(ref mainContent, value);
        }

        public MainWindowViewModel()
        {
            MainContentHelper.MainWindowViewModel = this;
            MainContent = new JournalPlaceholder();
        }

        public async void CreateJournal()
        {
            var vm = new JournalCreateWindowViewModel();
            var unlockWindow = new JournalCreateWindow()
            {
                DataContext = vm
            };
            vm.ParentWindow = unlockWindow;
            unlockWindow.Show();
        }

        public async void OpenJournal()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter()
            {
                Extensions = new List<string>()
                {
                    "osj"
                },
                Name = "Open Secure Journals"
            });
            var result = await dialog.ShowAsync(new Window());

            var files = new List<string>();
            if (result != null)
            {
                var firstResult = result.First();
                var vm =  new JournalUnlockWindowViewModel()
                {
                    JournalPath = firstResult
                };
                var unlockWindow = new JournalUnlockWindow()
                {
                    DataContext = vm
                };
                vm.ParentWindow = unlockWindow;
                unlockWindow.Show();
            }
        }

        public void ExitCommand()
        {
            Environment.Exit(0);
        }
    }
}
