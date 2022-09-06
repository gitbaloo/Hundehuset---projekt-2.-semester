using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundehuset
{
    class Dog
    {
        public string pedigreeNumber { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public char sex { get; set; }
        public int chipNumber { get; set; }
        public double inbreedingCoefficient { get; set; }
        public char hdStatus { get; set; }
        public int hdIndex { get; set; }
        public int spondylosisStatus { get; set; }
        public int heartStatus { get; set; }
        public string colour { get; set; }
        public bool isAlive { get; set; }
        public string momPedigreeNumber { get; set; }
        public string dadPedigreeNumber { get; set; }
        public string owner { get; set; }
        public string breeder { get; set; }

    }
}
