using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    public static class Storage
    {
        private static readonly Dictionary<string, Item> Inventory = new Dictionary<string, Item>(); //This is readonly, so that the inventory can never be replaced with a new one. Regular functionality should be kept

        public static Item[] Items
        {
            get
            {
                Item[] items = new Item[Inventory.Count];
                Inventory.Values.CopyTo(items, 0);
                return items;
            }
        }

        public static void Add(Item item)
        {
            Inventory.Add(item.Barcode, item);
            Log.Add(item + "was added to storage!");
        }

        public static void Add(ICollection<Item> items)
        {
            int i = 0;
            foreach (Item item in items)
            {
                Inventory.Add(item.Barcode, item);
                Log.Add($"{item} was added to storage! ({i += 1}/{items.Count})");
            }
        }

        public static Item Get(string barcode)
        {
            Item item = Inventory[barcode];
            Log.Add(item + "was accessed in storage!");
            return item;
        }

        public static bool Contains(string barcode)
        {
            return Inventory.ContainsKey(barcode);
        }

        public static bool Contains(Item item)
        {
            return Contains(item.Barcode);
        }

        public static void Remove(string barcode)
        {
            Log.Add(Inventory[barcode] + "was removed from storage!");
            Inventory.Remove(barcode);
        }

        public static void Remove(Item item)
        {
            Remove(item.Barcode);
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
