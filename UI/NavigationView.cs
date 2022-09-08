using Hundehuset.UI.DogViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.UI
{
    public class NavigationView
    {
        RegisterDogView registerDogView = new();
        SearchDogView searchDogView = new();

        public void menu()
        {
            //Only when the system starts up
            Console.WriteLine("Who let the dogs out?");
            Console.ReadKey();
            Console.WriteLine("Woof, woof, woof!");
            Console.ReadKey();

            // Loop of menu, that loops until the close program is selected
            bool runProgram = true;

            while (runProgram == true)
            {
                Console.Clear(); // the menu gets presented on a cleared console

                // Menu
                Console.WriteLine("Selection menu:");
                Console.WriteLine("\t1: Register new dog.");
                Console.WriteLine("\t2: Search for a dog.");
                Console.WriteLine("\tX: Close program.");

                // user selection
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "1":
                        dogview.RegisterDog();
                        break;
                    case "2":
                        dogview.SearchDogView();
                        break;
                    case "X":
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            }
        }
    }
}
