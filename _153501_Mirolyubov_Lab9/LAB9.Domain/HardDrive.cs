using System;

namespace LAB9.Domain
{
    public class HardDrive
    {
        public int Id { get; set; }
        public int AmountOfMemory { get; set; }
        public HardDrive() { }
        public HardDrive(int id, int memory)
        {
            Id = id;
            AmountOfMemory = memory;
        }

    }
}
