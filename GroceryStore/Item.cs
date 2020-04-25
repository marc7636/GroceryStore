using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    [Serializable]
    public class Item
    {
        public string Name { get; private set; }

        public string Barcode { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public StorageMedium StorageMedium { get; private set; }

        public Item(string name, string barcode, DateTime experirationDate, StorageMedium storageMedium)
        {
            this.Name = name; 
            this.Barcode = barcode;
            this.ExpirationDate = experirationDate;
            this.StorageMedium = storageMedium;
        }

        public override string ToString()
        {
            return $"{Name} ({Barcode})";
        }
    }

    public enum StorageMedium
    {
        None,
        Refrigeration,
        Freezer
    }
}
