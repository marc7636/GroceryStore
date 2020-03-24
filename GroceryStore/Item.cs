using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    [Serializable]
    class Item
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        string barcode;
        public string Barcode
        {
            get
            {
                return barcode;
            }
        }

        DateTimeOffset experirationDate;
        public DateTimeOffset ExpirationDate
        {
            get
            {
                return experirationDate;
            }
        }

        StorageMedium storageMedium;
        public StorageMedium StorageMedium
        {
            get
            {
                return storageMedium;
            }
        }

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
