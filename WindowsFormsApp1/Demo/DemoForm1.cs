using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp1.Demo
{
    public partial class DemoForm1 : Form
    {

        public string dbPath = @"C:\Work\WorkPlace\Doing\qpp.db";
        public List<DataObject> UIDList = new List<DataObject>();

        public DemoForm1()
        {
            InitializeComponent();
        }

        private void DemoForm1_Load(object sender, EventArgs e)
        {
            ReadFileToList();
            StreamWriter sw = new StreamWriter(@"C:\Work\WorkPlace\Doing\result.txt");

            int i = 1;
            foreach (DataObject item in UIDList)
            {
                DataObject obj = query(item.cargoHeight);
                DataObject obj2 = query2(item.cargoHeight, obj.phoneTo);
                DataObject obj3 = query3(item.cargoHeight, obj2.phoneFrom);
                Debug.Print($"index:{i}, UID:{UIDList[0].UID}, cargoHeight:{UIDList[0].cargoHeight}, pre cargoHeight:{obj2.cargoHeight}, next cargoHeight:{obj3.cargoHeight}, pre fromBalance:{obj2.fromBalance}, next fromBalance:{obj3.fromBalance}");
                List<string> a = new List<string>();

                a.Add(i.ToString());
                a.Add(item.UID);
                a.Add(item.cargoHeight);
                a.Add(obj2.cargoHeight);
                a.Add(obj3.cargoHeight);
                a.Add(obj2.fromBalance);
                a.Add(obj3.fromBalance);
                a.Add(obj2.toBalance);
                a.Add(obj3.toBalance);
                a.Add(obj2.amount);
                a.Add(obj3.amount);

                if (ulong.Parse(obj2.cargoHeight) == ulong.Parse(item.cargoHeight) - 1 && ulong.Parse(obj3.cargoHeight) == ulong.Parse(item.cargoHeight) + 1)
                {
                    a.Add("Yes");
                }
                else
                {
                    a.Add("No");
                }

                ulong x, y = 0;
                if (ulong.Parse(obj2.fromBalance) > ulong.Parse(obj3.fromBalance))
                {
                    x = ulong.Parse(obj2.fromBalance) - ulong.Parse(obj3.fromBalance);
                    y = ulong.Parse(obj3.fromBalance);
                }
                else
                {
                    x = ulong.Parse(obj3.fromBalance) - ulong.Parse(obj2.fromBalance);
                    y = ulong.Parse(obj2.fromBalance);
                }

                if (x / 2 == ulong.Parse(obj2.amount))
                {
                    a.Add((y+x/2).ToString());
                }
                else {
                    a.Add("");
                }

                if (ulong.Parse(obj2.fromBalance) > ulong.Parse(obj3.fromBalance))
                {
                    a.Add((ulong.Parse(obj2.fromBalance) - ulong.Parse(obj3.fromBalance)).ToString());
                }
                else { 
                    a.Add((ulong.Parse(obj3.fromBalance) - ulong.Parse(obj2.fromBalance)).ToString());

                }

                if (ulong.Parse(obj2.toBalance) > ulong.Parse(obj3.toBalance))
                {
                    a.Add((ulong.Parse(obj2.toBalance) - ulong.Parse(obj3.toBalance)).ToString());
                }
                else
                {
                    a.Add((ulong.Parse(obj3.toBalance) - ulong.Parse(obj2.toBalance)).ToString());
                }

                sw.WriteLine(string.Join("\t", a.ToArray()));
                i++;
            }
            sw.Close();
        }

        public DataObject query(string cargoHeight)
        {
            CSQLiteHelper sqliteHelper = new CSQLiteHelper(dbPath);
            sqliteHelper.OpenDb();

            SQLiteCommand sqlite_cmd = sqliteHelper._SQLiteConn.CreateCommand();
            sqlite_cmd.CommandText = $"select * from cc where cargoid = 106589 and cargoHeight < {cargoHeight} order by cargoHeight DESC limit 1";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataObject obj = new DataObject();
            sqlite_datareader.Read();
            obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
            obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
            obj.toBalance = sqlite_datareader["toBalance"].ToString();
            obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
            obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
            obj.amount = sqlite_datareader["amount"].ToString();
            sqliteHelper.CloseDb();
            return obj;
        }

        public DataObject query2(string cargoHeight, string phone)
        {
            CSQLiteHelper sqliteHelper = new CSQLiteHelper(dbPath);
            sqliteHelper.OpenDb();

            SQLiteCommand sqlite_cmd = sqliteHelper._SQLiteConn.CreateCommand();
            sqlite_cmd.CommandText = $"select * from cc where cargoid =106589 and cargoHeight <  {cargoHeight} and (phoneTo = {phone} or phoneFrom = {phone}) order by cargoHeight DESC limit 1";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataObject obj = new DataObject();
            sqlite_datareader.Read();
            obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
            obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
            obj.toBalance = sqlite_datareader["toBalance"].ToString();
            obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
            obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
            obj.amount = sqlite_datareader["amount"].ToString();
            sqliteHelper.CloseDb();
            return obj;
        }

        public DataObject query3(string cargoHeight, string phone)
        {
            CSQLiteHelper sqliteHelper = new CSQLiteHelper(dbPath);
            sqliteHelper.OpenDb();

            SQLiteCommand sqlite_cmd = sqliteHelper._SQLiteConn.CreateCommand();//create command
            sqlite_cmd.CommandText = $"select * from cc where cargoid =106589 and cargoHeight >  {cargoHeight} and (phoneTo = {phone} or phoneFrom = {phone}) order by cargoHeight ASC limit 1";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataObject obj = new DataObject();
            sqlite_datareader.Read();
            obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
            obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
            obj.toBalance = sqlite_datareader["toBalance"].ToString();
            obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
            obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
            obj.amount = sqlite_datareader["amount"].ToString();
            sqliteHelper.CloseDb();

            return obj;
        }
        public void ReadFileToList()
        {
            StreamReader sr = new StreamReader(@"C:\Work\WorkPlace\Doing\106589.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] a = line.Split('\t');
                DataObject obj = new DataObject() { UID = a[0], cargoHeight = a[1] };
                UIDList.Add(obj);

                line = sr.ReadLine();
            }
            sr.Close();
            Console.ReadLine();
        }
        public class DataObject
        {
            public string UID;
            public string cargoHeight;
            public string phoneFrom;
            public string phoneTo;
            public string fromBalance;
            public string toBalance;
            public string amount;
        }
    }
}
