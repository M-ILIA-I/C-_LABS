
using System;
using System.Data;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;



namespace Stream_service
{
   
    public class StreamService 
    {
        static object locker = new object();
        
        public async Task  WriteToStreamAsync(Stream stream, IEnumerable<Student> data, IProgress<string> progress)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Begin writing " + Thread.CurrentThread.ManagedThreadId);
                BinaryFormatter bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    ms.Seek(0, SeekOrigin.End);
                    lock (locker)
                    {
                        foreach (Student student in data)
                        {
                            stream.Write(System.Text.Encoding.UTF8.GetBytes((student.id + " ").ToString()));
                            stream.Write(System.Text.Encoding.UTF8.GetBytes(student.name + " "));
                            stream.Write(System.Text.Encoding.UTF8.GetBytes((student.exelentStudent+"\n").ToString()));
                            progress.Report("Progress:" + student.id);
                        }
                        
                    }
                }
                Console.WriteLine("End writing " + Thread.CurrentThread.ManagedThreadId);
            }); 
        }

        public async Task CopyFromStreamAsync(Stream stream, string filename)
        {
            string fullPath = "E:\\C# Labs\\lab8\\" + filename + ".txt";
            await Task.Run(() =>
            {
                Console.WriteLine("Begin copy " + Thread.CurrentThread.ManagedThreadId);
                stream.Seek(0, SeekOrigin.Begin);

                lock (locker)
                {
                  
                        byte[] array = new byte[stream.Length];
                        stream.Read(array, 0, array.Length);
                        string textFromStream = System.Text.Encoding.Default.GetString(array);

                        File.WriteAllText(fullPath, textFromStream);
                    
                }

                Console.WriteLine("End copy " + Thread.CurrentThread.ManagedThreadId);

            });

        }

        public async Task<int> GetStatisticsAsync(string fileName, Func<Student, bool> filter)
        {
            string fullPath = "E:\\C# Labs\\lab8\\" + fileName + ".txt";
            int num = 0;
            await Task.Run(() =>
            {
                string textFromFile = null;
                lock (locker)
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
                    {
                        byte[] array = new byte[stream.Length];
                        stream.Read(array, 0, array.Length);
                        textFromFile = System.Text.Encoding.Default.GetString(array);

                    }

                    string[] studentStr = textFromFile?.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    List<Student> students = new List<Student>();
                    foreach (string student in studentStr)
                    {
                        
                        string[] studentElement = student.Split(' ');
                        students.Add(new Student(Convert.ToInt32(studentElement[0]), studentElement[1], Convert.ToBoolean(studentElement[2]))); 
                    }
                    foreach (Student student in students)
                    {
                        if (filter(student) == true)
                        {
                            num++;
                        }
                    }
                   

                }
            });
            return num;
        }
        
        
    }
}