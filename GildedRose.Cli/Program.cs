using System;
using System.Collections.Generic;

namespace GildedRose.Cli
{
    class Program
    {
        private readonly Inn _inn = new Inn();

        public Inn Inn
        {
            get { return _inn; }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();


            System.Console.WriteLine("Type <enter> to pass to the next day or <esc> to quit:");
            System.Console.WriteLine();

            while (System.Console.ReadKey().Key != ConsoleKey.Escape)
            {
                System.Console.WriteLine("Go to next day...");
                app.Inn.UpdateQuality();
            }

            System.Console.WriteLine("Ciao...");
            System.Console.ReadLine();
        }
    }

    /// <summary>
    /// Forbidden: do not modify this class!!!
    /// </summary>
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
