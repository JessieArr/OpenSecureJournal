using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSecureJournal.WPF.Services
{
    public class ActiveJournalService
    {
        public static JournalMainControl MainControl { get; set; }
        public static string EncryptedJournalText { get; set; }
        public static string OpenedJournalText { get; set; }
        public static string Password { get; set; }
    }
}
