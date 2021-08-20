using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Demo
{
    abstract class DemoBase
    {
        protected static List<string> optionList = new List<string>();
        public static readonly string LineString = $"\r\n{new string('=', Console.WindowWidth)}\r\n";
        public static void ShowOptions()
        {
            Console.WriteLine(LineString);
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.Write("{0}. {1}\t\t\t", i, optionList[i].ToString());
                if (optionList[i].ToString().Length <= 12) Console.Write("\t");
                if ((i + 1) % 2 == 0) Console.WriteLine();
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
