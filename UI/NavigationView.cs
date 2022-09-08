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
        DogView dogview = new();

        public void menu()
        {
            Console.WriteLine("Who let the dogs out?");
            Console.ReadKey();
            Console.WriteLine("Woof, woof, woof!");
            Console.WriteLine();

            Console.WriteLine("Select menu");
            Console.WriteLine("1: Register new dog");
            Console.WriteLine("2: Search for a dog");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterDogView registerDogView = new RegisterDogView();
                    registerDogView.ShowView();
                    break;

                case "2":
                    dogview.SearchDogView();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    break;
            }
        }
    }
}
