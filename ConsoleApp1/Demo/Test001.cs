using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace ConsoleApp1.Demo
{
    static class Test001
    {
        static bool _done;
        static readonly object _locker = new object();
        delegate int D001(string msg);
        static void Main(string[] args)
        {

            Console.WriteLine("------------------ Start ------------------");

            Foo f1 = new Foo(10);
            Foo f2 = f1 + 5;

            Console.WriteLine($"f1:{f1.myValue}, f2:{f2.myValue}");


            Console.ReadKey();
            Console.WriteLine("------------------ End ------------------");
        }

    }

    public class Foo {
        public int myValue;
        public Foo(int x) {
            myValue = x;
        }

        public static Foo operator +(Foo f, int x) =>  new Foo(f.myValue + x);
        
    }

}
