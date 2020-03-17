using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    class Item
    {
        string name;
        string barcode;
        DateTimeOffset experirationDate;
        bool requiresRefrigeration;

        public Item(string name, string barcode, DateTimeOffset experirationDate, bool requiresRefrigeration)
        {
            this.name = name; 
            this.barcode = barcode;
            this.experirationDate = experirationDate;
            this.requiresRefrigeration = requiresRefrigeration;
        }

        
    }
}
