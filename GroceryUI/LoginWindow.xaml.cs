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
using System.Windows.Shapes;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		public Frame frame;
		public LoginPage(Frame frame)
		{
			this.frame = frame;
			InitializeComponent();
		}

		void AttemptLogin(object sender, RoutedEventArgs e)
		{
			if (UsernameBox.Text != "")
			{
				frame.Content = new MainPage(frame);		
			}
		}
	}
}
