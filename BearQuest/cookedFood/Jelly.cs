using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.cookedFood
{
    // Represents a piece of cooked jelly in the game
    internal class Jelly : Food
    {
        public Jelly() : base("Jelly", 10) { }

        // Cook the jelly, which burns it and makes it inedible
        public override Food Cook()
        {
            Use();
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
