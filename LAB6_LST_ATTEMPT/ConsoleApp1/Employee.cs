using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool GetReward { get; set; }
        public Employee()
        {
            Name = null;
            Salary = 0;
            GetReward = false;
        }
        public Employee(string name, int salary, bool reward)
        {
            Name = name;
            Salary = salary;
            GetReward = reward;
        }
        public override string ToString()
        {
            string result = $"Name: {this.Name}, Salary {this.Salary}, Is getting reward {GetReward}";
            return result;
        }
    }
}
