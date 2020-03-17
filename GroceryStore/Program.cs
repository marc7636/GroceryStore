using System;

namespace GroceryStore
{
    class Program
    {
        static void Main(string[] args)
        {
			DateTime date = new DateTime(2000, 12, 4, 8, 9, 21);
            Console.WriteLine(date.Month);
            date = date.AddDays(40);
            Console.WriteLine(date.Month);
        }
    }
}
