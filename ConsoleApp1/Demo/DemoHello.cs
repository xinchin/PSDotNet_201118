using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Demo
{
    class DemoHello:DemoBase
    {
        
        public static void Run()
        {
            bool canExecute = true;
            string op = string.Empty;

            optionList.Add("Hello 001");    //0
            optionList.Add("Hello 002");    //1

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
                        Console.WriteLine("------------ Hello 001 ---------------");
                        break;
                    case "1":
                        Console.WriteLine("------------ Hello 002 ---------------");
                        break;
                    case "exit":
                        canExecute = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}

