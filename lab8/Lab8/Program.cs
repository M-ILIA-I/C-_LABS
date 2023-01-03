using Stream_service;
class Program
{
    static async Task Main()
    {
        object locker = new object();
        Semaphore sem = new Semaphore(1, 1);
        StreamService sv = new StreamService();
        List<Student> lst = new List<Student>();

        Console.WriteLine("Begin main program " + Thread.CurrentThread.ManagedThreadId);
     
        for (int i = 0; i < 10; i++)
        {
            lst.Add(new Student(i, "Name" + i, (i + 20) / 2));
        }

        

        string fullFileName = "test";
        MemoryStream memoryStream = new MemoryStream();

        
        var writeTask = sv.WriteToStreamAsync(memoryStream, lst);
        
        Thread.Sleep(1000);
        
        var copyTask = sv.CopyFromStreamAsync(memoryStream, fullFileName);
        
        
        Console.WriteLine("Begin method 1 and 2 " + Thread.CurrentThread.ManagedThreadId);
        //Task.WaitAll(new Task[] { writeTask, copyTask });
        int statisticAmount = await sv.GetStatisticsAsync(fullFileName, (Student) => { return (Student.exelentStudent == true) ? true : false; });
        Console.WriteLine("Amount of exelent students: " + statisticAmount);
        Console.WriteLine("End main program " + Thread.CurrentThread.ManagedThreadId);
    }
}
