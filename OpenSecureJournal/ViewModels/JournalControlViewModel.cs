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
    public class JournalControlViewModel : ViewModelBase
    {
        public Journal Journal { get; set; }
        public string Password { get; set; }

        private List<DateTime> _EntryDates; 
        public List<DateTime> EntryDates
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
        }

        public async void NewEntry()
        {
            EntryContent = new Label()
            {
                Content = "New!!"
            };
        }
    }
}
