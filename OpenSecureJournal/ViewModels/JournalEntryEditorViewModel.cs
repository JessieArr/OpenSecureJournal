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
    public class JournalEntryEditorViewModel : ViewModelBase
    {
        //private DateTime _EntryDate;
        //public DateTime EntryDate
        //{
        //    get => _EntryDate;
        //    set => this.RaiseAndSetIfChanged(ref _EntryDate, value);
        //}
        public DateTime EntryDate { get; set; }
        public string EntryText { get; set; }

        public JournalEntryEditorViewModel()
        {
            EntryDate = DateTime.Now;
        }

        private JournalEntry _JournalEntry;

        public void LoadJournalEntry(JournalEntry entry)
        {
            _JournalEntry = entry;
            EntryDate = entry.Date;
            EntryText = entry.Text;
        }

        public async void SaveEntry()
        {
            _JournalEntry.Date = EntryDate;
            _JournalEntry.Text = EntryText;
        }
    }
}
