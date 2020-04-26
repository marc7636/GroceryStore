using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GroceryUI
{
	/// <summary>
	/// Interaction logic for BarcodeInputWindow.xaml
	/// </summary>
	public partial class BarcodeInputWindow : Window
	{
		public string Barcode { get; private set; }
		public BarcodeInputWindow(int number, DateTime expirationDate)
		{
			InitializeComponent();
			Title = $"Item {number}";
			barcodeInputBox.Focus();
			expirationDatePicker.SelectedDate = expirationDate;
		}

		private void BarcodeInputBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				RegisterItemButton_Click(sender, e); //KeyEventArgs inherit from RoutedEventArgs, so this is allowed.
			}
		}

		//Courtesy of https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
		private void NumberInputValidation(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void RegisterItemButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(barcodeInputBox.Text))
			{
				barcodeInputBox.Focus();
			}
			else
			{
				Barcode = barcodeInputBox.Text;
				DialogResult = true;
				Close();
			}
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			if (!DialogResult.HasValue)
			{
				e.Cancel = true;
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
	}
}
