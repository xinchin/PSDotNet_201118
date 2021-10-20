using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1.Demo
{
    class Test001
    {
        static bool _done;
        static readonly object _locker = new object();
        delegate int D001(string msg);
        static void Main(string[] args)
        {

            Console.WriteLine("------------------Start");
            printThread("Main");

            G1();

            Console.WriteLine("-------------------End");
            Console.ReadLine();

        }

        async static void G1()
        {
            printThread("G1");

            //int result = F1();
            //show(result.ToString());

            //Task<int> result = F1Async();
            //show(result.GetAwaiter().GetResult().ToString());

            //Task<int> result = F1Async();
            //var a = result.GetAwaiter();
            //a.OnCompleted(() =>
            //{
            //    printThread("oncompleted");
            //    show(a.GetResult().ToString());
            //});

            //int result = await F1Async();
            //show(result.ToString());

            Func<Task<int>> F4 = async () => { printThread("F4"); await Task.Delay(1000); Console.WriteLine("F4 End"); return 99; };


            await F4();


            await F2Async();
            Console.WriteLine("G End");

            //TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            //new Thread(()=> {
            //    printThread("new Thread");
            //    Thread.Sleep(2000);
            //    tcs.SetResult(99);
            //}).Start();

            //var a = tcs.Task.GetAwaiter();
            //a.OnCompleted(()=> {
            //    printThread("awaiter");
            //    show(a.GetResult().ToString());
            //});


        }

        static int F1()
        {
            printThread("F1");
            Thread.Sleep(3000);
            return 99;
        }

        static Task<int> F1Async()
        {
            printThread("F1");
            return Task.Run(() =>
            {
                printThread("F1 Run");

                Thread.Sleep(3000);
                return 99;
            });
        }

         async static Task F2Async()
        {
            printThread("F2");
            await Task.Delay(1000);
            int x = await F3Async();
            Console.WriteLine(x.ToString());
            Console.WriteLine("F2 end");
        }

        async static Task<int> F3Async()
        {
            printThread("F3");
            await Task.Delay(1000);
            Console.WriteLine("F3 end");
            return 99;
        }

        static void show(string msg)
        {
            Console.WriteLine(msg);
        }

        static void printThread(string who = "Default")
        {
            Console.WriteLine($"{who} : {Thread.CurrentThread.ManagedThreadId}");
        }





    }
}
