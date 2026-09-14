using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public int HydrationValue { get; set; }
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
                if(HealthLevel + temp.RegenerationValue < 100)
                {
                    HealthLevel = 100;
                }
                else
                {
                    HealthLevel += temp.RegenerationValue + HealthLevel;
                }
                temp.eat();
            } else if (item is Drink && HydrationValue < 100)
            {
                Drink temp = item as Drink;
                if(HydrationValue + temp.HydrationValue < 100)
                {
                    HydrationValue = 100;
                }
                else
                {
                    HydrationValue += temp.HydrationValue + HydrationValue;
                }
                temp.drink();
            } else
            {
                Console.WriteLine("You don't need to use that item right now");
            }

            int location = inventory.IndexOf(item);

            if (inventory[location].Quantity <= 0)
            {
                inventory.Remove(item);
            }
        }

        public void cook(Food food)
        {
            Item item = food.Cook();

            if(food.Quantity == 0)
            {
                inventory.RemoveAt(inventory.IndexOf(food));
            }

            if(item != null)
            {
                addToInventory(item);
            }
        }

        public void displayInventory()
        {
            Item item;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Item:\t Name:\t Quantity:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < inventory.Count; i++)
            {
                item = inventory[i];
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            }
            Console.WriteLine("----------------------------");
        }

        public void displayInventory(int type)
        {
            Item item;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Item:\t Name:\t Quantity:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < inventory.Count; i++)
            {
                item = inventory[i];
                //Check if the item is Food or Drink, and if the type is drink or food
                if (type == 0 && item is Food) {
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            } else if (type == 1 && item is Drink) {
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            }

        }
        Console.WriteLine("----------------------------");
        }

        public void addToInventory(Item item)
        {
            bool found = false;
            Item temp = null;

            for (int i = 0; i < inventory.Count; i++)
            {
                temp = inventory[i];

                if (item.GetType == temp.GetType)
                {
                    temp.Quantity = (temp.Quantity + 1);
                    found = true;
                }
            }

            if (!found)
            {
                item.Quantity = 1;
                inventory.Add(item);
            }
        }

        public string toString()
        {
            return "Character stats: \n Name: " + Name
                    + " \n Hydration: " + HydrationValue
                    + " \n Health: " + HealthLevel;
        }
    }
}
