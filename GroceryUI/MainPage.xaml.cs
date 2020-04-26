using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void StorageButtonClick(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new StoragePage());
		}
        
		void LogsButtonClick(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new LogsPage());
		}
	}
}
