using Microsoft.Win32;
using OpenSecureJournal.WPF.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationHelper.SetMainWindow(this);
            MainContent.Content = new MainControl();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.FileName = "MyJournal";
            dlg.DefaultExt = ".osj";
            dlg.Filter = "Open Secure Journal Files (.osj)|*.osj";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                var filename = dlg.FileName;

                var journalText = ActiveJournalService.MainControl.GetJournalText();
                var encryptedText = AESThenHMAC.SimpleEncryptWithPassword(journalText, ActiveJournalService.Password);
                File.WriteAllText(filename, encryptedText);
            }
        }

        private void NewJournal_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new PasswordPromptWindow();
            newWindow.Show();
        }

        private void OpenJournal_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Open Secure Journal Files (.osj)|*.osj"; // Filter files by extension

            var result = dlg.ShowDialog();

            if (result == true)
            {
                var filename = dlg.FileName;
                var contents = File.ReadAllText(filename);

                ActiveJournalService.EncryptedJournalText = contents;

                var newWindow = new PasswordPromptWindow();
                newWindow.Show();
            }
        }

        public void SetMainContent(UserControl newContent)
        {
            MainContent.Content = newContent;
        }
    }
}
