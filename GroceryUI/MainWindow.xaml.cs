using GroceryStore;
using System;
using System.ComponentModel;
using System.Windows;

namespace GroceryUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                User.CurrentUser = loginWindow.UsernameBox.Text;
                frame.Content = new MainPage();
            }
            else
            {
                Close();
            }
            Log.LoadState();
        }

        void MainWindowClosing(object sender, CancelEventArgs e)
        {
            try
            {
                Log.SaveState();
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show("Could not save data, because " + exception.ToString());
                throw;
            }
        }
    }
}
