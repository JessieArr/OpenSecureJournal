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
    public class JournalControlViewModel : ViewModelBase
    {
        public string JournalPath { get; set; }
        public string Password { get; set; }

        public JournalControlViewModel()
        {
        }
    }
}
