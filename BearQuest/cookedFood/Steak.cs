using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.cookedFood
{
    // Represents a piece of cooked steak in the game
    internal class Steak : Food
    {
        public Steak() : base("Steak", 10){}

        // Cook the venison, which burns it and makes it inedible
        public override Food Cook()
        {
            Use();
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
