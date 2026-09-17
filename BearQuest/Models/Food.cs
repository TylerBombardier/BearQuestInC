using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    // Represents a piece of food in the game with a name and regeneration value
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

        // Method to eat the food, using it and printing a message if successful
        public void eat()
        {
            if( Use())
            {
                Console.WriteLine(("You at the " + this.Name));
            }
        }
    }
}
