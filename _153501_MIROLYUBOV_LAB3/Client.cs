using System;

namespace _153501_MIROLYUBOV_LAB3
{
    public class Client
    {
        public string Name { get; private set; }
        public List<Contributions>? contributions; 
        
        public Client(string name, float deposit, int procent, string depositName)
        {
            Contributions nw = new Contributions(deposit, procent, depositName);
            contributions = new();
            contributions.Add(nw);
            Name = name;
        }

        private void AddNewContribution(float deposit, int procent, string depositName)
        {
            contributions?.Add(new Contributions(deposit, procent, depositName));
        }

        public void MakeContribution(float dep, int procent, string depositName)
        {
            bool chek = false;
            foreach(var i in contributions)
            {
                if(i.Name == depositName)
                {
                    chek = true;
                    i.IncreaseDep(dep);
                    break;
                }
            }
            if(!chek)
            {
                AddNewContribution(dep, procent, depositName);
            }
        }

        public float GeneralRemains()
        {
            float result = 0;
            foreach(var contribution in contributions)
            {
                result += contribution.GetRemains();
            }
            return result;
        }

        public float GeneralDeposit()
        {
            float result = 0;
            foreach (var contribution in contributions)
            {
                result += contribution.Deposit;
            }
            return result;
        }
    }
}