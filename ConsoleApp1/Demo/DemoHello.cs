﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Immutable;

namespace ConsoleApp1.Demo
{

    public delegate void showMsg(string msg);

    class DemoHello : DemoBase
    {

        public static void Run()
        {
            bool canExecute = true;
            string op = string.Empty;

            Console.Clear();
            optionList.Clear();
            optionList.Add("Hello 001");                    //0
            optionList.Add("ShowEnvironmentDetails");       //1
            optionList.Add("UseDatesAndTimes");             //2
            optionList.Add("BasicStringFunctionality");     //3
            optionList.Add("StringEquality");               //4
            optionList.Add("FunWithStringBuilder");         //5
            optionList.Add("Array Test");         //5

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
                    case "1":
                        ShowEnvironmentDetails();
                        break;
                    case "2":
                        UseDatesAndTimes();
                        break;
                    case "3":
                        BasicStringFunctionality();
                        break;
                    case "4":
                        StringEquality();
                        break;
                    case "5":
                        FunWithStringBuilder();
                        break;
                    case "6":
                        int[] a = new int[] { 1, 2, 3 };

                        Console.WriteLine(a.Length);

                        for (int i = 0; i < a.Length; i++)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("end");

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


        public static void SayHello()
        {
            Console.Clear();
            Console.WriteLine(Program.LineString);

            int a = 9;
            object obj = a;

            int b = (int)obj;


            ArrayList list = new ArrayList();
            list.Add(9);
            list.Add(7);
            list.Add(1);
            list.Add(3);

            foreach (int item in list) {
                Console.WriteLine(item.ToString());
            }









            

        }

        /// <summary>
        /// 系統環境
        /// </summary>
        public static void ShowEnvironmentDetails()
        {
            Console.WriteLine("OS：{0}", Environment.OSVersion);
            Console.WriteLine("Numbers of Processors : {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version : {0}", Environment.Version);
            Console.WriteLine("Is 64 bit OS : {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine("MachineName : {0}", Environment.MachineName);
            Console.WriteLine("User Name : {0}", Environment.UserName);
            Console.WriteLine("System Directory : {0}", Environment.SystemDirectory);
        }

        /// <summary>
        /// 日期及時間
        /// </summary>
        public static void UseDatesAndTimes()
        {
            DateTime dt = new DateTime(2020, 11, 19);
            TimeSpan ts = new TimeSpan(11, 33, 00);

            Console.WriteLine("===================== Dates and Times ==============================");
            Console.WriteLine();
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            Console.WriteLine("Time : {0}", ts.ToString());
            Console.WriteLine();
            Console.WriteLine("=====================================================================");
        }

        /// <summary>
        /// 字串
        /// </summary>
        public static void BasicStringFunctionality()
        {
            Console.WriteLine("BasicStringFunctionality");
            string firstName = "Freddy Freddy";
            Console.WriteLine("Value of firstName : {0}", firstName);
            Console.WriteLine("after replce : {0}", firstName.Replace("dy", "**"));
            Console.WriteLine("firstName contains letter 'y' ? {0}", firstName.Contains("y"));
            Console.WriteLine("firstName : {0} \a", firstName);
            Console.WriteLine(@"D:\RD_2020\temp");
        }

        public static void StringEquality()
        {
            string s1 = "Hello";
            string s2 = "Yo!";
            Console.WriteLine("s1 : {0}, s2 : {1}", s1, s2);
            Console.WriteLine("s1 == s2 ： {0}", s1 == s2);
            Console.WriteLine("s1.Equals(s2) : {0}", s1.Equals(s2));
            Console.WriteLine("Yo!.Equals(s2) : {0}", "Yo!".Equals(s2));
            Console.WriteLine("Yo! === s2 ： {0}", "Yo!" == s2);
        }

        public static void FunWithStringBuilder()
        {
            StringBuilder sb = new StringBuilder("**** Fantastic Game ****");
            sb.Append("\n");
            sb.AppendLine("Half life");

            Console.WriteLine(sb.ToString());

        }

        public static void EnterLogData(string msg, string owner = "BOSS")
        {
            Console.WriteLine("Message is {0}, Owner is {1}", msg, owner);
        }

    }





    public class ToolCompare<T> where T : IComparable {
        public static int Comp(T o1, T o2) {
            return o1.CompareTo(o2);
        }
    }


    public class Book : IComparable
    {
        public int price;
        public string title;

        public Book(string t, int p) {
            title = t;
            price = p;
        }

        public int CompareTo(object obj)
        {
            Book b2 = (Book)obj;
            
            //return this.price.CompareTo(b2.price);
            return this.title.CompareTo(b2.title);
        }

        public void show(showMsg cb) {
            cb(this.title);
        }
    }


    public class BaseType {

        public virtual String Name { 
            get; 
            set; 
        }

    }


    public class User
    {
        private Lazy<string> uname;
        //public string UserName => uname.Value;

        public string UserName {
            get => uname.Value;
            
        }

        public User()
        {
            uname = new Lazy<string>(()=>"xinchin");
        }
    }


}

