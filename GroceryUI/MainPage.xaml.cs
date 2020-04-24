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

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public Frame frame;
		public MainPage(Frame frame)
		{
			this.frame = frame;
			InitializeComponent();
		}

		void StorageButtonClick(object sender, RoutedEventArgs e)
		{
			
		}

		void LogsButtonClick(object sender, RoutedEventArgs e)
		{
			frame.Content = new LogsPage();
		}
	}
}
