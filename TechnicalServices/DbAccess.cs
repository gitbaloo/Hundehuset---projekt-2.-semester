using Hundehuset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.TechnicalServices
{
    //DbAccess created as a singleton

    public sealed class DbAccess
    {
        public List<Dog> Dogs { get; set; }

        private string path = "Dog.txt";

        private static readonly DbAccess _instance = new DbAccess();

        public static DbAccess Instance
        {
            get { return _instance; }
        }

        static DbAccess()
        {
        }

        private DbAccess()
        {
            //Ved instansiering af DbAccess forsøges det at hente en eksisterende database
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
                        BirthDate = data[3] == null ? null : DateTime.Parse(data[3]), //Denne property er nullable, så der parses til null eller DateTime
                        Sex = data[4] == null ? null : char.Parse(data[4]), //Denne property er nullable
                        ChipNumber = data[5],
                        InbreedingCoefficient = double.TryParse(data[6], out double ic) == false ? null : ic, //Denne property er nullable
                        HdStatus = data[7] == null ? null : char.Parse(data[7]), //Denne property er nullable
                        HdIndex = int.TryParse(data[8], out int hi) == false ? null : hi, //Denne property er nullable
                        SpondylosisStatus = int.TryParse(data[9], out int ss) == false ? null: ss, //Denne property er nullable
                        HeartStatus = int.TryParse(data[10], out int hs) == false ? null : hs, //Denne property er nullable
                        Color = data[11],
                        IsAlive = bool.Parse(data[12]),
                        MomPedigreeNumber = data[13],
                        DadPedigreeNumber = data[14],
                        Owner = data[15],
                        Breeder = data[16]
                    });
                }


            }
            //Hvis databasen ikke eksisterer oprettes en ny tom liste.
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

        //Tekstfilen overskrives med den information, der ligger i listen Dogs
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
