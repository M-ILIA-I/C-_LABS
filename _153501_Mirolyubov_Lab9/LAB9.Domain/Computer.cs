using System;
using System.Collections.Generic;
using System.Linq;
namespace LAB9.Domain
{
    public class Computer
    {
        public int Id { get; set; }
        public List<HardDrive> drives { get; set; }
        public Computer()
        {
            drives = new List<HardDrive>();
        }
        public Computer(int id)
        {
            Id = id;
            drives = new List<HardDrive>();
        }
        public Computer(int id, IEnumerable<HardDrive> newDrives)
        {
            Id = id;
            drives = newDrives.ToList();
        }
        public void AddDrives(HardDrive drive)
        {
            drives.Add(drive);
        }
        public override string ToString()
        {
            string newStr = $"Id: {Id}, Hard drives: \n";
            if (drives != null)
            {
                foreach (HardDrive newDrive in drives)
                {
                    newStr += $"Hard drive Id {newDrive.Id}, Memory: {newDrive.AmountOfMemory} \n";
                }
            }
            return newStr;
        }
    }
}
