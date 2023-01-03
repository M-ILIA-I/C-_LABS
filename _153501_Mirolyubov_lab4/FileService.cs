using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153501_Mirolyubov_lab4
{
    class FileService : IFileService
    {
        public IEnumerable<Car> ReadFile(string fileName)
        {

            string carName;
            int horsePower;
            bool age;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.PeekChar() != -1)
                    {
                        carName = br.ReadString();
                        horsePower = br.ReadInt32();
                        age = br.ReadBoolean();

                        yield return new Car(carName, horsePower, age);
                    }
                }
            }
        }
        public void SaveData(IEnumerable<Car> data, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (Car i in data)
                    {
                        bw.Write(i.Name);
                        bw.Write(i.HorsePower);
                        bw.Write(i.olderThan2000);
                    }

                }
            }
        }
    }
}