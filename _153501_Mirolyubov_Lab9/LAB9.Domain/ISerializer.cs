using System.Collections.Generic;

namespace LAB9.Domain
{
    public interface ISerializer
    {
        IEnumerable<Computer> DeSerializeByLINQ(string fileName);
        IEnumerable<Computer> DeSerializeXML(string fileName);
        IEnumerable<Computer> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Computer> xxx, string fileName);
        void SerializeXML(IEnumerable<Computer> xxx, string fileName);
        void SerializeJSON(IEnumerable<Computer> xxx, string fileName);
    }
}