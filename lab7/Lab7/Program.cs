using il;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
class Program
{
    
    static void Main()
    {
        /* Thread myThread1 = new Thread(() => integral.IntByRect());
         Thread myThread2 = new Thread(() => integral.IntByRect());

         myThread1.Priority = ThreadPriority.Lowest;
         myThread2.Priority = ThreadPriority.Highest;

         myThread1.Start();
         myThread1.Start()*/

        Semaphore sem = new Semaphore(1, 5);
        for(int i = 0; i < 6; i++)
        {
            Thread myThread = new Thread(() => integral.IntByRect());
            myThread.Name = i.ToString();
            myThread.Start();
        }
    }
}
