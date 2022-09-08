using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.UI.DogViews
{
    public class SearchDogView
    {
        DogController dogController = new();
        ShowProfileDogView showDogView = new();

        // metode man kan fremsøge hund fra
        public void ShowView()
        {

            bool searchDogExit = false;

            while (!searchDogExit)
            {
                Console.Clear();
                Console.WriteLine("FIND A DOG");
                Console.WriteLine("Enter 'X' to exit");
                Console.Write("Please enter pedigree number: ");
                var pedigreeNumber = Console.ReadLine();


                if (pedigreeNumber.ToUpper() == "X")
                {
                    searchDogExit = true;
                }
                else
                {
                    if (dogController.IsDogInDatabase(pedigreeNumber) == false)
                    {
                        Console.WriteLine("Dog not found. Press any button to return to search...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Dog existingDog = dogController.GetDog(pedigreeNumber);

                        showDogView.ShowView(existingDog);
                        Console.ReadKey();
                    }

                }
            }
        }
    }
}
