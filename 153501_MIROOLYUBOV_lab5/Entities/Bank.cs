using _153501_MIROOLYUBOV_lab5.Collections;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _153501_MIROOLYUBOV_lab5.Entities
{
    internal class Bank
    {
        private string name;
        private MyCustomCollection<Client> clients;
        public MyCustomCollection<int> interestRate;

        
        public delegate void EventHandler(string massage);
        public event EventHandler? Changed ;
        public event EventHandler? Registrated;
       

        public Bank(string name)
        {
            this.name = name;
            clients = new MyCustomCollection<Client>();
            interestRate = new MyCustomCollection<int>();
            interestRate.Add(10);
            interestRate.Add(30);
            interestRate.Add(50);
            interestRate.Add(70);
        }
        public void AddNewClient(Client client, double summ, int procent)
        {
            clients.Add(client);
            client.AddDeposit(summ, procent);
            Changed?.Invoke($"new client {client.Name} was added");
        }

        public void NewDeposit(Client client, double summ, int interest_rate)
        {
            int i = 0;
            int chek = 0;
            while (!clients[i].Equals(client))
            {
                i++;
                if (i >= clients.Count)
                {
                    chek = 1;
                    break;
                }
                
            }
            if(chek != 1)
            {
                int j = 0;
                chek = 0;
                while (clients[i].deposit[j].Procent != interest_rate)
                {
                    j++;
                    if (j >= clients[i].deposit.Count)
                    {
                        chek = 1;
                        break;
                    }
                    
                }
                if(chek == 1)
                {
                    Deposit nw_dpt = new Deposit(summ, interest_rate);
                    clients[i].deposit.Add(nw_dpt);
                    Registrated?.Invoke("New deposit was Registrated");
                }
                else
                {
                    clients[i].deposit[j].NewContribution(summ);
                    Changed?.Invoke($"new  deposit {summ} was added");
                }
                
            }
            else
            {
                Console.WriteLine("Такого клиента не существует");
            }
            
            
        }

        public double GeneralPayment(Client client)
        {
            double res = 0;
            int i = 0;
            while(i < client.deposit.Count)
            {
                res += client.deposit[i].CalculateProcentSum();
                i++;
            }
            Changed?.Invoke("General payment was counted");
            return res;
           
        }
    }
}