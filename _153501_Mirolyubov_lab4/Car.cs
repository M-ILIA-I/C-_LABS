using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Mirolyubov_lab4
{
    internal class Car
    {
        public string Name { get; private set; }
        public int HorsePower { get; private set; }
        public bool olderThan2000 { get; private set; }

        public Car(string name, int horsePower, int releaseDate)
        {
            Name = name;
            HorsePower = horsePower;
            if(releaseDate < 2000)
            {
                olderThan2000 = true;
            }
            else
            {
                olderThan2000 = false;
            }
        }
        public Car(string name, int horsePower, bool releaseDate)
        {
            Name = name;
            HorsePower = horsePower;
            olderThan2000 = releaseDate;
        }
    }
}
