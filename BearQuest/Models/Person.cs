using BearQuest.Beverages;
using BearQuest.rawFood;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BearQuest.Models
{
    // Represents a person in the game with a name, hydration value, health level, and an inventory of items
    internal class Person
    {
        public static int FOOD = 0;
        public static int DRINK = 1;

        private string _Name;
        private int _HydrationValue;
        private int _HealthLevel;

        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public int HydrationValue
        {
            get => _HydrationValue;
            set => _HydrationValue = value;
        }

        public int HealthLevel
        {
            get => _HealthLevel;
            set => _HealthLevel = value;
        }

        private List<Item> _Inventory = new List<Item>();

        public List<Item> Inventory
        {
            get => _Inventory;
            set => _Inventory = value;
        }

        // Constructor for the Person class that initializes the name, hydration value, health level, and adds some items to the inventory
        public Person(string name)
        {
            this._Name = name;
            this._HydrationValue = 100;
            this._HealthLevel = 100;

            AddToInventory(new Berries());
            AddToInventory(new Venison());
            AddToInventory(new Venison());
            AddToInventory(new BottledWater());
            AddToInventory(new SodaPop());
        }

        // Method to use an item from the inventory, which can be either food or drink, and updates the person's health or hydration accordingly
        public void UseItem(Item item)
        {
            if(item is Food && HealthLevel < 100)
            {
                Food temp = (Food)item;
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
                Drink temp = (Drink)item;
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

            int location = Inventory.IndexOf(item);

            if (Inventory[location].Quantity <= 0)
            {
                Inventory.Remove(item);
            }
        }

        // Method to cook a food item as a person
        public void Cook(Food food)
        {
            Item item = food.Cook();

            if(food.Quantity == 0)
            {
                Inventory.RemoveAt(Inventory.IndexOf(food));
            }

            if(item != null)
            {
                AddToInventory(item);
            }
        }

        // Method to display the inventory of items, including their name and quantity
        public void DisplayInventory()
        {
            Item item;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Item:\t Name:\t Quantity:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < Inventory.Count; i++)
            {
                item = Inventory[i];
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            }
            Console.WriteLine("----------------------------");
        }

        // Method to display the inventory of items, filtered by type (food or drink)
        public void DisplayInventory(int type)
        {
            Item item;
            Console.WriteLine("----------------------------");
            Console.WriteLine("Item:\t Name:\t Quantity:");
            Console.WriteLine("----------------------------");
            for (int i = 0; i < Inventory.Count; i++)
            {
                item = Inventory[i];
                //Check if the item is Food or Drink, and if the type is drink or food
                if (type == 0 && item is Food) {
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            } else if (type == 1 && item is Drink) {
                Console.WriteLine(i + ")\t" + item + "\t\t X" + item.Quantity);
            }

        }
        Console.WriteLine("----------------------------");
        }

        // Method to add an item to the inventory, either by increasing the quantity of an existing item or adding a new item to the list
        public void AddToInventory(Item item)
        {
            bool found = false;
            Item temp = null;

            for (int i = 0; i < Inventory.Count; i++)
            {
                temp = Inventory[i];

                if (item.GetType() == temp.GetType())
                {
                    temp.Quantity = (temp.Quantity + 1);
                    found = true;
                }
            }

            if (!found)
            {
                item.Quantity = 1;
                Inventory.Add(item);
            }
        }

        public override string ToString()
        {
            return "Character stats: \n Name: " + Name
                    + " \n Hydration: " + HydrationValue
                    + " \n Health: " + HealthLevel;
        }
    }
}
