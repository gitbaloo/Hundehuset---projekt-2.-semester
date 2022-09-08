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
        private DbAccess dbAccess;

        public DogController()
        {
            dbAccess = new DbAccess();
        }

        public bool IsDogInDatabase(string pedigreeNumber)
        {
            Dog dog = dbAccess.GetDog(pedigreeNumber);

            return dog == null ? false : true;
        }

        public bool CreateDog(Dog dog)
        {
            if (!IsDogInDatabase(dog.PedigreeNumber))
            {
                dbAccess.AddDog(dog);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dog GetDog(string pedigreeNumber)
        {
            return dbAccess.GetDog(pedigreeNumber);
        }
    }
}



