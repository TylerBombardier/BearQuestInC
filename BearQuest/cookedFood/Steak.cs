using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.cookedFood
{
    internal class Steak : Food
    {
        public Steak() : base("Steak", 10){}

        public override Food Cook()
        {
            use();
            Console.WriteLine("You began to cook the steak");

            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("The steak burnt.");

            return null;
        }
    }
}
