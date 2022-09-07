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
        List<Dog> dogs;

        public DbAccess()
        {
            dogs = new List<Dog>();
        }

        /*public bool IsDogInDatabase(string pedigreeNumber)
        {
            if (dogs.Any())
            {
                return dogs.Any(dog => dog.PedigreeNumber == pedigreeNumber);
            }
            
            return false;
        }
        */
        public Dog GetDog(string pedigreeNumber)
        {
            return dogs.FirstOrDefault(x => x.PedigreeNumber == pedigreeNumber);
        }

        public void AddDog(Dog dog)
        {
            dogs.Add(dog);
        }
    }
}
