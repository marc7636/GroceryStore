using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    class Item
    {
        string name;
        string barcode;
        DateTime experitationDate;
       


        Item(string name, string barcode, DateTime experirationDate)
        {
            this.name = name; 
            this.barcode = barcode;
            this.experitationDate = experirationDate;
        }

        
    }
}
