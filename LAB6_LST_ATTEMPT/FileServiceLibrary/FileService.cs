using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using lab6;

namespace FileServiceLibrary
{
    public class FileService<T> : IFileService<T> where T : class
    {
        string path = "E:\\C# Labs\\LAB6_LST_ATTEMPT";
        public IEnumerable<T> ReadFile(string fileName)
        {
            string fullFileName = path + fileName + ".json";
            IEnumerable<T> newEnum;
            string jsonString = File.ReadAllText(fullFileName);
            newEnum = JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);
            return newEnum;
        }
        public void SaveData(IEnumerable<T> data, string fileName)
        {
            string fullFileName = path + fileName + ".json";
            var options = new JsonWriterOptions
            {
                Indented = true,
            };
            using (FileStream stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
            {
                JsonSerializer.Serialize(writer, data);
            }
        }
    }
}