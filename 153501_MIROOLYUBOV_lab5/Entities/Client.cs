using _153501_MIROOLYUBOV_lab5.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROOLYUBOV_lab5.Entities
{
    internal class Client
    {
        public static int id = 0;
        public int ID = 0;
        public string Name { get; private set; }
        public MyCustomCollection<Deposit> deposit;
        public Client(string name)
        {
            deposit = new MyCustomCollection<Deposit>();
            Name = name;
            id++;
            ID = id;
        }

        public void AddDeposit(double summ, int procent)
        {
            Deposit nw_dpt = new Deposit(summ, procent);
            deposit.Add(nw_dpt);
        }
    }
}

