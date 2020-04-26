using GroceryStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for AddItemWindow.xaml
	/// </summary>
	public partial class AddItemWindow : Window
	{
		string itemName;
		DateTime itemExpirationDate;
		StorageMedium itemStorageMedium;

		public AddItemWindow()
		{
			InitializeComponent();

			string[] storageMediumInterpretationMedium = new string[3];
			int i = 0;
			foreach (StorageMedium storageMedium in Enum.GetValues(typeof(StorageMedium)))
			{
				storageMediumInterpretationMedium[i] = storageMedium.ToString();
				i++;
			}
			storageMediumSelection.ItemsSource = storageMediumInterpretationMedium;

			itemNameEmpty.Foreground = Brushes.Transparent;
			expirationEmpty.Foreground = Brushes.Transparent;
			storageMediumEmpty.Foreground = Brushes.Transparent;
			amountEmpty.Foreground = Brushes.Transparent;
		}

		void AddButton_Click(object sender, RoutedEventArgs e)
		{
			bool ProperlyFilled = true;
			if (string.IsNullOrEmpty(itemNameTextBox.Text))
			{
				ProperlyFilled = false;
				itemNameEmpty.Foreground = Brushes.Red;
			}
			if (expirationDateSelection.SelectedDate is null)
			{
				ProperlyFilled = false;
				expirationEmpty.Foreground = Brushes.Red;
			}
			if (storageMediumSelection.SelectedIndex == -1)
			{
				ProperlyFilled = false;
				storageMediumEmpty.Foreground = Brushes.Red;
			}
			if (string.IsNullOrEmpty(itemAmountTextBox.Text))
			{
				ProperlyFilled = false;
				amountEmpty.Foreground = Brushes.Red;
			}

			if (ProperlyFilled)
			{
				List<Item> newItems = new List<Item>();
				itemName = itemNameTextBox.Text;
				itemExpirationDate = expirationDateSelection.SelectedDate.Value;
				itemStorageMedium = (StorageMedium)storageMediumSelection.SelectedIndex;
				for (int i = 0; i < int.Parse(itemAmountTextBox.Text);)
				{
					BarcodeInputWindow barcodeInputWindow = new BarcodeInputWindow(i += 1, itemExpirationDate);
					if (barcodeInputWindow.ShowDialog().Value)
					{
						newItems.Add(new Item(itemName, barcodeInputWindow.Barcode, itemExpirationDate, itemStorageMedium));
					}
					else
					{
						Close();
						return;
					}
				}
				Storage.Add(newItems);
				Close();
			}
		}

		//Courtesy of https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
		private void NumberInputValidation(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text); //Whether or not the input is accepted depends on if it's a number or not
		}
	}
}
