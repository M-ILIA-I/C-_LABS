using System;
using System.Diagnostics;
using System.Net.Sockets;
using lib;

namespace il
{
    
    public class integral
    {
        static Semaphore sem = new Semaphore(3, 3);
        delegate void Del(string data);
        static event Del? SomeEvent = new Del(Event.Print);
        static public double IntByRect()
        {
            sem.WaitOne();

            var sw = new Stopwatch();
            sw.Start();

            double h = 0.000001, x = 0, result = 0;
            int l = 0, r = 1, p = 0;
            while(x <= r)
            {
                if (p <= 100 * x)
                {
                    if (Convert.ToDouble(Thread.CurrentThread.Name) % 2 == 0)
                    {
                        SomeEvent?.Invoke($"Поток {Thread.CurrentThread.ManagedThreadId} ======> {p}%");
                    }
                    else
                    {
                        SomeEvent?.Invoke($"\t\t\tПоток {Thread.CurrentThread.ManagedThreadId} ======> {p}%");
                    }
                    p++;
                }

                x = x + h;    
                result += Math.Sin(x);

                for(int i = 0; i != 10000; i++)
                {
                    l = i * i;
                }
                
            }
            double final_result = result * h;

            sw.Stop();
            SomeEvent?.Invoke($"\n\nПоток {Thread.CurrentThread.ManagedThreadId}: Завершен с результатом: {final_result}");
            SomeEvent?.Invoke($"Затраченное время потоком{Thread.CurrentThread.ManagedThreadId}: {sw.ElapsedMilliseconds} милисекунд");
            sem.Release();
            return final_result;
        }
         
    }
}