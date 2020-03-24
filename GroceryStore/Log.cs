using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GroceryStore
{
    public static class Log
    {
        public static List<string> log {
            get;
            private set;
        } = new List<string>();


        public static void LoadState()
        {
            if (File.Exists(@"/storage"))
            {
                using (Stream stream = File.Open("/storage", FileMode.Create))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var inv = (Item[])formatter.Deserialize(stream);
                    Storage.AddCollection(inv);
                }
            }    
        }

        public static void SaveState()
        {
            if (File.Exists(@"/storage"))
                File.Delete(@"/storage");
            using (Stream stream = File.Open("/storage", FileMode.Create))
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, Storage.Values);
            }
        }

        public static void Add(string changes)
        {
            string time = DateTimeOffset.Now.TimeOfDay.ToString();
            log.Add(time.Substring(0,time.IndexOf('.')) + @$" | {User.CurrentUser} | " + changes);
        }
    }
}
