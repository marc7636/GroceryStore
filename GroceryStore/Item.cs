using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    [Serializable]
    class Item
    {
        string name;
        string barcode;
        DateTimeOffset experirationDate;
        StorageMedium storageMedium;

        public Item(string name, string barcode, DateTimeOffset experirationDate, StorageMedium storageMedium)
        {
            this.name = name; 
            this.barcode = barcode;
            this.experirationDate = experirationDate;
            this.storageMedium = storageMedium;
        }

        
    }

    enum StorageMedium
    {
        None,
        Refrigeration,
        Freezer
    }
}
