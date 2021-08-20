using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public static readonly string LineString = $"\r\n{new string('=', Console.WindowWidth)}\r\n";

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
                    case "2":
                        Demo.DemoPractice1.Run();
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
            optionList.Add("Say Hello");                //0
            optionList.Add("DemoAsync");                //1
            optionList.Add("DemoPractice1");            //2

            Console.Clear();
            Console.WriteLine(LineString);
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.Write("{0}. {1}\t\t\t", i, optionList[i].ToString());
                if (optionList[i].Length <= 12) Console.Write("\t");
                if ((i+1) % 2 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("please type 'exit' if you want to exit here");
            Console.WriteLine();
            Console.Write("Please type your selection :");
            Console.WriteLine(LineString);
        }
    }
}
