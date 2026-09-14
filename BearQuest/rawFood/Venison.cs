using BearQuest.cookedFood;
using BearQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.rawFood
{
    internal class Venison : Food
    {
        public Venison(string name, int regenerationValue) : base("Venison", 1){}

        public override Food Cook()
        {
            use();

            Console.WriteLine("You began to cook the venison");

            try
            {
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("The steak is cooked to perfection");
            return new Steak();
        }
    }
}
