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
        //Instantiating the other classes, whose methods we will be using
        DogController dogController;
        ShowProfileDogView showDogView;

        public SearchDogView(DogController dogController)
        {
            this.dogController = dogController;
            showDogView = new();
        }

        //method for finding a dog / searching for a dog using pedigree number
        public void ShowView()
        {

            bool searchDogExit = false;

            //loop continues until user enters 'X' as the pedigree number
            while (!searchDogExit)
            {
                Console.Clear();
                Console.WriteLine("FIND A DOG");
                Console.WriteLine("Enter 'X' to return to main menu");
                Console.Write("Please enter pedigree number: ");

                var pedigreeNumber = Console.ReadLine();
                
                //exit condition
                if (pedigreeNumber.ToUpper() == "X")
                {
                    searchDogExit = true;
                }
                //Pedigree number entered (or anything besides 'X'). Search
                else
                {
                    //1st we check whether dog exists or not
                  
                    //If it doesn't exist:
                    if (dogController.IsDogInDatabase(pedigreeNumber) == false)
                    {
                        Console.WriteLine("Dog not found. Press any button to return to search...");
                        Console.ReadKey();
                    }

                    //If it does exist:
                    else
                    {
                        Dog existingDog = dogController.GetDog(pedigreeNumber); //We create a reference to a dog that the dogController got for us
                        Console.Clear();
                        showDogView.ShowView(existingDog); //We call the method for showing the attributes of existingDog - the dog's profile.
                        Console.WriteLine();
                        Console.WriteLine("Press any button to return to search..."); //Returning to search where user can choose to return to main menu or search for another dog
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
