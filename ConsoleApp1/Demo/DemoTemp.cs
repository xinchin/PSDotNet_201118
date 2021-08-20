using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Demo
{

    class DemoTemp : DemoBase
    {

        public static void Run()
        {
            bool canExecute = true;
            string op = string.Empty;

            Console.Clear();
            optionList.Clear();
            optionList.Add("Hello...");                    //0

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
                        SayHello();
                        break;

                    case "exit":
                        canExecute = false;
                        break;
                    default:
                        break;
                }
            }
        }


        public static void SayHello()
        {
            Console.Clear();
            Console.WriteLine(Program.LineString);

            Console.WriteLine("......Hello World ....");
        }
    }
}
