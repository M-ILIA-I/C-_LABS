using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROLYUBOV_LAB3
{
    public class Journal
    {
        private List<string> eventJournal;
        
        public Journal()
        {
            eventJournal = new List<string>();
        }

        public void TakeNewNote(string massege)
        {
            eventJournal.Add(massege);
        }
        public void PrintJournal()
        {
            foreach (string i in eventJournal)
            {
                Console.WriteLine(i);
            }
        }
    }
}
