using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Demo
{
    class DemoPractice1 : DemoBase
    {
        public static void Run()
        {
            bool canExecute = true;
            string op = string.Empty;

            Console.Clear();
            optionList.Clear();
            optionList.Add("Extension");                    //0


            while (canExecute)
            {
                ShowOptions();
                op = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Your selection is： {0}", op);
                Console.WriteLine();
                switch (op)
                {
                    case "0":
                        TestExtension();
                        break;

                    case "exit":
                        canExecute = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void SayHello() {
            Console.Clear();
            Console.WriteLine(Program.LineString);
            Console.WriteLine("Hello Practice 1");
        }

        public static void TestExtension() {
            Console.Clear();
            Console.WriteLine(Program.LineString);
            string s1 = "Hello World !";
            int cc = s1.GetWordCount();
            Console.WriteLine(cc.ToString());
            cc.ShowValue();

            MyUser u1 = new MyUser();
            u1.Name = "Nelson";
            u1.ShowUser();
            u1.ShowAll();

            var hello = new HelloCollection();
            foreach (var o in hello) {
                Console.WriteLine(o);
            }

        }
    }

    public class MyUser {
        public string Name { get; set; }
    }

    public class HelloCollection {
        public IEnumerator<string> GetEnumerator() {
            yield return "Hello";
            yield return "World";
        }
    }



    public static class MyExtension{
        public static int GetWordCount(this string s) => s.Split().Length;
        public static void ShowValue(this int n) => Console.WriteLine((n+100).ToString());
        public static void ShowUser(this MyUser u) => Console.WriteLine($"Hello {u.Name}");

        public static void ShowAll(this object o) => Console.WriteLine(o.ToString());
    }
}
