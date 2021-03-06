﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool canExecute = true;
            string op = string.Empty;
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
                        Demo.DemoHello.Run();
                        break;
                    case "1":
                        Demo.DemoAsync.Run();
                        break;
                    case "exit":
                        canExecute = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("please type any key !");
            Console.ReadKey();
        }

        static void ShowOptions() {
            List<string> optionList = new List<string>();
            optionList.Add("Say Hello");    //0
            optionList.Add("DemoAsync");    //1
            

            Console.WriteLine();
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.Write("{0}. {1}\t\t" , i, optionList[i].ToString());
                if ((i+1) % 3 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("please type 'exit' if you want to exit here");
            Console.WriteLine();
            Console.Write("Please type your selection :");
        }
    }
}
