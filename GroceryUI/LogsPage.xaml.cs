using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroceryStore;

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
