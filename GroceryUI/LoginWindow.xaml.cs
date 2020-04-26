using System.Windows;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		void AttemptLogin(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(UsernameBox.Text))
			{
				DialogResult = true;
				Close();
			}
		}

		private void CancelLoginButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
	}
}
