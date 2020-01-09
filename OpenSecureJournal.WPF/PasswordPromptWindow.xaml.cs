using OpenSecureJournal.WPF.Services;
using System;
using System.Windows;

namespace OpenSecureJournal.WPF
{
    /// <summary>
    /// Interaction logic for PasswordPromptWindow.xaml
    /// </summary>
    public partial class PasswordPromptWindow : Window
    {
        public PasswordPromptWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var password = Password.Password;

            var encryptedText = ActiveJournalService.EncryptedJournalText;
            if (!String.IsNullOrEmpty(encryptedText))
            {
                var decryptedText = AESThenHMAC.SimpleDecryptWithPassword(encryptedText, password);
                if (!String.IsNullOrEmpty(decryptedText))
                {
                    ActiveJournalService.Password = password;
                    ActiveJournalService.OpenedJournalText = decryptedText;
                    NavigationHelper.ChangeMainContent(new JournalMainControl());
                    Close();
                }
                else
                {
                    ErrorText.Content = "The password was incorrect! Please try again.";
                }
            }
            else
            {
                ActiveJournalService.Password = password;
                NavigationHelper.ChangeMainContent(new JournalMainControl());
                Close();
            }
        }
    }
}
