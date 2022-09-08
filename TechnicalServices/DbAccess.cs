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
        public List<Dog> Dogs { get; set; }

        string path = "Dog.txt";

        public DbAccess()
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                Dogs = new List<Dog>();

                var lines = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                sr.Close();

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] data = lines[i].Split(';');
                    Dogs.Add(new Dog()
                    {
                        Id = int.Parse(data[0]),
                        PedigreeNumber = data[1],
                        Name = data[2],
                        BirthDate = DateTime.Parse(data[3]),
                        Sex = char.Parse(data[4]),
                        ChipNumber = data[5],
                        InbreedingCoefficient = double.Parse(data[6]),
                        HdStatus = char.Parse(data[7]),
                        HdIndex = int.Parse(data[8]),
                        SpondylosisStatus = int.Parse(data[9]),
                        HeartStatus = int.Parse(data[10]),
                        Color = data[11],
                        IsAlive = bool.Parse(data[12]),
                        MomPedigreeNumber = data[13],
                        DadPedigreeNumber = data[14],
                        Owner = data[15],
                        Breeder = data[16]
                    });
                }
            }
            catch (Exception)
            {
                Dogs = new List<Dog>();
            }
        }

        public Dog GetDog(string pedigreeNumber)
        {
            return Dogs.FirstOrDefault(x => x.PedigreeNumber == pedigreeNumber);
        }

        public void AddDog(Dog dog)
        {
            dog.Id = GetId();
            Dogs.Add(dog);
            UpdateDatabase();
        }

        public void UpdateDatabase()
        {
            StreamWriter sw = new StreamWriter(path);

            foreach (var dog in Dogs)
            {
                sw.WriteLine($"{dog.Id};{dog.PedigreeNumber};{dog.Name};{dog.BirthDate};" +
                    $"{dog.Sex};{dog.ChipNumber};{dog.InbreedingCoefficient};{dog.HdStatus};" +
                    $"{dog.HdIndex};{dog.SpondylosisStatus};{dog.HeartStatus};{dog.Color};" +
                    $"{dog.IsAlive};{dog.MomPedigreeNumber};{dog.DadPedigreeNumber};{dog.Owner}" +
                    $";{dog.Breeder}");
            }

            sw.Close();
        }

        private int GetId()
        {
            if (Dogs.Any())
            {
                return Dogs.Max(x => x.Id) + 1;
            }

            return 1;
        }
    }
}
