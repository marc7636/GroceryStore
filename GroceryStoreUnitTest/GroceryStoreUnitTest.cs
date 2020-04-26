using GroceryStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GroceryStoreUnitTest
{
	[TestClass]
	public class StorageTest
	{
		[TestMethod]
		public void AddValidItem()
		{
			var expirationDate = new System.DateTime(2022, 1, 1, 0, 0, 0);
			Item testItem = new Item("testItem", "123456789 900", expirationDate, StorageMedium.None);
			Storage.Add(testItem);
			Assert.IsTrue(Storage.Contains(testItem));
		}
		
		[ExpectedException(typeof(System.NullReferenceException))]
		[TestMethod]
		public void AddNull()
		{
			Item testItem = null;
			Storage.Add(testItem);
		}

		[TestMethod]
		public void AddExpiredItem()
		{
			var expirationDate = new System.DateTime(2000, 1, 1, 0, 0, 0);
			Item testItem = new Item("testItem", "123456789 000", expirationDate, StorageMedium.None);
			Storage.Add(testItem);
			Assert.IsTrue(Storage.Contains(testItem));
		}

		[TestMethod]
		public void AddCollection()
		{
			var collectionOfItems = new List<Item>();
			for (int i = 0; i < 10; i++)
			{
				var expirationDate = new System.DateTime(2022, 1, 1, 0, 0, 0);
				Item testItem = new Item("testItem", "123456789 " + i, expirationDate, StorageMedium.None);
				collectionOfItems.Add(testItem);
			}
			Storage.Add(collectionOfItems);
			bool result = true;
			foreach (var item in collectionOfItems)
			{
				if (!Storage.Contains(item))
					result = false;
			}
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void RemoveItem()
		{
			var expirationDate = new System.DateTime(2022, 1, 1, 0, 0, 0);
			Item testItem = new Item("testItem", "123456789 300", expirationDate, StorageMedium.None);
			Storage.Add(testItem);
			Storage.Remove(testItem);
			Assert.IsFalse(Storage.Contains(testItem));
		}

		[TestMethod]
		public void GetExpired()
		{
			var expirationDate = new System.DateTime(2000, 1, 1, 0, 0, 0);
			Item testItem = new Item("testItem", "123456789 200", expirationDate, StorageMedium.None);
			Storage.Add(testItem);
			var expired = Storage.GetExpiredItems();
			Assert.IsTrue(expired[1] == testItem);
		}
	}

	[TestClass]
	public class OtherTests
	{
		[TestMethod]
		public void SaveAndLoadStateTest()
		{
			var expirationDate = new System.DateTime(2022, 1, 1, 0, 0, 0);
			Item testItem = new Item("testItem", "123456789 100", expirationDate, StorageMedium.None);
			Storage.Add(testItem);

			Log.SaveState();
			var oldItems = Storage.Items;
			foreach (var item in Storage.Items)
			{
				Storage.Remove(item);
			}

			Log.LoadState();
			Assert.IsTrue(oldItems[0].Barcode == Storage.Items[0].Barcode);
		}

		[TestMethod]
		public void AddToLog()
		{
			Log.Add("This is a test");
			string text = System.IO.File.ReadAllText(Log.path + System.DateTimeOffset.Now.Date.ToString("dd-MM-yyyy") + ".txt");
			Assert.IsTrue(text.Contains("This is a test"));
		}
	}
}
