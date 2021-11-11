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
                // 取出上一筆(查 toBalance)
                DataObject obj = query(item.cargoHeight, item.UID);

                // 取出上一筆（查 fromBalance）
                DataObject obj2 = new DataObject();
                if (obj.phoneFrom != null)
                {
                    obj2 = query2(item.cargoHeight, obj.phoneFrom);
                }

                // 取出下一筆（查 fromBalance）
                DataObject obj3 = new DataObject();
                if (obj.phoneFrom != null)
                {
                    obj3 = query3(item.cargoHeight, obj.phoneFrom);
                }

                // 取出下一筆（查 toBalance）
                DataObject obj4 = new DataObject();
                if (obj.phoneTo != null)
                {
                    obj4 = query3(item.cargoHeight, obj.phoneTo);
                }

                Debug.Print($"index:{i},UID:{item.UID}, {obj3.fromBalance}, {obj3.toBalance}");

                List<string> a = new List<string>();

                a.Add(i.ToString());
                a.Add(item.UID);
                a.Add(item.cargoHeight);
                a.Add(obj2.cargoHeight);
                a.Add(obj3.cargoHeight);

                if (obj.phoneFrom == obj2.phoneTo)
                {
                    a.Add(obj2.toBalance);
                }
                else
                {
                    a.Add(obj2.fromBalance);
                }

                a.Add(obj3.fromBalance);
                a.Add(obj.toBalance);
                a.Add(obj4.toBalance);
                a.Add(obj.cargoHeight);
                a.Add(obj4.cargoHeight);

                sw.WriteLine(string.Join("\t", a.ToArray()));
                i++;
            }
            sw.Close();
        }

        public DataObject query(string cargoHeight, string phone)
        {
            CSQLiteHelper sqliteHelper = new CSQLiteHelper(dbPath);
            sqliteHelper.OpenDb();

            SQLiteCommand sqlite_cmd = sqliteHelper._SQLiteConn.CreateCommand();
            sqlite_cmd.CommandText = $"select * from cc where cargoid = 106589 and cargoHeight < {cargoHeight} and (phoneTo = {phone} or phoneFrom = {phone})  order by cargoHeight DESC limit 1";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataObject obj = new DataObject();
            while (sqlite_datareader.Read())
            {
                obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
                obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
                obj.toBalance = sqlite_datareader["toBalance"].ToString();
                obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
                obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
                obj.amount = sqlite_datareader["amount"].ToString();
            }
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
            while (sqlite_datareader.Read())
            {
                obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
                obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
                obj.toBalance = sqlite_datareader["toBalance"].ToString();
                obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
                obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
                obj.amount = sqlite_datareader["amount"].ToString();
            }
            sqliteHelper.CloseDb();
            return obj;
        }

        public DataObject query3(string cargoHeight, string phone)
        {
            CSQLiteHelper sqliteHelper = new CSQLiteHelper(dbPath);
            sqliteHelper.OpenDb();

            SQLiteCommand sqlite_cmd = sqliteHelper._SQLiteConn.CreateCommand();
            sqlite_cmd.CommandText = $"select * from cc where cargoid =106589 and cargoHeight >  {cargoHeight} and (phoneTo = {phone} or phoneFrom = {phone}) order by cargoHeight ASC limit 1";

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataObject obj = new DataObject();
            while (sqlite_datareader.Read())
            {
                obj.cargoHeight = sqlite_datareader["cargoHeight"].ToString();
                obj.fromBalance = sqlite_datareader["fromBalance"].ToString();
                obj.toBalance = sqlite_datareader["toBalance"].ToString();
                obj.phoneFrom = sqlite_datareader["phoneFrom"].ToString();
                obj.phoneTo = sqlite_datareader["phoneTo"].ToString();
                obj.amount = sqlite_datareader["amount"].ToString();
            }
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
