using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest.Models
{
    internal class Person
    {
        public static int FOOD = 0;
        public static int DRINK = 1;

        private string _Name;
        private int _HydrationValue;
        private int _HealthLevel;

        public string Name { get; set; }
        public int HydrationLevel { get; set; }
        public int HealthLevel { get; set; }

        private List<Item> inventory = new List<Item>();

        public Person(string name)
        {
            this._Name = name;
            this._HydrationValue = 100;
            this._HealthLevel = 100;

           
        }

        public void useItem(Item item)
        {
            if(item is Food && HealthLevel < 100)
            {
                Food temp = item as Food;

            }
        }

        public void cook(Food food)
        {

        }

        public void displayInventory()
        {

        }

        public void displayInventory(int type)
        {

        }

        public void addToInventory(Item item)
        {

        }
    }
}
