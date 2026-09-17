using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    // Represents an item in the game with a name and quantity
    internal class Item
    {
        private string _Name;
        private int _Quantity;

        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public int Quantity
        {
            get => _Quantity;
            set => _Quantity = value;
        }

        public Item(string name)
        {
            this._Name = name;
            this._Quantity = 0;
        }

        // Method to use the item, reducing its quantity by 1 if available
        public bool Use()
        {
            if(_Quantity > 0)
            {
                _Quantity = _Quantity - 1;
                return true;
            } else {
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
