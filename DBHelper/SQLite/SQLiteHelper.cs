using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DBHelper.SQLite
{
    public class SQLiteHelper : IDBHelper
    {
        private readonly string CONNECTIONSTRING;

        public SQLiteHelper(string conStr)
        {
            CONNECTIONSTRING = conStr;
        }


        public bool CreateDataBase(string dbName, ref string message)
        {
            try
            {
                SQLiteConnection.CreateFile(dbName);
                message = $"成功创建数据库文件{dbName}。";
                return true;
                //return $"成功创建数据库文件{dbName}。";
            }
            catch (Exception e)
            {
                message = e.ToString();
                return false;
            }
        }


        public bool CreateDataTable(string tbName, string columns, ref string message)
        {
            
            string sql = $"create table {tbName} ({columns})";
            using (SQLiteConnection conn = new SQLiteConnection(CONNECTIONSTRING))
            {
                try
                { 
                    SQLiteCommand comm = new SQLiteCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    message = $"成功创建数据表{tbName}。";
                    return true;
                }
                catch (Exception e)
                {
                    message = e.ToString();
                    return false;
                }
            }
        }


        public DataSet Query(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTIONSTRING))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SQLiteDataAdapter command = new SQLiteDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    //throw new Exception(ex.Message);
                    return null;
                }
                return ds;
            }
        }

        public int ExcuteSQL(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(CONNECTIONSTRING))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        connection.Close();
                        //throw new Exception(E.Message);
                        return 0;
                    }
                }
            }
        }


        public bool DoTransaction(string[] sqls)
        {
            using (SQLiteConnection conn = new SQLiteConnection(CONNECTIONSTRING))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                SQLiteTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < sqls.Length; n++)
                    {
                        string strsql = sqls[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return true;
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    tx.Rollback();
                    //throw new Exception(E.Message);
                    return false;
                }
            }
        }
    }
}
