﻿using System;
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

namespace GroceryUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GroceryStore.Log.LoadState();
            InitializeComponent();
            this.Closed += new EventHandler(MainWindowClosed);
            frame.Content = new LoginPage(frame);
        }

        void MainWindowClosed(object sender, EventArgs e)
        {
            GroceryStore.Log.SaveState();
        }

        
    }
}
