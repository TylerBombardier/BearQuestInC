using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
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

        public bool use()
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
