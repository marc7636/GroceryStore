using GroceryStore;
using System.Windows;
using System.Windows.Controls;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for Storage.xaml
	/// </summary>
	public partial class StoragePage : Page
	{
		public StoragePage()
		{
			InitializeComponent();
			UpdateListView();
		}

		void UpdateListView()
		{
			StorageListView.Items.Clear();
			foreach (Item item in Storage.Items)
			{
				StorageListView.Items.Add(new ItemInterpretation() { Name = item.Name, Barcode = item.Barcode, ExpirationDate = item.ExpirationDate.ToString("yyyy-MM-dd"), StorageMedium = item.StorageMedium.ToString()});
			}
		}

		void AddButtonClick(object sender, RoutedEventArgs e)
		{
			(new AddItemWindow()).ShowDialog();
			UpdateListView();
		}
	}

	public class ItemInterpretation
	{
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string ExpirationDate { get; set; }
		public string StorageMedium { get; set; }
	}
}
