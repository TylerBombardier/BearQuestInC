using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Beverages
{
    // Represents a soda pop drink item in the game with a hydration value
    internal class SodaPop : Drink
    {
        public SodaPop() : base("SodaPop", 10) { }

        // Method to drink the soda pop, using it and printing a message if successful
        public override void drink()
        {
            if( Use())
            {
                Console.WriteLine("You drink a can of cola");
            }
        }
    }
}
