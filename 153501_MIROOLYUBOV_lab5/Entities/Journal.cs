using _153501_MIROOLYUBOV_lab5.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROOLYUBOV_lab5.Entities
{
    internal class Journal
    {
        MyCustomCollection<string> writtenEvents;
        public Journal()
        {
            writtenEvents = new MyCustomCollection<string>();
        }
        public void TakeNewNote(string message)
        {
            //Console.WriteLine(message);
            writtenEvents.Add(message);
        }
        public void PrintJournal()
        {
            for (int i = 0; i < writtenEvents.Count; i++)
            {
                Console.WriteLine(writtenEvents[i]);
            }
        }
    }
}
