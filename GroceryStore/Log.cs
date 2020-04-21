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
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\GroceryStore\\";


        public static void LoadState()
        {
            if (File.Exists(path + @"/storage.store"))
            {
                using (Stream stream = File.Open(path + "/storage.store", FileMode.Open))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var inv = (Item[])formatter.Deserialize(stream);
                    Storage.Add(inv);
                }
            }    
        }

        public static void SaveState()
        {
            if (File.Exists(path + @"/storage.store"))
                File.Delete(path + @"/storage.store");
            using (Stream stream = File.Open(path + "/storage.store", FileMode.Create))
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, Storage.Items);
            }
        }

        public static void Add(string changes)
        {
            Directory.CreateDirectory(path);
            var time = DateTimeOffset.Now;
            using (StreamWriter file =
            new StreamWriter(path + time.Date.ToString().Replace('/', '-').Split(' ')[0] + ".txt", true))
            {
                var timeOfDay = time.TimeOfDay.ToString();
                file.WriteLine(timeOfDay.Substring(0, timeOfDay.IndexOf('.')) + @$" | {User.CurrentUser} | " + changes);
            }
        }
    }
}
