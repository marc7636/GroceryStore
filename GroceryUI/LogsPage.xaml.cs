using GroceryStore;
using System;
using System.Windows.Controls;

namespace GroceryUI
{
    /// <summary>
    /// Interaction logic for LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {
        public LogsPage()
        {
            
            InitializeComponent();

            FillInLogs();
        }

        private void FillInLogs()
        {
            foreach (var log in LoadLogs())
            {
                textBox.Text += log + "\n";
            }
            
        }

        string[] LoadLogs()
        {
            return System.IO.File.ReadAllLines(Log.path + DateTimeOffset.Now.Date.ToString("dd-MM-yyyy") + ".txt");
        }
    }
}
