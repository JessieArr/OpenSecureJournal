using OpenSecureJournal.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenSecureJournal.WPF
{
    /// <summary>
    /// Interaction logic for JournalMainControl.xaml
    /// </summary>
    public partial class JournalMainControl : UserControl
    {
        public JournalMainControl()
        {
            InitializeComponent();

            ActiveJournalService.MainControl = this;

            if(!String.IsNullOrEmpty(ActiveJournalService.OpenedJournalText))
            {
                JournalText.Text = ActiveJournalService.OpenedJournalText;
                ActiveJournalService.OpenedJournalText = null;
            }
        }

        public string GetJournalText()
        {
            return JournalText.Text;
        }
    }
}
