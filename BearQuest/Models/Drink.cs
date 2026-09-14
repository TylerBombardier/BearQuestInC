using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    internal abstract class Drink : Item
    {
        private int _HydrationValue;

        public int HydrationValue { get; set; }

        public Drink(string name, int hydrationValue) : base(name)
        {
            this._HydrationValue = hydrationValue;
        }

        public abstract void drink();
    }
}
