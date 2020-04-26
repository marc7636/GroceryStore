using GroceryStore;
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
	/// Interaction logic for Storage.xaml
	/// </summary>
	public partial class StoragePage : Page
	{
		readonly double listWidthModifier = 3 / 5;
		public StoragePage()
		{
			InitializeComponent();
			StorageListView.Width = this.Width * listWidthModifier;
			UpdateListView();
		}

		void UpdateListView()
		{
			StorageListView.Items.Clear();
			foreach (Item item in Storage.Items)
			{
				StorageListView.Items.Add(item);
			}
		}

		void OnSizeChange(object sender, SizeChangedEventArgs e)
		{
			if (e.WidthChanged)
			{
				StorageListView.Width = e.NewSize.Width * listWidthModifier;
			}
		}

		void AddButtonClick(object sender, RoutedEventArgs e)
		{
			(new AddItemWindow()).ShowDialog();
			UpdateListView();
		}
	}
}
