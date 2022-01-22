using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsAppLib.MultiThread
{
    public class TaskExample
    {
        /*
         * Two main strategies for paritioning work among threads
         * a) Data Parallelism - partitions the data between threads (ex: RunAsParallel())
         * b) Task Parallelism - partitions the tasks - each thread performs a different task
         * 
         */
        public void RunATask()
        {
            Task.Run(()=> 
            {
                Console.WriteLine("my first task");
                for (int i = 1; i < 10; i++)
                {
                    var result = i * i;
                    Console.WriteLine($"{i}, result={result}");
                }
            });
        }
        public void RunATask2()
        {
            Task task = Task.Run(() =>
                {
                    Console.WriteLine("my first task");
                    for (int i = 1; i < 10; i++)
                    {
                        Thread.Sleep(1000);
                        var result = i * i;
                        Console.WriteLine($"{i}, result={result}");
                    }
                });
            Console.WriteLine(task.IsCompleted); // false
            task.Wait(); // wait(block) for the task to finish
        }
        public void RunATask3()
        {
            Task<int> task = Task.Run(() =>
                {
                    Console.WriteLine("this task returns an int");
                    return 3;
                });
            int result = task.Result; // block if the task is not already finished
            Console.WriteLine($"task.result={result}");
        }
        public void RunATask4()
        {
            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine("this task will throw an exception");
                int i = 10;
                int j = 0;
                return i/j;
            });
            int result = task.Result; // block if the task is not already finished
            Console.WriteLine($"task.result={result}");
        }
        public void RunAsParallel()
        {
            // example using PLINQ
            var s ="The quick brown fox jumped over the hill";
            Console.WriteLine(s);
            var r = s
                .AsParallel().WithDegreeOfParallelism(2) // number of threads allowed to run concurrently
                .Where(c => !char.IsWhiteSpace(c)) // selecting the characters based on a condtition
                .AsParallel().WithDegreeOfParallelism(3)
                .Select(c => char.ToUpper(c)); // do an operation on each character

            var result = new string(r.ToArray());
            Console.WriteLine(result);
        }
        public void RunAsParallel2()
        {
            // example using PLINQ
            var s = "abcdthequickbrownfoxjumpedoverthehillxyz";
            Console.WriteLine(s);
            s.AsParallel()
             .Select(c => char.ToUpper(c))
             .ForAll(Console.Write);
            
        }
    }
}
