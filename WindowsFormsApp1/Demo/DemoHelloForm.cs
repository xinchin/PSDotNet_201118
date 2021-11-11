using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1.Demo
{
    public partial class DemoHelloForm : Form
    {
        public int x = 0;
        SynchronizationContext _context;
        public DemoHelloForm()
        {
            InitializeComponent();
        }

        public string SayHello()
        {
            return "hello";
        }

        private void DemoHelloForm_Load(object sender, EventArgs e)
        {
            //Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Console.WriteLine($"Main:{Thread.CurrentThread.ManagedThreadId}");
            _context = SynchronizationContext.Current;
            new Thread(work).Start();

        }
        void work() {
            Thread.Sleep(5000);
            UpdateMessage("Hello");
        }

        void UpdateMessage(string msg) {
            _context.Post(_ => textBox1.Text = msg, null);
            
            //_context.Post()
            //textBox1.Text = msg;
        }




        private void button2_Click(object sender, EventArgs e)
        {
        }

        async static Task DisplayPrimeCountsAsync()
        {
            //Thread.Sleep(2000);
            Console.WriteLine($"DisplayPrimeCountsAsync:{Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(await GetPrimeCountAsync(i * 1000000 + 2, 1000000) + " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
            }
            Console.WriteLine("Done!!");
        }

        static Task<int> GetPrimeCountAsync(int start, int count)
        {
            Console.WriteLine($"GetPrimeCountAsync:{Thread.CurrentThread.ManagedThreadId}");
            //await Task.Run(()=> {
            //    Console.WriteLine($"Run:{Thread.CurrentThread.ManagedThreadId}");
            //});
            //return 99;
            return Task.Run(() =>
            {
                Console.WriteLine($"Run:{Thread.CurrentThread.ManagedThreadId}");
                return ParallelEnumerable.Range(start, count).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
            });
        }


    }
}
