using System;
using Serializer;
using LAB9.Domain;
using System.Collections.Generic;

namespace _053501_Krishtafovich_Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>();
            List<HardDrive> drives = new List<HardDrive>();
            int driveMemory = 300;
            for (int i = 0; i < 6; i++)
            {
                drives.Add(new HardDrive(i, driveMemory));
                computers.Add(new Computer(i, drives));
                driveMemory = driveMemory / 15 * 37 + 1;
            }
            SerializerTool serializer = new SerializerTool();
            string fileXml = "fxml";
            string fileJson = "fjson";
            string fileLinq = "flinq";

            serializer.SerializeXML(computers, fileXml);
            foreach (Computer comp in serializer.DeSerializeXML(fileXml))
            {
                Console.WriteLine(comp);
            }
            serializer.SerializeJSON(computers, fileJson);
            foreach (Computer comp in serializer.DeSerializeJSON(fileJson))
            {
                Console.WriteLine(comp);
            }
            serializer.SerializeByLINQ(computers, fileLinq);
            foreach (Computer comp in serializer.DeSerializeByLINQ(fileLinq))
            {
                Console.WriteLine(comp);
            }
        }
    }
}