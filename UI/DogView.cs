using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.UI
{
    public class DogView
    {
        DogController dogController = new();

        public void RegisterDog()
        {
            Console.Clear();
            Console.WriteLine("REGISTER NEW DOG");
            Console.Write("Please enter pedigree number: ");
            var pedigreeNumber = Console.ReadLine();

            if (!dogController.DoesPedigreeNumberExist(pedigreeNumber))
            {
                //Dog dog = dogController.CreateDog(pedigreeNumber);

                Dog dog = new()
                {
                    PedigreeNumber = pedigreeNumber
                };

                Console.WriteLine("ADDITIONAL INFO");
                //Name
                Console.Write("Please enter name of the dog: ");
                dog.Name = Console.ReadLine();

                //BirthDate
                DateTime birthDate;
                bool correctBirthDateInput = false;

                while (correctBirthDateInput == false) // loops until there is a propor input
                {
                    Console.Write("Please enter birthdate (dd-mm-yyyy): "); 
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        correctBirthDateInput = true; // stops the while loop
                    }
                    else if (DateTime.TryParse(input, out birthDate))
                    {
                        dog.BirthDate = birthDate;
                        correctBirthDateInput = true; // stops the while loop
                    }
                    else
                    {
                        Console.WriteLine("The entered birthdate is not in the propor format.");
                        // and the while loop starts over 
                    }
                }

                //Sex
                bool correctSexInput = false;
                char sex;
                
                while (correctSexInput == false)
                {
                    Console.Write("Please enter sex (T for female and H for male): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {

                    }
                    else if (char.TryParse(input, out sex)) // is it posible to parse the input to a char
                    {
                        if (sex == 'h' || sex == 'H')
                        {
                            dog.Sex = 'H';
                            correctSexInput = true;
                        }
                        else if (sex == 't' || sex == 'T')
                        {
                            dog.Sex = 'T';
                            correctSexInput = true;
                        }
                        else // if the input can be converted, but is other than t, T, h or H
                        {
                            Console.WriteLine("The entered sex is not in the propor format.");
                            continue; // go back to the start of the while loop
                        }
                    }
                    else
                    {
                        Console.WriteLine("The entered sex is not in the propor format.");
                        // and the while loop will start over
                    }

                }


                //dog.Sex = char.Parse(Console.ReadLine());

                //ChipNumber
                Console.Write("Please enter chipnumber: ");
                dog.ChipNumber = int.Parse(Console.ReadLine());

                //missing InbreedingCoefficient

                //HdStatus
                Console.Write("Please enter HD-status: ");
                dog.HdStatus = char.Parse(Console.ReadLine());

                //missing HD-index

                //SpondylosisStatus
                Console.Write("Please enter Spondylosis status: ");
                dog.SpondylosisStatus = int.Parse(Console.ReadLine());

                //HeartStatus
                Console.Write("Please enter heart status: ");
                dog.HeartStatus = int.Parse(Console.ReadLine());

                //Color
                Console.Write("Please enter color (RG, TG, RG/HV, TG/HV, hvid, fejl): ");
                dog.Color = Console.ReadLine();

                //Console.Write("Is the dog alive? Press 1 for yes, 0 for no: ");
                //dog.IsAlive = bool.Parse(Console.ReadLine());

                //MomPedigreeNumber
                Console.Write("Please enter pedigree number of the dog's mother: ");
                dog.MomPedigreeNumber = Console.ReadLine();

                //DadPedigreeNumber
                Console.Write("Please enter pedigree number of the dog's father: ");
                dog.DadPedigreeNumber = Console.ReadLine();

                //Owner
                Console.Write("Please enter name of the dog's owner: ");
                dog.Owner = Console.ReadLine();

                //Breeder
                Console.Write("Please enter name of the dog's breeder: ");
                dog.Breeder = Console.ReadLine();

                dogController.CreateDog(dog);

            }
            else
            {
                //ShowDog
            }
        }


        // metode man kan fremsøge hund fra

    }
}
