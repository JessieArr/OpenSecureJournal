using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OpenSecureJournal.WPF
{
    public static class NavigationHelper
    {
        private static MainWindow _MainWindow;
        public static void ChangeMainContent(UserControl newContent)
        {
            _MainWindow.MainContent.Content = newContent;
        }

        public static void SetMainWindow(MainWindow mainWindow)
        {
            _MainWindow = mainWindow;
        }
    }
}
