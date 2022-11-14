using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_MIROOLYUBOV_lab5.Interfaces
{
     public interface ICustomCollection<T>
     {
        T this[int index]{ get; set; }
        void Reset();
        void Next();
        T Current();
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
     }
}
