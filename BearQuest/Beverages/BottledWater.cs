using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Beverages
{
    // Represents a bottled water drink item in the game with a hydration value
    internal class BottledWater : Drink
    {
        public BottledWater() : base("Water", 20) { }

        // Method to drink the water bottle, using it and printing a message if successful
        public override void drink()
        {
            if( Use())
            {
                Console.WriteLine("You drink a bottle of water");
            }
        }
    }
}
