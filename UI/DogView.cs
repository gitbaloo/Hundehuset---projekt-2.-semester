﻿using Hundehuset.Domain;
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
                Console.Write("Please enter name of the dog: ");
                dog.Name = Console.ReadLine();

                Console.Write("Please enter birthdate (dd-mm-yyyy): ");
                dog.BirthDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Please enter sex (T for female and H for male): ");
                dog.Sex = char.Parse(Console.ReadLine());

                Console.Write("Please enter chipnumber: ");
                dog.ChipNumber = int.Parse(Console.ReadLine());

                //missing InbreedingCoefficient

                Console.Write("Please enter HD-status: ");
                dog.HdStatus = char.Parse(Console.ReadLine());

                //missing HD-index

                Console.Write("Please enter Spondylosis status: ");
                dog.SpondylosisStatus = int.Parse(Console.ReadLine());

                Console.Write("Please enter heart status: ");
                dog.HeartStatus = int.Parse(Console.ReadLine());

                Console.Write("Please enter color (RG, TG, RG/HV, TG/HV, hvid, fejl): ");
                dog.Color = Console.ReadLine();

                //Console.Write("Is the dog alive? Press 1 for yes, 0 for no: ");
                //dog.IsAlive = bool.Parse(Console.ReadLine());

                Console.Write("Please enter pedigree number of the dog's mother: ");
                dog.MomPedigreeNumber = Console.ReadLine();

                Console.Write("Please enter pedigree number of the dog's father: ");
                dog.DadPedigreeNumber = Console.ReadLine();

                Console.Write("Please enter name of the dog's owner: ");
                dog.Owner = Console.ReadLine();

                Console.Write("Please enter name of the dog's breeder: ");
                dog.Breeder = Console.ReadLine();

                dogController.CreateDog(dog);

                //ShowDog

            }
            else
            {

            }
        }


        // metode man kan fremsøge hund fra

    }
}
