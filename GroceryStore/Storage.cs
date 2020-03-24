using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    public static class Storage
    {
        private static Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public static Item[] Values
        {
            get
            {
                Item[] items = new Item[Inventory.Count];
                int i = 0;
                foreach (Item item in Inventory.Values)
                {
                    items[i] = item;
                    i++;
                }
                return items;
            }
        }

        public static void Add(Item item)
        {
            Inventory.Add(item.Barcode, item);
            Log.Add(item + "was added to storage!");
        }

        public static void AddCollection(ICollection<Item> items)
        {
            int i = 0;
            foreach (Item item in items)
            {
                Inventory.Add(item.Barcode, item);
                Log.Add($"{item} was added to storage! ({i++}/{items.Count})");
            }
        }

        public static Item GetItem(string barcode)
        {
            Item item = Inventory[barcode];
            Log.Add(item + "was accessed in storage!");
            return item;
        }

        public static bool CheckItem(string barcode)
        {
            return Inventory.ContainsKey(barcode);
        }

        public static void RemoveItem(string barcode)
        {
            Log.Add(Inventory[barcode] + "was removed from storage!");
            Inventory.Remove(barcode);
        }

        public static Item[] GetExpiredItems()
        {
            List<Item> expiredItems = new List<Item>();
            foreach (Item item in Inventory.Values)
            {
                if (item.ExpirationDate <= DateTimeOffset.Now)
                {
                    expiredItems.Add(item);
                }
            }
            return expiredItems.ToArray();
        }

        public static IEnumerator<Item> GetEnumerator()
        {
            return Inventory.Values.GetEnumerator();
        }
    }
}
