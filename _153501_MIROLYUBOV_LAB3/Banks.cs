using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _153501_MIROLYUBOV_LAB3
{
    internal class Banks
    {
        public delegate void EventHandler(string massage);
        public event EventHandler Change; 
        public event EventHandler Registration;
        
        public Dictionary<string, Contributions> percentRate;
        private List<Client> clients { get; set; }

        public Banks()
        {
            percentRate = new();
            clients = new();
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
            if (percentRate.ContainsKey(client.contributions[client.contributions.Count - 1].Name) == false)
            {
                percentRate.Add(client.contributions[client.contributions.Count - 1].Name, client.contributions[client.contributions.Count - 1]);
            }
            Registration.Invoke("New client was added");
        }

        public void AddDeposit(Client client, float dep, int procent, string name)
        {
            if(clients?.Contains(client) == null)
            {
                clients?.Add(client);
            }
            client.MakeContribution(dep, procent, name);
            if (percentRate?.ContainsKey(name) == null)
            {
                percentRate?.Add(name, new Contributions(dep, procent, name));
            }
        }
        private float GeneralDeposit(Client client)
        {
            float result = 0;

            foreach (var i in clients)
            {
                if (i.Equals(client))
                {
                    foreach(var j in i.contributions)
                    {
                        result += j.GetRemains();
                    }
                }
            }
            return result;
        }

        private Client GetClient(int num)
        {
            if (num < 0 || num > clients.Count)
            {
                throw new Exception("index out of range");
            }
            else
            {
                return clients[num];
            }
        }


        public List<string> GetPercentRate()
        {
            List<string> orderedPercent = new List<string>(); 
            foreach(var pair in percentRate.OrderBy(pair => pair.Value.Percent))
            {
                orderedPercent.Add(pair.Key);
            
            }
            return orderedPercent;
        }

        public float GetGeneralPercent()
        {
            float result = 0;
            foreach (var client in clients)
            {
                foreach(var contribution in client.contributions)
                {
                    result += contribution.GetRemains();
                }
            }
            return result;
        }

        public float GetGeneralBankDeposit()
        {
            float result = 0;
            foreach (var client in clients)
            {
                result += client.GeneralDeposit();
            }
            return result;
        }

        public string GetVipClient()
        {
            int index = 0;
            float maxRemain = 0;
            for(int i = 0; i < clients.Count; i++)
            {
                if(maxRemain < clients[i].GeneralRemains())
                {
                    maxRemain = clients[i].GeneralRemains();
                    index = i;
                }
            }
            return clients[index].Name;
        }

        public int CountClientsWhoPayMoreConsSumm(float money)
        {
            int count = clients.Aggregate(0, (total, next) => next.GeneralDeposit() > money ? total + 1 : total) ;
            return count;      
        }

        public List<float> CummonClientProcentGroup()
        {
            List<float> result = new List<float>();
            var query = clients.GroupBy(client => client.GeneralRemains());
            foreach(var i in query)
            {
                result.Add(i.Key);
            }
            return result;
        }
    }
}
