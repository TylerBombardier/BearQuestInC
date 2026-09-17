using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    internal abstract class Food : Item
    {
        private int _RegenerationValue;

        public int RegenerationValue
        {
            get => _RegenerationValue;
            set => _RegenerationValue = value;
        }

        public Food(string name, int regenerationValue) : base(name)
        {
            this._RegenerationValue = regenerationValue;
        }

        public abstract Food Cook();

        public void eat()
        {
            if( use())
            {
                Console.WriteLine(("You at the " + this.Name));
            }
        }
    }
}
