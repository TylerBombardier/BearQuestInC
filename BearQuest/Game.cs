using BearQuest.Beverages;
using BearQuest.Models;
using BearQuest.rawFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearQuest
{
    internal class Game()
    {
        // Starts up the game and displays the main menu
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bear Quest");
            Console.WriteLine("Please enter your name:");
            Person mainCharacter = new Person(Console.ReadLine());

            //Display our main menu
            DisplayMainMenu(mainCharacter);

            Console.WriteLine("Thank you for playing Bear Quest");
        }

        // Displays the main menu and handles user input
        public static void DisplayMainMenu(Person mainCharacter)
        {
            Random random = new Random();

            int bearDamage;
            char userInput = '0';

            do
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Main Menu");
                Console.WriteLine("------------------------");
                Console.WriteLine(mainCharacter);
                Console.WriteLine("------------------------");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Look at inventory (I)");
                Console.WriteLine("Explore (E)");
                Console.WriteLine("Quit (X)");
                Console.WriteLine("Please enter a letter:");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                userInput = char.ToUpper(input[0]); // Will accept: I,i,E,e,X,x

                switch (userInput)
                {
                    case 'I':
                        InventoryMenu(mainCharacter);
                        break;
                    case 'E':
                        bearDamage = random.Next(50); // between 0 - 50

                        Console.WriteLine("You got mauled by a bear! Take " + bearDamage + " damage!");

                        mainCharacter.HealthLevel = (mainCharacter.HealthLevel - bearDamage);
                        mainCharacter.HydrationValue = (mainCharacter.HydrationValue - 10);

                        if (mainCharacter.HealthLevel <= 0 || mainCharacter.HydrationValue <= 0)
                        {
                            Console.WriteLine("You died");
                            userInput = 'X';
                        }
                        else
                        {
                            AcquireRandomItem(mainCharacter);
                        }
                        break;
                }

            } while (userInput != 'X');
        }

        // Displays the inventory menu and handles user input
        public static void InventoryMenu(Person mainCharacter)
        {
            char userInput = '0';
            int item = 0;

            do
            {
                mainCharacter.displayInventory();

                Console.WriteLine("What would you like to do");
                Console.WriteLine("Use an Item (U)");
                Console.WriteLine("Cook Food (C)");
                Console.WriteLine("Leave Inventory (X)");
                Console.WriteLine("Please enter a letter:");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                userInput = char.ToUpper(input[0]);

                switch (userInput)
                {
                    case 'U':
                        mainCharacter.displayInventory();

                        Console.WriteLine("Which item would you like to use?");

                        string consumeInput = Console.ReadLine();

                        if (!int.TryParse(consumeInput, out item))
                        {
                            Console.WriteLine("Please enter a valid number.");
                            continue;
                        }

                        if (item < 0 || item >= mainCharacter.Inventory.Count)
                        {
                            Console.WriteLine("That item does not exist.");
                            continue;
                        }

                        mainCharacter.UseItem(mainCharacter.Inventory[item]);

                        break;

                    case 'C':
                        mainCharacter.DisplayInventory(Person.FOOD);

                        Console.WriteLine("Which item would you like to cook?");
                        string cookInput = Console.ReadLine();

                        if (!int.TryParse(cookInput, out item))
                        {
                            Console.WriteLine("Please enter a valid number.");
                            continue;
                        }

                        if (item < 0 || item >= mainCharacter.Inventory.Count)
                        {
                            Console.WriteLine("That item does not exist.");
                            continue;
                        }

                        Food food = (Food)mainCharacter.Inventory[item];
                        mainCharacter.Cook(food);

                        break;
                }

            } while (userInput != 'X');
        }

        // Picks a random item from a list of items and adds it to the player's inventory
        public static void AcquireRandomItem(Person mainCharacter)
        {
            Random random = new Random();
            //Create a list of random items that can be picked-up
            List<Item> itemList = [ new Berries(), new Venison(), new BottledWater(), new SodaPop() ];

            //Pick a random number corresponding to the list of items
            int randomNumber = random.Next(itemList.Count);

            Console.WriteLine(itemList[randomNumber] + " was just added to your inventory");

            //Add the random item to the player's inventory
            mainCharacter.AddToInventory(itemList[randomNumber]);
        }
    }
}