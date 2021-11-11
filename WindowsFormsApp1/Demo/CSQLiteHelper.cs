using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace WindowsFormsApp1.Demo
{
    public class CSQLiteHelper
    {
        private string _dbName = "";
        public SQLiteConnection _SQLiteConn = null;     //連接對象
        private SQLiteTransaction _SQLiteTrans = null;   //事務對象
        private bool _IsRunTrans = false;        //事務運行標識
        private string _SQLiteConnString = null; //連接字元串
        private bool _AutoCommit = false; //事務自動提交標識

        public string SQLiteConnString
        {
            set { this._SQLiteConnString = value; }
            get { return this._SQLiteConnString; }
        }

        public CSQLiteHelper(string dbPath)
        {
            this._dbName = dbPath;
            this._SQLiteConnString = "Data Source=" + dbPath;
        }

        /// <summary>
        /// 新建資料庫文件
        /// </summary>
        /// <param name="dbPath">資料庫文件路徑及名稱</param>
        /// <returns>新建成功，返回true，否則返回false</returns>
        static public Boolean NewDbFile(string dbPath)
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建資料庫文件" + dbPath + "失敗：" + ex.Message);
            }
        }


        /// <summary>
        /// 創建表
        /// </summary>
        /// <param name="dbPath">指定資料庫文件</param>
        /// <param name="tableName">表名稱</param>
        static public void NewTable(string dbPath, string tableName)
        {

            SQLiteConnection sqliteConn = new SQLiteConnection("data source=" + dbPath);
            if (sqliteConn.State != System.Data.ConnectionState.Open)
            {
                sqliteConn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = "CREATE TABLE " + tableName + "(Name varchar,Team varchar, Number varchar)";
                cmd.ExecuteNonQuery();
            }
            sqliteConn.Close();
        }
        /// <summary>
        /// 打開當前資料庫的連接
        /// </summary>
        /// <returns></returns>
        public Boolean OpenDb()
        {
            try
            {
                this._SQLiteConn = new SQLiteConnection(this._SQLiteConnString);
                this._SQLiteConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("打開資料庫：" + _dbName + "的連接失敗：" + ex.Message);
            }
        }

        /// <summary>
        /// 打開指定資料庫的連接
        /// </summary>
        /// <param name="dbPath">資料庫路徑</param>
        /// <returns></returns>
        public Boolean OpenDb(string dbPath)
        {
            try
            {
                string sqliteConnString = "Data Source=" + dbPath;

                this._SQLiteConn = new SQLiteConnection(sqliteConnString);
                this._dbName = dbPath;
                this._SQLiteConnString = sqliteConnString;
                this._SQLiteConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("打開資料庫：" + dbPath + "的連接失敗：" + ex.Message);
            }
        }

        /// <summary>
        /// 關閉資料庫連接
        /// </summary>
        public void CloseDb()
        {
            if (this._SQLiteConn != null && this._SQLiteConn.State != ConnectionState.Closed)
            {
                if (this._IsRunTrans && this._AutoCommit)
                {
                    this.Commit();
                }
                this._SQLiteConn.Close();
                this._SQLiteConn = null;
            }
        }

        /// <summary>
        /// 開始資料庫事務
        /// </summary>
        public void BeginTransaction()
        {
            this._SQLiteConn.BeginTransaction();
            this._IsRunTrans = true;
        }

        /// <summary>
        /// 開始資料庫事務
        /// </summary>
        /// <param name="isoLevel">事務鎖級別</param>
        public void BeginTransaction(IsolationLevel isoLevel)
        {
            this._SQLiteConn.BeginTransaction(isoLevel);
            this._IsRunTrans = true;
        }

        /// <summary>
        /// 提交當前掛起的事務
        /// </summary>
        public void Commit()
        {
            if (this._IsRunTrans)
            {
                this._SQLiteTrans.Commit();
                this._IsRunTrans = false;
            }
        }


    }
}
