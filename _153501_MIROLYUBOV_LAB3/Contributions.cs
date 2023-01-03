using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROLYUBOV_LAB3
{
    public class Contributions
    {
        public float Deposit { get; private set; }
        public string Name { get; private set; }
        public int Percent { get; private set; }

        public Contributions(float deposit, int percent, string name)
        {
            this.Deposit = deposit;
            Percent = percent;
            this.Name = name;
        }


        
        public void IncreaseDep(float dep)
        {
            Deposit += dep;
        }

        public float GetRemains()
        {
            return Deposit * Percent / 100;
        }
    }
}
