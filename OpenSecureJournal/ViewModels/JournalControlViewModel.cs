using Avalonia.Controls;
using OpenSecureJournal.Models;
using OpenSecureJournal.Services;
using OpenSecureJournal.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSecureJournal.ViewModels
{
    public class JournalControlViewModel : ViewModelBase
    {
        public Journal Journal { get; set; }
        public string Password { get; set; }

        private ObservableCollection<DateTime> _EntryDates;
        public ObservableCollection<DateTime> EntryDates
        {
            get => _EntryDates;
            set => this.RaiseAndSetIfChanged(ref _EntryDates, value);
        }

        private object _EntryContent;
        public object EntryContent
        {
            get => _EntryContent;
            set => this.RaiseAndSetIfChanged(ref _EntryContent, value);
        }

        public JournalControlViewModel()
        {
            EntryContent = new Label()
            {
                Content = "Entry will appear here."
            };
            EntryDates = new ObservableCollection<DateTime>();
        }

        public async void NewEntry()
        {
            var vm = new JournalEntryEditorViewModel();
            var newEntry = new JournalEntry()
            {
                Date = DateTime.Now,
                Text = "Your text here."
            };
            EntryDates.Add(newEntry.Date);
            vm.LoadJournalEntry(newEntry);
            EntryContent = new JournalEntryEditor()
            {
                DataContext = vm
            };
        }
    }
}
