using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    // Represents a drink item in the game with a hydration value
    internal abstract class Drink : Item
    {
        private int _HydrationValue;

        public int HydrationValue
        {
            get => _HydrationValue;
            set => _HydrationValue = value;
        }

        public Drink(string name, int hydrationValue) : base(name)
        {
            this._HydrationValue = hydrationValue;
        }

        // Method to drink the beverage, using it and printing a message if successful
        public abstract void drink();
    }
}
