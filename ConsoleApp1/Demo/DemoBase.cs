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
        public static void ShowOptions()
        {
            Console.WriteLine();
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.Write("{0}. {1}\t\t", i, optionList[i].ToString());
                if ((i + 1) % 3 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("please type 'exit' if you want to exit here");
            Console.WriteLine();
            Console.Write("Please type your selection :");
        }
    }
}
