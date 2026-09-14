using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Beverages
{
    internal class SodaPop : Drink
    {
        public SodaPop() : base("SodaPop", 10) { }
        public override void drink()
        {
            if( use())
            {
                Console.WriteLine("You drink a can of cola");
            }
        }
    }
}
