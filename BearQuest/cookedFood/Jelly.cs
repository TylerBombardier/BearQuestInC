using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.cookedFood
{
    internal class Jelly : Food
    {
        public Jelly() : base("Jelly", 10) { }

        public override Food Cook()
        {
            use();
            Console.WriteLine("You began to cook the jelly");

            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }


            Console.WriteLine("The jelly is burnt. Smells like molasses. The Jelly is inedible");

            return null;
        }
    }
}
