using System;
using LAB9.Domain;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace Serializer
{
    public class SerializerTool : ISerializer
    {
        string path = @"E:\C# Labs\_153501_ Mirolyubov_Lab9\";
        public void SerializeXML(IEnumerable<Computer> xxx, string fileName)
        {
            string fullFileName = path + fileName + ".xml";
            XmlSerializer formatter = new XmlSerializer(xxx.GetType());
            using (FileStream stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, xxx);
            }
            Console.WriteLine("Serialization using XmlSerializer");
        }
        public IEnumerable<Computer> DeSerializeXML(string fileName)
        {
            string fullFileName = path + fileName + ".xml";
            IEnumerable<Computer> newComputers = null;
            XmlSerializer formatter = new XmlSerializer(typeof(Computer[]));
            using (FileStream stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            {
                newComputers = (IEnumerable<Computer>)formatter.Deserialize(stream);
            }
            Console.WriteLine("Deserialization using XmlSerializer");
            return newComputers;
        }
        public void SerializeJSON(IEnumerable<Computer> xxx, string fileName)
        {
            string fullFileName = path + fileName + ".json";
            var options = new JsonWriterOptions
            {
                Indented = true,
            };
            using (FileStream stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
            {
                JsonSerializer.Serialize(writer, xxx);
            }
            Console.WriteLine("Serialization into Json file");
        }
        public IEnumerable<Computer> DeSerializeJSON(string fileName)
        {
            string fullFileName = path + fileName + ".json";
            IEnumerable<Computer> newComputers;
            string jsonString = File.ReadAllText(fullFileName);
            newComputers = JsonSerializer.Deserialize<IEnumerable<Computer>>(jsonString);
            Console.WriteLine("Deserialization from Json");
            return newComputers;
        }
        public void SerializeByLINQ(IEnumerable<Computer> xxx, string fileName)
        {
            string fullFileName = path + fileName + ".xml";
            XDocument xdoc = new XDocument();
            XElement computers = new XElement("Computers");
            foreach (Computer item in xxx)
            {
                XElement comp = new XElement("Computer");
                comp.Add(new XElement("Id", item.Id));
                if (item.drives != null)
                {
                    XElement drives = new XElement("Drives");
                    foreach (HardDrive drive in item.drives)
                    {
                        XElement hardDrive = new XElement("HardDrive");
                        hardDrive.Add(new XElement("Id", drive.Id));
                        hardDrive.Add(new XElement("Memory", drive.AmountOfMemory));
                        drives.Add(new XElement(hardDrive));
                    }
                    comp.Add(drives);
                }
                computers.Add(comp);
            }
            xdoc.Add(computers);
            xdoc.Save(fullFileName);
            Console.WriteLine("Serialization with Linq");
        }
        public IEnumerable<Computer> DeSerializeByLINQ(string fileName)
        {
            List<Computer> computersList = new List<Computer>();
            string fullFileName = path + fileName + ".xml";
            XDocument xdoc = XDocument.Load(fullFileName);
            XElement computersListXml = xdoc.Element("Computers");
            foreach (XElement computers in computersListXml.Elements())
            {
                Computer comp = new Computer();
                comp.Id = (int)computers.Element("Id");
                XElement drives = computers?.Element("Drives");
                if (drives != null)
                {
                    foreach (XElement driveXml in drives.Elements())
                    {
                        HardDrive drive = new HardDrive();
                        drive.Id = (int)driveXml.Element("Id");
                        drive.AmountOfMemory = (int)driveXml.Element("Memory");
                        comp.AddDrives(drive);
                    }
                }
                computersList.Add(comp);
            }
            Console.WriteLine("Deserialization with Linq");
            return computersList;
        }
    }
}