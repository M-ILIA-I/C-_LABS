using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROOLYUBOV_lab5.Entities
{
    internal class Deposit
    {
        public double Remains { get; private set; }
        
        public int Procent { get; private set; }
        public Deposit(double sum, int procent)
        {
            Remains = sum;
            Procent = procent;
        }
        public double CalculateProcentSum()
        {
            return Remains * Procent / 100;
        }

        public void NewContribution(double summ)
        {
            Remains += summ;
        }
    }

}
