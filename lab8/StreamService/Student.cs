using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_service
{
    [Serializable]
    public class Student
    {
        public int id{ get; private set; }
        public string name{ get; private set; }
        public bool exelentStudent { get; private set; }

        public Student(int id, string name, bool mark)
        {
            this.id = id;
            this.name = name;
            exelentStudent = mark;
        }
            public Student(int id, string name, double mark)
        {
            this.id = id;
            this.name = name;
            if(mark > 9)
            {
                exelentStudent = true;
            }
            else
            {
                exelentStudent = false;
            }
        }

    }
}
