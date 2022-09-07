using Hundehuset.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.Domain
{
    public class DogController
    {
        DbAccess dbAccess = new();

        public bool IsDogInDatabase(string pedigreeNumber)
        {
            Dog dog = dbAccess.GetDog(pedigreeNumber);

            return dog == null ? false : true;
        }

        public void CreateDog(Dog dog)
        {
            dbAccess.AddDog(dog);
        }
        public Dog GetDog(string pedigreeNumber)
        {
            return dbAccess.GetDog(pedigreeNumber);
        }

        /*
        public Dog CreateDog(string pedigreeNumber)
        {
            if (!dbAccess.IsDogInDatabase(pedigreeNumber))
            {
                dog = new Dog()
                {
                    PedigreeNumber = pedigreeNumber
                };
                //add dog to database
                dbAccess.addDog(dog);
            }
            // else, if dog exists in database 

            return dog;
        }

        public void UpdateDog(Dog dog)
        {
            //adjust dog in database
        }
        */
    }

}



