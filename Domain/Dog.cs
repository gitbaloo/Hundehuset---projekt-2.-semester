using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset.Domain
{
    public class Dog
    {
        public string PedigreeNumber { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public string ChipNumber { get; set; }
        public double InbreedingCoefficient { get; set; }
        public char HdStatus { get; set; }
        public int HdIndex { get; set; }
        public int SpondylosisStatus { get; set; }
        public int HeartStatus { get; set; }
        public string Color { get; set; }
        public bool IsAlive { get; set; }
        public string MomPedigreeNumber { get; set; }
        public string DadPedigreeNumber { get; set; }
        public string Owner { get; set; }
        public string Breeder { get; set; }

    }
}
