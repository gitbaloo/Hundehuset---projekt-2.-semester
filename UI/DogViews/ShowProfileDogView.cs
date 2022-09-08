using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.UI.DogViews
{
    public class ShowProfileDogView
    {
        public void ShowView(Dog dog)
        {
            Console.WriteLine("Showing profile for {0} ({1})", dog.Name, dog.PedigreeNumber);
            Console.WriteLine();
            Console.WriteLine("Pedigree Number: {0}", dog.PedigreeNumber);
            Console.WriteLine("Name: {0}", dog.Name);
            Console.WriteLine("Birth Date: {0}", dog.BirthDate);
            Console.WriteLine("Sex: {0}", dog.Sex);
            Console.WriteLine("Chip Number: {0}", dog.ChipNumber);
            Console.WriteLine("Inbreeding Coefficient: {0}", dog.InbreedingCoefficient);
            Console.WriteLine("HD-Status: {0}", dog.HdStatus);
            Console.WriteLine("HD-Index: {0}", dog.HdIndex);
            Console.WriteLine("Spondylosis Status: {0}", dog.SpondylosisStatus);
            Console.WriteLine("Heart Status: {0}", dog.HeartStatus);
            Console.WriteLine("Color: {0}", dog.Color);
            string Status;
            if (dog.IsAlive)
                Status = "Alive";
            else
                Status = "Deceased";
            Console.WriteLine("Status: {0}", Status);
            Console.WriteLine("Mom's Pedigree Number: {0}", dog.MomPedigreeNumber);
            Console.WriteLine("Dad's Pedigree Number: {0}", dog.DadPedigreeNumber);
            Console.WriteLine("Owner: {0}", dog.Owner);
            Console.WriteLine("Breeder: {0}", dog.Breeder);
        }
    }
}
