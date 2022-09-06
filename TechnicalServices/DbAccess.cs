using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.TechnicalServices
{
    public class DbAccess
    {
        List<Dog> dogs = new();

        public bool IsDogInDatabase(string pedigreeNumber)
        {
            /*if (dogs.Any())
            {
                return dogs.Any(dog => dog.PedigreeNumber == pedigreeNumber);
            }
            */
            return false;
        }

        public void addDog(Dog dog)
        {
            dogs.Add(dog);
        }
    }
}
