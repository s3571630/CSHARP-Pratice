using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 同步非同步
{
    public class TimerAndEfficacy
    {
        static Stopwatch read_timer = new Stopwatch();
        static Stopwatch proc_timer = new Stopwatch();
        static Stopwatch write_timer = new Stopwatch();
        static Stopwatch overall_timer = new Stopwatch();
        static Stopwatch read_timer2 = new Stopwatch();
        static Stopwatch proc_timer2 = new Stopwatch();
        static Stopwatch write_timer2 = new Stopwatch();
        static Stopwatch overall_timer2 = new Stopwatch();
        public void ShowNoAsync()
        {
            overall_timer.Start();
            for (int count = 0; count < 5; count++)
            {
                Read();
                Process();
                Write();
            }
            overall_timer.Stop();
            Console.WriteLine("Total Time (over all): {0} ms", overall_timer.ElapsedMilliseconds);
            Console.WriteLine("Total Read Time:       {0} ms", read_timer.ElapsedMilliseconds);
            Console.WriteLine("Total Process Time:    {0} ms", proc_timer.ElapsedMilliseconds);
            Console.WriteLine("Total Write Time:      {0} ms", write_timer.ElapsedMilliseconds);
        }
        public void ShowWithAsync()
        {
            overall_timer2.Start();
            DoWork().Wait();
            overall_timer2.Stop();
            Console.WriteLine("ShowWithAsync Total Time (over all): {0} ms", overall_timer2.ElapsedMilliseconds);
            Console.WriteLine("ShowWithAsync Total Read Time:       {0} ms", read_timer2.ElapsedMilliseconds);
            Console.WriteLine("ShowWithAsync Total Process Time:    {0} ms", proc_timer2.ElapsedMilliseconds);
            Console.WriteLine("ShowWithAsync Total Write Time:      {0} ms", write_timer2.ElapsedMilliseconds);
        }

        private static void Read()
        {
            read_timer.Start();
            Task.Delay(100).Wait();
            read_timer.Stop();
        }
        private static void Process()
        {
            proc_timer.Start();
            Task.Delay(200).Wait();
            proc_timer.Stop();
        }
        private void Write()
        {
            write_timer.Start();
            Task.Delay(300).Wait();
            write_timer.Stop();
        }

        // Async 

        private static void ReadAsync()
        {
            read_timer2.Start();
            Task.Delay(100).Wait();
            read_timer2.Stop();
        }
        private static void ProcessAsync()
        {
            proc_timer2.Start();
            Task.Delay(200).Wait();
            proc_timer2.Stop();
        }

        public static async Task WriteAsync()
        {
            write_timer2.Start();
            await Task.Delay(300);
            write_timer2.Stop();
        }
        private static async Task DoWork()
        {
            Task write_result = null;
            for (int count = 0; count < 5; count++)
            {
                ReadAsync();
                ProcessAsync();
                if (write_result != null) await write_result;
                write_result = WriteAsync();
            }
            await write_result;
        }

    }

}
