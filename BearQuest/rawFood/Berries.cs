using BearQuest.cookedFood;
using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.rawFood
{
    // Represents a piece of raw berries that can be cooked into jelly
    internal class Berries : Food
    {
        public Berries() : base("Berries", 1) { }

        public override Food Cook()
        {
            Use();

            Console.WriteLine("You began to cook the berries");

            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("The berries are cooked. Hello Jelly!");
            return new Jelly();
        }
    }
}
