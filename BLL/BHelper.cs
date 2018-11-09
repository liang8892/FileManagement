using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper;

namespace BLL
{
    public class BHelper
    {
        private IDBHelper _dBHelper;
        
        public IDBHelper DbHelper
        {
            get { return _dBHelper; }
            set { _dBHelper = value; }
        }

        //无参构造
        public BHelper()
        {
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="dBHelper">IDBHelper，用来初始化属性DbHelper， 为NULL时抛ArgumentNullException异常</param>
        public BHelper(IDBHelper dBHelper)
        {
            if (dBHelper != null)
                DbHelper = dBHelper;
            else
                throw new ArgumentNullException();
        }


        /// <summary>
        /// 初始化数据库和数据表
        /// </summary>
        /// <param name="dbName">数据库名（包含绝对路径）</param>
        public string InitialDataBaseAndDataTable(string dbName)
        {
            string message = "";
            bool result = DbHelper.CreateDataBase(dbName, ref message);
            if (result)
            {
                if (!CreateDataTable("tb_FileManagement", "", ref message))
                    return message;
                return "OK!";
            }
            return message;
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="columns">字段名及格式描述</param>
        public bool CreateDataTable(string tbName, string columns, ref string message)
        {
            bool result = DbHelper.CreateDataTable(tbName, columns, ref message);
            //MessageBox.Show(message);
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="fileds">要查询的所有字段</param>
        /// <param name="condition">指定where条件（需要where）</param>
        /// <returns></returns>
        public DataSet Query(string tbName, string fileds, string condition)
        {
            string sql = $"select {fileds} from {tbName} {condition}";
            return DbHelper.Query(sql);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="fileds">字段</param>
        /// <param name="values">值</param>
        /// <returns></returns>
        public int Insert(string tbName, string fileds, string values)
        {
            string sql = $"insert into {tbName} ({fileds}) values({values})";
            return DbHelper.ExcuteSQL(sql);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="fileds">字段及字段值</param>
        /// <param name="condition">指定where条件（需要where关键字）</param>
        /// <returns></returns>
        public int Update(string tbName, string fileds, string condition)
        {
            string sql = $"update {tbName} set {fileds} {condition}";
            return DbHelper.ExcuteSQL(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="condition">指定where条件（不需要where关键字）</param>
        /// <returns></returns>
        public int Delete(string tbName, string condition)
        {
            if (!string.IsNullOrEmpty(condition))
            {
                string sql = $"delete from {tbName} where {condition}";
                return DbHelper.ExcuteSQL(sql);
            }
            return 0;
        }
    }
}
