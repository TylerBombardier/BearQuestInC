using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Beverages
{
    internal class BottledWater : Drink
    {
        public BottledWater() : base("Water", 20) { }
        public override void drink()
        {
            if( use())
            {
                Console.WriteLine("You drink a bottle of water");
            }
        }
    }
}
