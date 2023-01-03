using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Mirolyubov_lab4
{
    internal class  MyCustomComparer:IComparer<Car>
    {
        public int Compare(Car e1, Car e2)
        {
            return String.Compare(e1.Name, e2.Name);
        }
    }
}
