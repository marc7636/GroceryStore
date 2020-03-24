using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore
{
    static class Log
    {
        private static List<string> log = new List<string>();

        public static void LoadState()
        {

        }

        private static void LoadState(string filePath)
        {

        }

        public static void SaveCurrentState()
        {

        }

        public static void Add(string changes)
        {
            string time = DateTime.Now.TimeOfDay.ToString();
            log.Add(time.Substring(0,time.IndexOf('.')) + @$" | {User.CurrentUser} | " + changes);
        }
    }
}
