using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Mirolyubov_lab4
{
    interface IFileService
    {
        IEnumerable<Car> ReadFile(string fileName);
        void SaveData(IEnumerable<Car> data, string fileName);
    }
}

