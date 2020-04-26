using GroceryStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
